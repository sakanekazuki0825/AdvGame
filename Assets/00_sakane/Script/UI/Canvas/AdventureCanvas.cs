using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

// アドベンチャーキャンバス
public class AdventureCanvas : CanvasBase, IAdventureCanvas
{
	// 背景画像
	[SerializeField]
	Image backGroundImg;

	// キャラクター
	[SerializeField]
	Image characterImg;
	Animator characterAnimator;

	// セリフなどのテキスト
	[SerializeField]
	GameObject messageTxt;
	IAdvText iadvText;

	protected override void Start()
	{
		base.Start();
		// キャラクターのアニメーター取得
		characterAnimator = characterImg.GetComponent<Animator>();

		iadvText = messageTxt.GetComponent<IAdvText>();
	}

	/// <summary>
	/// チャプター変更
	/// </summary>
	/// <param name="chapter">章の情報</param>
	public void ChapterChange(Chapter chapter)
	{
		// 背景設定
		backGroundImg.sprite = chapter.backGround;
		// キャラクター画像設定
		characterImg.sprite = chapter.characterSprite;
		// アニメーターコントローラー設定
		characterAnimator.runtimeAnimatorController = chapter.characterAnimatorController;
	}

	/// <summary>
	/// カット変更
	/// </summary>
	/// <param name="cut">カット</param>
	public async UniTask CutChange(OneCut cut)
	{
		var token = this.GetCancellationTokenOnDestroy();
		if (iadvText.IsCharacterFeeding())
		{
			iadvText.AllMessageDisplay();
			return;
		}
		await cut.CutBeforeEvent(token);
		// テキスト設定
		iadvText.SetMessageTxt(cut.message);
		// 選択肢の表示が必要か調べる
		if (cut.isChoice)
		{

		}
		// パラメーターを全て取得
		var animParams = characterAnimator.parameters;
		foreach (var param in animParams)
		{
			// 同じ名前のプロパティがある場合アニメーションを変更
			if (param.name == cut.cutNumber.ToString())
			{
				characterAnimator.SetTrigger(cut.cutNumber.ToString());
			}
		}

		await cut.CurAfterEvent(token);
	}
}