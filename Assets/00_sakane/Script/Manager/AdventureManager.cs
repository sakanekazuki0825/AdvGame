using System.Collections.Generic;
using UnityEngine;

// �A�h�x���`���[�Ǘ��N���X
public class AdventureManager : ManagerBase<AdventureManager>
{
	// �A�h�x���`���[
	[SerializeField]
	List<SO_Chapter> adventures = new List<SO_Chapter>();

	// �A�h�x���`���[�L�����o�X
	[SerializeField]
	GameObject adventureCanvasPrefab;
	GameObject adventureCanvas;
	IAdventureCanvas iAdventureCanvas;

	// �͂̔ԍ�
	int chapterNumber = 0;
	// �J�b�g�ԍ�
	int cutNumber = 0;

	private void Start()
	{
		// �A�h�x���`���[�L�����o�X����
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		// �A�h�x���`���[�L�����o�X�\��
		adventureCanvas.SetActive(true);
		// �A�h�x���`���[�̃C���^�t�F�C�X�擾
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		// �͂̔ԍ��ݒ�
		foreach (var v in adventures)
		{
			v.chapterNumber = adventures.IndexOf(v);
		}
	}

	/// <summary>
	/// ������
	/// </summary>
	void Initialize()
	{
		chapterNumber = 0;
		cutNumber = 0;
	}

	/// <summary>
	/// ���̃J�b�g
	/// </summary>
	public void NextCut()
	{
		// �ԍ���i�߂�
		++cutNumber;

		// �J�b�g���𒴂��Ă��Ȃ������ׂ�
		if (cutNumber >= adventures[chapterNumber].chapterCuts.Count)
		{
			NextChapter();
		}
		// �J�b�g�ύX
		iAdventureCanvas.CutChange(adventures[chapterNumber].chapterCuts[cutNumber]);
	}

	/// <summary>
	/// ���̏͂ɐi��
	/// </summary>
	public void NextChapter()
	{
		// �ԍ���i�߂�
		++chapterNumber;
		// �J�b�g��0����
		cutNumber = 0;
		// �`���v�^�[���������Ă��Ȃ������ׂ�
		if (chapterNumber >= adventures.Count)
		{
			// �Q�[���N���A
			Debug.Log("�Q�[���N���A");
			chapterNumber = 0;
			LevelManager.OpenLevel("TitleScene").Forget();
		}
		else
		{
			// �͂̏�Ԃ�ݒ�
			iAdventureCanvas.ChapterChange(adventures[chapterNumber].chapter);
		}
	}
}