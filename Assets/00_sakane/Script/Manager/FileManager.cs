using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// ファイル管理クラス
public class FileManager : ManagerBase<FileManager>
{
	/// <summary>
	/// Jsonファイルから読み込み
	/// </summary>
	/// <param name="fileName">ファイル名</param>
	/// <returns>読み込んだデータ</returns>
	public static T LoadJson<T>(string fileName) where T : new()
	{
		// ファイルの有無を調べる
		if (!File.Exists(fileName))
		{
			Debug.Log("ファイルが存在しません");
			return new T();
		}
		// 読み込むファイルを開く
		StreamReader reader = new StreamReader(fileName);
		// 読み込み
		var jsondata = reader.ReadToEnd();
		// データをクラス化
		var data = JsonUtility.FromJson<T>(jsondata);
		// ファイル閉じる
		reader.Close();

		return data;
	}

	/// <summary>
	/// Jsonファイルに書き込み
	/// </summary>
	/// <param name="fileName">書き込みを行うファイル名</param>
	/// <param name="t">書き込むデータ</param>
	public static void WriteJson<T>(string fileName, T t)
	{
		// 保存するファイルを開く
		StreamWriter writer = new StreamWriter(fileName);

		// 保存するクラスをstringに変換
		var jsonStr = JsonUtility.ToJson(t);
		// Jsonに書き込み
		writer.Write(jsonStr);
		// バッファクリア
		writer.Flush();
		// ファイルを閉じる
		writer.Close();
	}

	/// <summary>
	/// CSVファイルから読み込み
	/// </summary>
	/// <param name="fileName">読み込みを行うファイル名</param>
	/// <returns>読み込んだデータ</returns>
	public static List<string> LoadCSV(string fileName)
	{
		// 読み込みを行ったデータ
		var datas = new List<string>();
		// ファイルが存在しない場合ログを出す
		if (!File.Exists(fileName))
		{
			Debug.Log("ファイルが存在しません");
			return datas;
		}
		// Resouces下のCSV読み込み
		var csvFile = File.ReadAllText(fileName);
		var reader = new StringReader(csvFile);
		// 行がなくなるまで一行ずつ読み込む
		while (reader.Peek() != -1)
		{
			// 一行読み込み
			var line = reader.ReadLine();
			// カンマ区切りでデータ読み込み
			var data = line.Split(",");
			// 読み込んだデータに保存
			foreach (var item in data)
			{
				datas.Add(item);
			}
		}

		return datas;
	}

	/// <summary>
	/// CSVに書き込み
	/// </summary>
	/// <param name="fileName">書き込みを行うファイル名</param>
	/// <param name="data">書き込むデータ</param>
	public static void WriteCSV(string fileName, List<string> datas)
	{

	}

	/// <summary>
	/// TSV読み込み
	/// </summary>
	/// <param name="fileName">ファイル名</param>
	/// <returns>読み込んだデータ</returns>
	public static List<string> LoadTSV(string fileName)
	{
		// 読み込んだデータ
		var datas = new List<string>();
		if (File.Exists(fileName))
		{
			Debug.Log("ファイルが存在しません");
			return datas;
		}
		// Resouces下のCSV読み込み
		var csvFile = Resources.Load(fileName) as TextAsset;
		var reader = new StringReader(csvFile.text);
		// 行がなくなるまで一行ずつ読み込む
		while (reader.Peek() != -1)
		{
			// 一行読み込み
			var line = reader.ReadLine();
			// タブ区切りでデータ読み込み
			var data = line.Split("	");
			// 読み込んだデータに保存
			foreach (var item in data)
			{
				datas.Add(item);
			}
		}

		return datas;
	}

	/// <summary>
	/// TSVに書き込み
	/// </summary>
	/// <param name="fileName">書き込みを行うファイル</param>
	/// <param name="data">書き込むデータ</param>
	public static void WriteTSV(string fileName, List<string> datas)
	{

	}
}