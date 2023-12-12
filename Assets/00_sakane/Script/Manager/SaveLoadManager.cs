// �ۑ��ǂݍ��݊Ǘ��N���X
using UnityEngine;

public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// �ۑ��ł���ő吔
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	// �ۑ�����t�@�C����
	public static string fileName;

	private void Awake()
	{
		fileName = Application.persistentDataPath + "/saveData.json";
	}

	private void OnApplicationQuit()
	{
		// �ۑ�����
		FileManager.WriteJson(fileName, GameInstance.saveData);
	}
}