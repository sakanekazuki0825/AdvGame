using UnityEngine;

// �A�h�x���`���[�Ǘ��N���X
public sealed class AdventureManager : ManagerBase<AdventureManager>
{
	// �A�h�x���`���[�̃L�����o�X
	[SerializeField]
	GameObject adventureCanvasPrefab;
	GameObject adventureCanvas;

	// �A�h�x���`���[�L�����o�X�̃C���^�[�t�F�[�X
	IAdventureCanvas iAdventureCanvas;

	// �\�����Ă���A�h�x���`���[�̔ԍ�
	int adventureNumber = 0;
	// �\�����Ă��郁�b�Z�[�W�̔ԍ�
	int messageNumber = 0;

	// �A�h�x���`���[
	[SerializeField]
	SO_Adventure so_adventure;

	private void Start()
	{
		// �A�h�x���`���[�p�̃L�����o�X����
		adventureCanvas = Instantiate(adventureCanvasPrefab);
		adventureCanvas.SetActive(true);
		iAdventureCanvas = adventureCanvas.GetComponent<IAdventureCanvas>();
		iAdventureCanvas.SetAdventure(so_adventure.adv[adventureNumber]);
	}

	/// <summary>
	/// ���̃A�h�x���`���[�ɐi��
	/// </summary>
	public void NextAdventure()
	{
		++adventureNumber;
	}

	/// <summary>
	/// ���̃��b�Z�[�W��
	/// </summary>
	public void NextMessage()
	{
		if (MainMessageText.Instance.IsFinish)
		{
			// ���b�Z�[�W�̔ԍ�
			++messageNumber;
			if (so_adventure.adv[adventureNumber].messagese.Count > messageNumber)
			{
				// �e�L�X�g���X�V
				MainMessageText.Instance.TextDisplay(so_adventure.adv[adventureNumber].messagese[messageNumber]);
			}
			else
			{
				// ���b�Z�[�W�̔ԍ����Z�b�g
				messageNumber = 0;
				// ���̃A�h�x���`���[�ɐi��
				NextAdventure();
				// �A�h�x���`���[��ݒ�
				iAdventureCanvas.SetAdventure(so_adventure.adv[adventureNumber]);
			}
		}
		else
		{
			// ����������΂��đS�Ă̕�����\������
			MainMessageText.Instance.CharacterFeedSkip();
		}
	}

	/// <summary>
	/// �A�h�x���`���[�ǂݍ���
	/// </summary>
	public void AdventureLoad()
	{
		// �A�h�x���`���[���N���A
		so_adventure.adv.Clear();
		// �A�h�x���`���[��CSV����ǂݍ��ށH
	}
}