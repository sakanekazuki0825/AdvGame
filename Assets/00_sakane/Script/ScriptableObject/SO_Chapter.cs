using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

// �A�h�x���`���[�̃X�N���v�^�u���I�u�W�F�N�g
[CreateAssetMenu(fileName = "chapter", menuName = "ScriptableObject/Chapter")]
public class SO_Chapter : ScriptableObject
{
	// �͂̔ԍ�
	public int chapterNumber = 0;
	// �`���v�^�[
	public Chapter chapter = new Chapter();
	// �A�h�x���`���[�f�[�^
	public List<OneCut> chapterCuts = new List<OneCut>();

	[ContextMenu("�J�b�g�ԍ��ݒ�")]
	public void SetCutNumber()
	{
		foreach (var v in chapterCuts)
		{
			// �ԍ��ݒ�
			v.cutNumber = chapterCuts.IndexOf(v);
		}
	}

	[ContextMenu("�����o��")]
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
	/// �͂̃f�[�^�ǂݍ���
	/// </summary>
	[ContextMenu("�ǂݍ���")]
	public void LoadChapterData()
	{
		var fileName = EditorUtility.OpenFilePanel("CSVLoad", "", "");
		var chapterData = FileManager.LoadTSV(fileName);
		// �͂̔ԍ��ݒ�
		chapterNumber = int.Parse(chapterData[0]);
		// �w�i�ݒ�
		chapter.backGround = Resources.Load<Sprite>(chapterData[1]);
		// �L�����N�^�[�摜�ݒ�
		chapter.characterSprite = Resources.Load<Sprite>(chapterData[2]);
		// �A�j���[�^�[�ݒ�
		chapter.characterAnimatorController = Resources.Load<AnimatorController>(chapterData[3]);

		// �J�b�g�폜
		chapterCuts.Clear();
		// �J�b�g�쐬
		chapterCuts = new List<OneCut>();

		for (int i = 4; i < chapterData.Count; ++i)
		{
			var cut = new OneCut();
			// �J�b�g�ԍ��ݒ�
			cut.cutNumber = int.Parse(chapterData[i]);
			++i;
			// �Z���t�ݒ�
			cut.message = chapterData[i];
			++i;
			// �I�����\���t���O�ݒ�
			cut.isChoice = bool.Parse(chapterData[i]);
			// �J�b�g�̏��ݒ�
			chapterCuts.Add(cut);
		}
	}
}