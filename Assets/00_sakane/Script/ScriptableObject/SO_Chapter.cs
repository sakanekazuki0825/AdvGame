using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

// アドベンチャーのスクリプタブルオブジェクト
[CreateAssetMenu(fileName = "chapter", menuName = "ScriptableObject/Chapter")]
public class SO_Chapter : ScriptableObject
{
	// 章の番号
	public int chapterNumber = 0;
	// チャプター
	public Chapter chapter = new Chapter();
	// アドベンチャーデータ
	public List<OneCut> chapterCuts = new List<OneCut>();

	[ContextMenu("カット番号設定")]
	public void SetCutNumber()
	{
		foreach (var v in chapterCuts)
		{
			// 番号設定
			v.cutNumber = chapterCuts.IndexOf(v);
		}
	}

	[ContextMenu("書き出し")]
	public void WriteChapterData()
	{
		var fileName = EditorUtility.OpenFilePanel("CSVLoad", "", "");
		var data = "";
		data += chapterNumber.ToString();
		data += "	";
		data += chapter.backGround.name;
		data += "	";
		data += chapter.characterSprite.name;
		data += "	";
		data += chapter.characterAnimatorController.name;
		data += "	";
		foreach (var v in chapterCuts)
		{
			data += v.cutNumber.ToString();
			data += "	";
			data += v.message;
			data += "	";
			data += v.isChoice.ToString();
			if(chapterCuts.Count - 1 <= chapterCuts.IndexOf(v))
			{

			}
			else
			{
				data += "	";
			}
		}
		FileManager.WriteTSV(fileName, data);
	}

	/// <summary>
	/// 章のデータ読み込み
	/// </summary>
	[ContextMenu("読み込み")]
	public void LoadChapterData()
	{
		var fileName = EditorUtility.OpenFilePanel("CSVLoad", "", "");
		var chapterData = FileManager.LoadTSV(fileName);
		// 章の番号設定
		chapterNumber = int.Parse(chapterData[0]);
		// 背景設定
		chapter.backGround = Resources.Load<Sprite>(chapterData[1]);
		// キャラクター画像設定
		chapter.characterSprite = Resources.Load<Sprite>(chapterData[2]);
		// アニメーター設定
		chapter.characterAnimatorController = Resources.Load<AnimatorController>(chapterData[3]);

		// カット削除
		chapterCuts.Clear();
		// カット作成
		chapterCuts = new List<OneCut>();

		for (int i = 4; i < chapterData.Count; ++i)
		{
			var cut = new OneCut();
			// カット番号設定
			cut.cutNumber = int.Parse(chapterData[i]);
			++i;
			// セリフ設定
			cut.message = chapterData[i];
			++i;
			// 選択肢表示フラグ設定
			cut.isChoice = bool.Parse(chapterData[i]);
			// カットの情報設定
			chapterCuts.Add(cut);
		}
	}
}