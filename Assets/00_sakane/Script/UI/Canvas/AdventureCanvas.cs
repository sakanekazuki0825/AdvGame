using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

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
	GameObject messageTxt;
	IAdvText iadvText;

	protected override void Start()
	{
		base.Start();
		// �L�����N�^�[�̃A�j���[�^�[�擾
		characterAnimator = characterImg.GetComponent<Animator>();

		iadvText = messageTxt.GetComponent<IAdvText>();
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
	public async UniTask CutChange(OneCut cut)
	{
		var token = this.GetCancellationTokenOnDestroy();
		if (iadvText.IsCharacterFeeding())
		{
			iadvText.AllMessageDisplay();
			return;
		}
		await cut.CutBeforeEvent(token);
		// �e�L�X�g�ݒ�
		iadvText.SetMessageTxt(cut.message);
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

		await cut.CurAfterEvent(token);
	}
}