// 保存読み込み管理クラス
using UnityEngine;

public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// 保存できる最大数
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	// 保存するファイル名
	public static string fileName;

	private void Awake()
	{
		fileName = Application.persistentDataPath + "/saveData.json";
	}

	private void OnApplicationQuit()
	{
		// 保存する
		FileManager.WriteJson(fileName, GameInstance.saveData);
	}
}