using UnityEngine;
using TMPro;
using System.Collections;

// テキスト管理クラス
public class MainMessageText : Singleton<MainMessageText>
{
	// 文字を表示するテキスト
	[SerializeField]
	TextMeshProUGUI text;

	// 次の文字を表示するまでの時間
	[SerializeField]
	float nextLetterTime = 0;

	// 文字送りが終わった後に表示される矢印
	[SerializeField]
	GameObject arrow;

	// true = 文字送り終了
	bool isFinish = false;
	public bool IsFinish
	{
		get => isFinish;
	}

	private void Start()
	{
		arrow?.SetActive(false);
	}

	/// <summary>
	/// 文字の表示
	/// </summary>
	/// <param name="message">表示する文字</param>
	public void TextDisplay(string message)
	{
		text.text = message;
		StartCoroutine(CharacterFeedJP());
	}

	/// <summary>
	/// 全ての文字表示
	/// </summary>
	public void CharacterFeedSkip()
	{
		// 文字を全て表示する
		text.maxVisibleCharacters = text.text.Length;
	}

	/// <summary>
	/// 文字送り
	/// </summary>
	/// <returns></returns>
	IEnumerator CharacterFeedJP()
	{
		// 矢印非表示
		arrow?.SetActive(false);
		// 文字送り中
		isFinish = false;

		// 一文字目は最初から表示
		text.maxVisibleCharacters = 1;
		// 文字を最後まで表示する
		while (text.text.Length > text.maxVisibleCharacters)
		{
			// 次の文字を表示するまで待つ
			yield return new WaitForSeconds(nextLetterTime);
			// 文字送り
			++text.maxVisibleCharacters;
		}

		// 矢印表示
		arrow?.SetActive(true);

		// 文字送り終了
		isFinish = true;

		yield break;
	}
}