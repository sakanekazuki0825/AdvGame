using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

// アドベンチャーのテキスト
public class AdvText : MonoBehaviour,IAdvText
{
	// セリフなどを表示するテキスト
	TextMeshProUGUI messageTxt;

	// true = 文字送り中
	bool isCharacterFeeding = false;

	private void Start()
	{
		// テキスト取得
		messageTxt = GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// テキストを設定
	/// </summary>
	/// <param name="message"></param>
	public void SetMessageTxt(string message)
	{
		// テキスト設定
		messageTxt.text = message;
		// キャンセレーショントークン取得
		var token = this.GetCancellationTokenOnDestroy();
		// 文字送り開始
		CharacterFeed(token).Forget();
	}

	/// <summary>
	/// 文字送り
	/// </summary>
	/// <param name="token">キャンセレーショントークン</param>
	/// <returns></returns>
	async UniTask CharacterFeed(CancellationToken token)
	{
		// 文字送り中
		isCharacterFeeding = true;
		// 文字を表示しない
		messageTxt.maxVisibleCharacters = 0;
		while (messageTxt.maxVisibleCharacters < messageTxt.text.Length && isCharacterFeeding)
		{
			// 文字送りの速度待つ
			await UniTask.WaitForSeconds(GameInstance.saveData.characterFeedSpeed);
			// 一文字追加
			++messageTxt.maxVisibleCharacters;
		}
		// 文字送り終了
		isCharacterFeeding = false;
	}

	/// <summary>
	/// 文字送りを終了して全てのテキストを表示する
	/// </summary>
	public void AllMessageDisplay()
	{
		messageTxt.maxVisibleCharacters = messageTxt.text.Length;
		isCharacterFeeding = false;
	}

	/// <summary>
	/// 文字送りの状態取得
	/// </summary>
	/// <returns></returns>
	public bool IsCharacterFeeding()
	{
		return isCharacterFeeding;
	}
}