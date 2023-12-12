using Cysharp.Threading.Tasks;
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

	// ���݂̃f�[�^
	AdvData advData = new AdvData();

	private void Start()
	{
		// �A�h�x���`���[�L�����o�X����
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		// �A�h�x���`���[�L�����o�X�\��
		adventureCanvas.SetActive(true);
		// �A�h�x���`���[�̃C���^�t�F�C�X�擾
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		//// �͂̔ԍ��ݒ�
		//foreach (var v in adventures)
		//{
		//	v.chapterNumber = adventures.IndexOf(v);
		//}
	}

	/// <summary>
	/// ������
	/// </summary>
	void Initialize()
	{
		
	}

	/// <summary>
	/// ���̃J�b�g
	/// </summary>
	public void NextCut()
	{
		// �ԍ���i�߂�
		++advData.cutNumber;

		// �J�b�g���𒴂��Ă��Ȃ������ׂ�
		if (advData.cutNumber >= adventures[advData.chapterNumber].chapterCuts.Count)
		{
			NextChapter();
		}
		// �J�b�g�ύX
		iAdventureCanvas.CutChange(adventures[advData.chapterNumber].chapterCuts[advData.cutNumber]).Forget();
	}

	/// <summary>
	/// ���̏͂ɐi��
	/// </summary>
	public void NextChapter()
	{
		// �ԍ���i�߂�
		++advData.chapterNumber;
		// �J�b�g��0����
		advData.cutNumber = 0;
		// �`���v�^�[���������Ă��Ȃ������ׂ�
		if (advData.chapterNumber >= adventures.Count)
		{
			// �Q�[���N���A
			Debug.Log("�Q�[���N���A");
			advData.chapterNumber = 0;
			LevelManager.OpenLevel("TitleScene").Forget();
		}
		else
		{
			// �͂̏�Ԃ�ݒ�
			iAdventureCanvas.ChapterChange(adventures[advData.chapterNumber].chapter);
		}
	}

	/// <summary>
	/// �A�h�x���`���[�ۑ�
	/// </summary>
	/// <param name="number">�ۑ�����f�[�^�̔ԍ�</param>
	public void AdvSave(int number)
	{
		GameInstance.saveData.advDatas[number] = advData;
	}
}