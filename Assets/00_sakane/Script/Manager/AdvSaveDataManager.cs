using System.Collections.Generic;
using System.IO;
using UnityEngine;

// アドベンチャーのセーブデータ管理クラス
public sealed class AdvSaveDataManager : ManagerBase<AdvSaveDataManager>
{
	// アドベンチャーのファイルパス
	static string folderPath = "";

	// ファイルの拡張子
	static string extension = ".advdata.json";

	// 保存する名前
	static List<string> saveDataNames = new List<string>();

	// アドベンチャーの保存データ
	static List<AdvSaveData> advSaveDatas = new List<AdvSaveData>();

	/// <summary>
	/// アドベンチャーのデータ読み込み
	/// </summary>
	public static void AdvDataLoad()
	{
		// フォルダ内にあるファイル名全て取得
		var fileNames = Directory.GetFiles(folderPath, "*" + extension, SearchOption.AllDirectories);

		// 全てのセーブデータ取得
		foreach (var fileName in fileNames)
		{
			// 読み込んだデータ保存
			advSaveDatas.Add(FileManager.LoadJson<AdvSaveData>(fileName));
			// 保存する名前設定
			saveDataNames.Add(fileName);
		}
	}

	/// <summary>
	/// アドベンチャーのデータ保存
	/// </summary>
	public void AdvDataSave()
	{
		// 全てのデータを書き込み
		foreach (var data in advSaveDatas)
		{
			FileManager.WriteJson(saveDataNames[advSaveDatas.IndexOf(data)], data);
		}
	}
}