using UnityEngine;
using UnityEngine.UI;

// アドベンチャーを表示するキャンバス
public class AdventureCanvas : CanvasBase, IAdventureCanvas
{
	// 現在のアドベンチャー
	AdventureBase adventure;

	// 背景画像
	[SerializeField]
	Image backGroundImg;

	// キャラクター画像
	[SerializeField]
	Image characterImg;

	/// <summary>
	/// アドベンチャー設定
	/// </summary>
	/// <param name="adventure">設定するアドベンチャー</param>
	void IAdventureCanvas.SetAdventure(AdventureBase adventure)
	{
		this.adventure = adventure;
		// 背景設定
		backGroundImg.sprite = adventure.backGroundSprite;
		// 文字表示
		MainMessageText.Instance.TextDisplay(adventure.messagese[0]);
	}
}
