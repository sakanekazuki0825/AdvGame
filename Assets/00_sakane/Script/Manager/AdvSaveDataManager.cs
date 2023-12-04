using System.Collections.Generic;
using System.IO;
using UnityEngine;

// �A�h�x���`���[�̃Z�[�u�f�[�^�Ǘ��N���X
public sealed class AdvSaveDataManager : ManagerBase<AdvSaveDataManager>
{
	// �A�h�x���`���[�̃t�@�C���p�X
	static string folderPath = "";

	// �t�@�C���̊g���q
	static string extension = ".advdata.json";

	// �ۑ����閼�O
	static List<string> saveDataNames = new List<string>();

	// �A�h�x���`���[�̕ۑ��f�[�^
	static List<AdvSaveData> advSaveDatas = new List<AdvSaveData>();

	/// <summary>
	/// �A�h�x���`���[�̃f�[�^�ǂݍ���
	/// </summary>
	public static void AdvDataLoad()
	{
		// �t�H���_���ɂ���t�@�C�����S�Ď擾
		var fileNames = Directory.GetFiles(folderPath, "*" + extension, SearchOption.AllDirectories);

		// �S�ẴZ�[�u�f�[�^�擾
		foreach (var fileName in fileNames)
		{
			// �ǂݍ��񂾃f�[�^�ۑ�
			advSaveDatas.Add(FileManager.LoadJson<AdvSaveData>(fileName));
			// �ۑ����閼�O�ݒ�
			saveDataNames.Add(fileName);
		}
	}

	/// <summary>
	/// �A�h�x���`���[�̃f�[�^�ۑ�
	/// </summary>
	public void AdvDataSave()
	{
		// �S�Ẵf�[�^����������
		foreach (var data in advSaveDatas)
		{
			FileManager.WriteJson(saveDataNames[advSaveDatas.IndexOf(data)], data);
		}
	}
}