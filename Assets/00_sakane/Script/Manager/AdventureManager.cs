using UnityEngine;

// アドベンチャー管理クラス
public sealed class AdventureManager : ManagerBase<AdventureManager>
{
	// アドベンチャーのキャンバス
	[SerializeField]
	GameObject adventureCanvasPrefab;
	GameObject adventureCanvas;

	// アドベンチャーキャンバスのインターフェース
	IAdventureCanvas iAdventureCanvas;

	// 表示しているアドベンチャーの番号
	int adventureNumber = 0;
	// 表示しているメッセージの番号
	int messageNumber = 0;

	// アドベンチャー
	[SerializeField]
	SO_Adventure so_adventure;

	private void Start()
	{
		// アドベンチャー用のキャンバス生成
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		adventureCanvas.SetActive(true);
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		iAdventureCanvas.SetAdventure(so_adventure.adv[adventureNumber]);
	}

	/// <summary>
	/// 次のアドベンチャーに進む
	/// </summary>
	public void NextAdventure()
	{
		++adventureNumber;
	}

	/// <summary>
	/// 次のメッセージに
	/// </summary>
	public void NextMessage()
	{
		if (MainMessageText.Instance.IsFinish)
		{
			// メッセージの番号
			++messageNumber;
			if (so_adventure.adv[adventureNumber].messagese.Count > messageNumber)
			{
				// テキストを更新
				MainMessageText.Instance.TextDisplay(so_adventure.adv[adventureNumber].messagese[messageNumber]);
			}
			else
			{
				// メッセージの番号リセット
				messageNumber = 0;
				// 次のアドベンチャーに進む
				NextAdventure();
				// アドベンチャーを設定
				iAdventureCanvas.SetAdventure(so_adventure.adv[adventureNumber]);
			}
		}
		else
		{
			// 文字送りを飛ばして全ての文字を表示する
			MainMessageText.Instance.CharacterFeedSkip();
		}
	}

	/// <summary>
	/// アドベンチャー読み込み
	/// </summary>
	public void AdventureLoad()
	{
		// アドベンチャーをクリア
		so_adventure.adv.Clear();
		// アドベンチャーをCSVから読み込む？
	}
}