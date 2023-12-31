// Copyright 2023 ReWaffle LLC. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Naninovel.UI
{
    /// <summary>
    /// A <see cref="UITextPrinterPanel"/> implementation that uses <see cref="IRevealableText"/> to reveal text over time.
    /// </summary>
    /// <remarks>
    /// A <see cref="IRevealableText"/> component should be attached to the underlying game object or one of it's child objects.
    /// </remarks>
    public class RevealableTextPrinterPanel : UITextPrinterPanel
    {
        [Serializable]
        protected class CharsToSfx
        {
            [Tooltip("The characters for which to trigger the SFX. Leave empty to trigger on any character.")]
            public string Characters;
            [Tooltip("The name (local path) of the SFX to trigger for the specified characters.")]
            [ResourcePopup(AudioConfiguration.DefaultAudioPathPrefix)]
            public string SfxName;
        }

        [Serializable]
        protected class CharsToPlaylist
        {
            [Tooltip("The characters for which to trigger the command. Leave empty to trigger on any character.")]
            public string Characters;
            [Tooltip("The text of the script command to execute for the specified characters.")]
            public string CommandText;
            public ScriptPlaylist Playlist { get; set; }
        }

        [Serializable]
        private class AuthorChangedEvent : UnityEvent<string> { }

        public override string PrintedText { get => RevealableText.Text; set => RevealableText.Text = value; }
        public override string AuthorNameText { get => AuthorNamePanel ? AuthorNamePanel.Text : null; set => SetAuthorNameText(value); }
        public override float RevealProgress { get => RevealableText.RevealProgress; set => SetRevealProgress(value); }
        public override string Appearance { get => GetActiveAppearance(); set => SetActiveAppearance(value); }
        public virtual IRevealableText RevealableText { get; private set; }

        protected const string DefaultAppearanceName = "Default";

        protected virtual string AuthorId { get; private set; }
        protected virtual CharacterMetadata AuthorMeta { get; private set; }
        protected virtual IInputIndicator InputIndicator { get; private set; }

        protected virtual AuthorNamePanel AuthorNamePanel => authorNamePanel;
        protected virtual AuthorImage AuthorAvatarImage => authorAvatarImage;
        protected virtual bool PositionIndicatorOverText => positionIndicatorOverText;
        protected virtual List<CanvasGroup> Appearances => appearances;
        protected virtual List<CharsToSfx> CharsSfx => charsSfx;
        protected virtual List<CharsToPlaylist> CharsCommands => charsCommands;

        [SerializeField] private AuthorNamePanel authorNamePanel;
        [SerializeField] private AuthorImage authorAvatarImage;
        [FormerlySerializedAs("inputIndicatorPrefab"), Tooltip("Object to use as an indicator when player is supposed to activate a `Continue` input to progress further. The prefab should have an `IInputIndicator` component on the root game object. Will instantiate a clone when an external prefab is assigned.")]
        [SerializeField] private MonoBehaviour inputIndicator;
        [Tooltip("Whether to automatically move input indicator so it appears after the last revealed text character.")]
        [SerializeField] private bool positionIndicatorOverText = true;
        [Tooltip("Assigned canvas groups will represent printer appearances. Game object name of the canvas group represents the appearance name. Alpha of the group will be set to 1 when the appearance is activated and vice-versa.")]
        [SerializeField] private List<CanvasGroup> appearances;
        [Tooltip("Allows binding an SFX to play when specific characters are revealed.")]
        [SerializeField] private List<CharsToSfx> charsSfx = new List<CharsToSfx>();
        [Tooltip("Allows binding a script command to execute when specific characters are revealed.")]
        [SerializeField] private List<CharsToPlaylist> charsCommands = new List<CharsToPlaylist>();
        [Tooltip("Invoked when author (character ID) of the currently printed text is changed.")]
        [SerializeField] private AuthorChangedEvent onAuthorChanged;
        [Tooltip("Invoked when text reveal is started.")]
        [SerializeField] private UnityEvent onRevealStarted;
        [Tooltip("Invoked when text reveal is finished.")]
        [SerializeField] private UnityEvent onRevealFinished;

        private readonly CommandParser commandParser = new CommandParser();

        private Color defaultMessageColor, defaultNameColor;
        private IAudioManager audioManager;
        private IScriptPlayer scriptPlayer;

        public override async UniTask InitializeAsync ()
        {
            await base.InitializeAsync();

            if (CharsSfx != null && CharsSfx.Count > 0)
            {
                var loadTasks = new List<UniTask>();
                foreach (var charSfx in CharsSfx)
                    if (!string.IsNullOrEmpty(charSfx.SfxName))
                        loadTasks.Add(audioManager.AudioLoader.LoadAndHoldAsync(charSfx.SfxName, this));
                await UniTask.WhenAll(loadTasks);
            }

            if (CharsCommands != null && CharsCommands.Count > 0)
                foreach (var charsCommand in CharsCommands)
                    if (!string.IsNullOrEmpty(charsCommand.CommandText))
                        charsCommand.Playlist = new ScriptPlaylist(Script.FromScriptText($"`{name}` printer `{charsCommand.Characters}` char command", charsCommand.CommandText));
        }

        public override async UniTask RevealPrintedTextOverTimeAsync (float revealDelay, AsyncToken asyncToken)
        {
            onRevealStarted?.Invoke();

            // Force-hide the indicator. Required when printing by non-played commands (eg, PlayScript component),
            // while the script player is actually waiting for input.
            SetWaitForInputIndicatorVisible(false);

            if (revealDelay <= 0)
            {
                RevealableText.RevealProgress = 1f;
                onRevealFinished?.Invoke();
                return;
            }

            var lastRevealTime = Time.time;
            while (RevealableText.RevealProgress < 1)
            {
                var charsToReveal = await WaitForCharsToRevealAsync(lastRevealTime, revealDelay, asyncToken);
                var lastRevealProgress = -1f;
                lastRevealTime = Time.time;
                RevealableText.RevealNextChars(charsToReveal, revealDelay, asyncToken);
                while (RevealableText.Revealing)
                {
                    await AsyncUtils.WaitEndOfFrameAsync(asyncToken);
                    if (!Mathf.Approximately(lastRevealProgress, lastRevealProgress = RevealableText.RevealProgress))
                        lastRevealTime += await ExecuteRevealRoutinesAsync(asyncToken);
                    if (asyncToken.Completed) RevealableText.RevealProgress = 1f;
                }
            }

            if (scriptPlayer.WaitingForInput)
                SetWaitForInputIndicatorVisible(true);

            onRevealFinished?.Invoke();
        }

        public override void SetWaitForInputIndicatorVisible (bool visible)
        {
            if (visible)
            {
                InputIndicator.Show();
                if (PositionIndicatorOverText) PlaceInputIndicatorOverText();
            }
            else InputIndicator.Hide();
        }

        public override void SetFontSize (int dropdownIndex)
        {
            base.SetFontSize(dropdownIndex);
            if (PositionIndicatorOverText) PlaceInputIndicatorOverText();
        }

        public override void SetFont (Font font, TMP_FontAsset tmpFont)
        {
            base.SetFont(font, tmpFont);
            if (PositionIndicatorOverText) PlaceInputIndicatorOverText();
        }

        public override void OnAuthorChanged (string authorId, CharacterMetadata authorMeta)
        {
            AuthorId = authorId;
            AuthorMeta = authorMeta;

            RevealableText.TextColor = authorMeta.UseCharacterColor ? authorMeta.MessageColor : defaultMessageColor;

            if (AuthorNamePanel)
                AuthorNamePanel.TextColor = authorMeta.UseCharacterColor ? authorMeta.NameColor : defaultNameColor;

            if (AuthorAvatarImage)
            {
                var avatarTexture = CharacterManager.GetAvatarTextureFor(authorId);
                AuthorAvatarImage.ChangeTextureAsync(avatarTexture).Forget();
            }

            onAuthorChanged?.Invoke(authorId);
        }

        protected override void Awake ()
        {
            base.Awake();
            this.AssertRequiredObjects(inputIndicator);

            RevealableText = GetComponentInChildren<IRevealableText>();
            Debug.Assert(RevealableText != null, $"IRevealableText component not found on {gameObject.name} or its descendants.");

            defaultMessageColor = RevealableText.TextColor;
            defaultNameColor = AuthorNamePanel ? AuthorNamePanel.TextColor : default;

            if (inputIndicator.transform.IsChildOf(transform))
                InputIndicator = inputIndicator.GetComponent<IInputIndicator>();
            else
            {
                InputIndicator = Instantiate(inputIndicator).GetComponent<IInputIndicator>();
                InputIndicator.RectTransform.SetParent(RevealableText.GameObject.transform, false);
            }

            audioManager = Engine.GetService<IAudioManager>();
            scriptPlayer = Engine.GetService<IScriptPlayer>();

            SetAuthorNameText(null);
        }

        protected override void OnEnable ()
        {
            base.OnEnable();

            CharacterManager.OnCharacterAvatarChanged += HandleAvatarChanged;
        }

        protected override void OnDisable ()
        {
            base.OnDisable();

            if (CharacterManager != null)
                CharacterManager.OnCharacterAvatarChanged -= HandleAvatarChanged;
        }

        protected virtual void LateUpdate ()
        {
            if (Visible) RevealableText?.Render();
        }

        protected override void OnDestroy ()
        {
            base.OnDestroy();

            if (CharsSfx != null && CharsSfx.Count > 0)
                foreach (var charSfx in CharsSfx)
                    if (!string.IsNullOrEmpty(charSfx.SfxName))
                        audioManager?.AudioLoader?.Release(charSfx.SfxName, this);
        }

        protected override void OnRectTransformDimensionsChange ()
        {
            base.OnRectTransformDimensionsChange();
            if (PositionIndicatorOverText) PlaceInputIndicatorOverText();
        }

        protected override void HandleVisibilityChanged (bool visible)
        {
            base.HandleVisibilityChanged(visible);

            if (!visible && AuthorAvatarImage && AuthorAvatarImage.isActiveAndEnabled)
                AuthorAvatarImage.ChangeTextureAsync(null).Forget();
        }

        protected virtual async void PlaceInputIndicatorOverText ()
        {
            // Wait a frame, so it'll return a correct position when reveal speed is instant.
            // Only affect uGUI printers, where rebuild is postponed by a frame.
            await UniTask.DelayFrame(1);
            if (!ObjectUtils.IsValid(InputIndicator)) return;
            var lastRevelPos = RevealableText.GetLastRevealedCharPosition();
            if (float.IsNaN(lastRevelPos.x) || float.IsNaN(lastRevelPos.y)) return;
            InputIndicator.RectTransform.position = new Vector3(lastRevelPos.x, lastRevelPos.y, InputIndicator.RectTransform.position.z);
        }

        protected virtual string GetActiveAppearance ()
        {
            if (Appearances is null || Appearances.Count == 0)
                return DefaultAppearanceName;
            foreach (var grp in Appearances)
                if (Mathf.Approximately(grp.alpha, 1f))
                    return grp.gameObject.name;
            return DefaultAppearanceName;
        }

        protected virtual void SetActiveAppearance (string appearance)
        {
            if (Appearances is null || Appearances.Count == 0 || !Appearances.Any(g => g.gameObject.name == appearance))
                return;

            foreach (var grp in Appearances)
                grp.alpha = grp.gameObject.name == appearance ? 1 : 0;
        }

        protected virtual void SetRevealProgress (float value)
        {
            RevealableText.RevealProgress = value;
        }

        protected virtual void SetAuthorNameText (string text)
        {
            if (!AuthorNamePanel) return;

            var isActive = !string.IsNullOrWhiteSpace(text);
            AuthorNamePanel.gameObject.SetActive(isActive);
            if (!isActive) return;

            AuthorNamePanel.Text = text;
        }

        protected virtual void HandleAvatarChanged (CharacterAvatarChangedArgs args)
        {
            if (!AuthorAvatarImage || args.CharacterId != AuthorId) return;

            AuthorAvatarImage.ChangeTextureAsync(args.AvatarTexture).Forget();
        }

        protected virtual async UniTask<int> WaitForCharsToRevealAsync (float start, float delay, AsyncToken asyncToken)
        {
            int count = 0;
            while (count == 0)
            {
                await AsyncUtils.WaitEndOfFrameAsync(asyncToken);
                count = Mathf.FloorToInt((Time.time - start) / delay);
            }
            return count;
        }

        protected virtual async UniTask<float> ExecuteRevealRoutinesAsync (AsyncToken asyncToken)
        {
            var execStartTime = Time.time;
            var lastRevealedChar = RevealableText.GetLastRevealedChar();
            PlayAuthorSound();
            PlayRevealSfxForChar(lastRevealedChar);
            await ExecuteCommandForCharAsync(lastRevealedChar, asyncToken);
            return Time.time - execStartTime;
        }

        protected virtual void PlayAuthorSound ()
        {
            if (AuthorMeta is null || string.IsNullOrEmpty(AuthorMeta.MessageSound)) return;

            audioManager.PlaySfxFast(AuthorMeta.MessageSound,
                restart: AuthorMeta.MessageSoundPlayback == MessageSoundPlayback.OneShotClipped,
                additive: AuthorMeta.MessageSoundPlayback != MessageSoundPlayback.Looped);
        }

        protected virtual void PlayRevealSfxForChar (char character)
        {
            if (CharsSfx is null) return;

            foreach (var chars in CharsSfx)
                if (ShouldPlay(chars))
                    audioManager.PlaySfxFast(chars.SfxName);

            bool ShouldPlay (CharsToSfx chars) =>
                !string.IsNullOrEmpty(chars.SfxName) &&
                (string.IsNullOrEmpty(chars.Characters) || chars.Characters.IndexOf(character) >= 0);
        }

        protected virtual async UniTask ExecuteCommandForCharAsync (char character, AsyncToken asyncToken)
        {
            if (CharsCommands is null) return;

            foreach (var chars in CharsCommands)
                if (ShouldExecute(chars))
                    await chars.Playlist.ExecuteAsync(asyncToken);

            bool ShouldExecute (CharsToPlaylist chars) =>
                chars.Playlist != null && chars.Playlist.Count > 0 &&
                (string.IsNullOrEmpty(chars.Characters) || chars.Characters.IndexOf(character) >= 0);
        }
    }
}
