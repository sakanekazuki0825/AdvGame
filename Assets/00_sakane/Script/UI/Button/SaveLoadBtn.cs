using UnityEngine;
using UnityEngine.UI;

// 保存読み込みボタン
public class SaveLoadBtn : MonoBehaviour
{
	// 画像
	Image image;

	private void Start()
	{
		// 画像取得
		image = GetComponent<Image>();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Init()
	{

	}

	/// <summary>
	/// ボタンの設定
	/// </summary>
	/// <param name="sprite">設定する画像</param>
	public void SetButton(Sprite sprite)
	{
		// 画像設定
		image.sprite = sprite;
	}

	/// <summary>
	/// クリック
	/// </summary>
	public void Click()
	{

	}
}