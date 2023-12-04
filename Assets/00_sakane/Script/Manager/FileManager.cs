using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// �t�@�C���Ǘ��N���X
public class FileManager : ManagerBase<FileManager>
{
	/// <summary>
	/// Json�t�@�C������ǂݍ���
	/// </summary>
	/// <param name="fileName">�t�@�C����</param>
	/// <returns>�ǂݍ��񂾃f�[�^</returns>
	public static T LoadJson<T>(string fileName) where T : new()
	{
		// �t�@�C���̗L���𒲂ׂ�
		if (!File.Exists(fileName))
		{
			Debug.Log("�t�@�C�������݂��܂���");
			return new T();
		}
		// �ǂݍ��ރt�@�C�����J��
		StreamReader reader = new StreamReader(fileName);
		// �ǂݍ���
		var jsondata = reader.ReadToEnd();
		// �f�[�^���N���X��
		var data = JsonUtility.FromJson<T>(jsondata);
		// �t�@�C������
		reader.Close();

		return data;
	}

	/// <summary>
	/// Json�t�@�C���ɏ�������
	/// </summary>
	/// <param name="fileName">�������݂��s���t�@�C����</param>
	/// <param name="t">�������ރf�[�^</param>
	public static void WriteJson<T>(string fileName, T t)
	{
		// �ۑ�����t�@�C�����J��
		StreamWriter writer = new StreamWriter(fileName);

		// �ۑ�����N���X��string�ɕϊ�
		var jsonStr = JsonUtility.ToJson(t);
		// Json�ɏ�������
		writer.Write(jsonStr);
		// �o�b�t�@�N���A
		writer.Flush();
		// �t�@�C�������
		writer.Close();
	}

	/// <summary>
	/// CSV�t�@�C������ǂݍ���
	/// </summary>
	/// <param name="fileName">�ǂݍ��݂��s���t�@�C����</param>
	/// <returns>�ǂݍ��񂾃f�[�^</returns>
	public static List<string> LoadCSV(string fileName)
	{
		// �ǂݍ��݂��s�����f�[�^
		var datas = new List<string>();
		// �t�@�C�������݂��Ȃ��ꍇ���O���o��
		if (!File.Exists(fileName))
		{
			Debug.Log("�t�@�C�������݂��܂���");
			return datas;
		}
		// Resouces����CSV�ǂݍ���
		var csvFile = File.ReadAllText(fileName);
		var reader = new StringReader(csvFile);
		// �s���Ȃ��Ȃ�܂ň�s���ǂݍ���
		while (reader.Peek() != -1)
		{
			// ��s�ǂݍ���
			var line = reader.ReadLine();
			// �J���}��؂�Ńf�[�^�ǂݍ���
			var data = line.Split(",");
			// �ǂݍ��񂾃f�[�^�ɕۑ�
			foreach (var item in data)
			{
				datas.Add(item);
			}
		}

		return datas;
	}

	/// <summary>
	/// CSV�ɏ�������
	/// </summary>
	/// <param name="fileName">�������݂��s���t�@�C����</param>
	/// <param name="data">�������ރf�[�^</param>
	public static void WriteCSV(string fileName, List<string> datas)
	{

	}

	/// <summary>
	/// TSV�ǂݍ���
	/// </summary>
	/// <param name="fileName">�t�@�C����</param>
	/// <returns>�ǂݍ��񂾃f�[�^</returns>
	public static List<string> LoadTSV(string fileName)
	{
		// �ǂݍ��񂾃f�[�^
		var datas = new List<string>();
		if (File.Exists(fileName))
		{
			Debug.Log("�t�@�C�������݂��܂���");
			return datas;
		}
		// Resouces����CSV�ǂݍ���
		var csvFile = Resources.Load(fileName) as TextAsset;
		var reader = new StringReader(csvFile.text);
		// �s���Ȃ��Ȃ�܂ň�s���ǂݍ���
		while (reader.Peek() != -1)
		{
			// ��s�ǂݍ���
			var line = reader.ReadLine();
			// �^�u��؂�Ńf�[�^�ǂݍ���
			var data = line.Split("	");
			// �ǂݍ��񂾃f�[�^�ɕۑ�
			foreach (var item in data)
			{
				datas.Add(item);
			}
		}

		return datas;
	}

	/// <summary>
	/// TSV�ɏ�������
	/// </summary>
	/// <param name="fileName">�������݂��s���t�@�C��</param>
	/// <param name="data">�������ރf�[�^</param>
	public static void WriteTSV(string fileName, List<string> datas)
	{

	}
}