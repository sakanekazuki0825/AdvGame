using Cysharp.Threading.Tasks;
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

	// 現在のデータ
	AdvData advData = new AdvData();

	private void Start()
	{
		// アドベンチャーキャンバス生成
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		// アドベンチャーキャンバス表示
		adventureCanvas.SetActive(true);
		// アドベンチャーのインタフェイス取得
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		//// 章の番号設定
		//foreach (var v in adventures)
		//{
		//	v.chapterNumber = adventures.IndexOf(v);
		//}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void Initialize()
	{
		
	}

	/// <summary>
	/// 次のカット
	/// </summary>
	public void NextCut()
	{
		// 番号を進める
		++advData.cutNumber;

		// カット数を超えていないか調べる
		if (advData.cutNumber >= adventures[advData.chapterNumber].chapterCuts.Count)
		{
			NextChapter();
		}
		// カット変更
		iAdventureCanvas.CutChange(adventures[advData.chapterNumber].chapterCuts[advData.cutNumber]).Forget();
	}

	/// <summary>
	/// 次の章に進む
	/// </summary>
	public void NextChapter()
	{
		// 番号を進める
		++advData.chapterNumber;
		// カットは0から
		advData.cutNumber = 0;
		// チャプター数が超えていないか調べる
		if (advData.chapterNumber >= adventures.Count)
		{
			// ゲームクリア
			Debug.Log("ゲームクリア");
			advData.chapterNumber = 0;
			LevelManager.OpenLevel("TitleScene").Forget();
		}
		else
		{
			// 章の状態を設定
			iAdventureCanvas.ChapterChange(adventures[advData.chapterNumber].chapter);
		}
	}

	/// <summary>
	/// アドベンチャー保存
	/// </summary>
	/// <param name="number">保存するデータの番号</param>
	public void AdvSave(int number)
	{
		GameInstance.saveData.advDatas[number] = advData;
	}
}