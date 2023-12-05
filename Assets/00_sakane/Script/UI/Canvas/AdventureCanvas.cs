using UnityEngine;
using UnityEngine.UI;
using TMPro;

// �A�h�x���`���[�L�����o�X
public class AdventureCanvas : CanvasBase, IAdventureCanvas
{
	// �w�i�摜
	[SerializeField]
	Image backGroundImg;

	// �L�����N�^�[
	[SerializeField]
	Image characterImg;
	Animator characterAnimator;

	// �Z���t�Ȃǂ̃e�L�X�g
	[SerializeField]
	TextMeshProUGUI messageTxt;

	protected override void Start()
	{
		base.Start();
		// �L�����N�^�[�̃A�j���[�^�[�擾
		characterAnimator = characterImg.GetComponent<Animator>();
	}

	/// <summary>
	/// �`���v�^�[�ύX
	/// </summary>
	/// <param name="chapter">�͂̏��</param>
	public void ChapterChange(Chapter chapter)
	{
		// �w�i�ݒ�
		backGroundImg.sprite = chapter.backGround;
		// �L�����N�^�[�摜�ݒ�
		characterImg.sprite = chapter.characterSprite;
		// �A�j���[�^�[�R���g���[���[�ݒ�
		characterAnimator.runtimeAnimatorController = chapter.characterAnimatorController;
	}

	/// <summary>
	/// �J�b�g�ύX
	/// </summary>
	/// <param name="cut">�J�b�g</param>
	public void CutChange(OneCut cut)
	{
		// �e�L�X�g�ݒ�
		messageTxt.text = cut.message;
		// �I�����̕\�����K�v�����ׂ�
		if (cut.isChoice)
		{

		}
		// �p�����[�^�[��S�Ď擾
		var animParams = characterAnimator.parameters;
		foreach (var param in animParams)
		{
			// �������O�̃v���p�e�B������ꍇ�A�j���[�V������ύX
			if (param.name == cut.cutNumber.ToString())
			{
				characterAnimator.SetTrigger(cut.cutNumber.ToString());
			}
		}
	}
}