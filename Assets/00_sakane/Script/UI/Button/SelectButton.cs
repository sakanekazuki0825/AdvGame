using UnityEngine;
using UnityEngine.UI;

// 選択ボタン
public class SelectButton : MonoBehaviour
{
	// ボタンのテキスト
	Text text;

	private void Start()
	{
		// テキスト取得
		text = GetComponentInChildren<Text>();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	/// <param name="message">テキストに表示する文字</param>
	public void Initialized(string message)
	{
		// 文字を設定
		text.text = message;
	}
}