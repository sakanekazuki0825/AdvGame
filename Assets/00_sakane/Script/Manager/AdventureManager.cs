using System.Collections.Generic;
using UnityEngine;

// アドベンチャー管理クラス
public class AdventureManager : ManagerBase<AdventureManager>
{
	// アドベンチャー
	[SerializeField]
	List<SO_Chapter> adventures = new List<SO_Chapter>();

	// アドベンチャーキャンバス
	[SerializeField]
	GameObject adventureCanvasPrefab;
	GameObject adventureCanvas;
	IAdventureCanvas iAdventureCanvas;

	// 章の番号
	int chapterNumber = 0;
	// カット番号
	int cutNumber = 0;

	private void Start()
	{
		// アドベンチャーキャンバス生成
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		// アドベンチャーキャンバス表示
		adventureCanvas.SetActive(true);
		// アドベンチャーのインタフェイス取得
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		// 章の番号設定
		foreach (var v in adventures)
		{
			v.chapterNumber = adventures.IndexOf(v);
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void Initialize()
	{
		chapterNumber = 0;
		cutNumber = 0;
	}

	/// <summary>
	/// 次のカット
	/// </summary>
	public void NextCut()
	{
		// 番号を進める
		++cutNumber;

		// カット数を超えていないか調べる
		if (cutNumber >= adventures[chapterNumber].chapterCuts.Count)
		{
			NextChapter();
		}
		// カット変更
		iAdventureCanvas.CutChange(adventures[chapterNumber].chapterCuts[cutNumber]);
	}

	/// <summary>
	/// 次の章に進む
	/// </summary>
	public void NextChapter()
	{
		// 番号を進める
		++chapterNumber;
		// カットは0から
		cutNumber = 0;
		// チャプター数が超えていないか調べる
		if (chapterNumber >= adventures.Count)
		{
			// ゲームクリア
			Debug.Log("ゲームクリア");
			chapterNumber = 0;
			LevelManager.OpenLevel("TitleScene").Forget();
		}
		else
		{
			// 章の状態を設定
			iAdventureCanvas.ChapterChange(adventures[chapterNumber].chapter);
		}
	}
}