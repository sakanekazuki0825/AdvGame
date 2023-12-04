using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

// �t�F�[�h�Ǘ��N���X
public class FadeManager : ManagerBase<FadeManager>
{
	// true = �t�F�[�h��
	public bool IsFading
	{
		get;
		private set;
	}

	// �t�F�[�h�L�����o�X�̃v���n�u
	[SerializeField]
	GameObject fadeCanvasPrefab;
	GameObject fadeCanvas;
	IFadeCanvas iFadeCanvas;

	private void Start()
	{
		// �t�F�[�h���Ă��Ȃ�
		IsFading = false;
		// �L�����o�X����
		fadeCanvas = Instantiate(fadeCanvasPrefab);
		// �t�F�[�h�L�����o�X��\��
		fadeCanvas.SetActive(false);
		// �t�F�[�h���s���L�����o�X�̃C���^�[�t�F�C�X�擾
		iFadeCanvas = fadeCanvas.GetComponent<IFadeCanvas>();
	}

	/// <summary>
	/// �t�F�[�h�C��
	/// </summary>
	public void FadeIn()
	{
		// �L�����Z���[�V�����g�[�N���擾
		var token = this.GetCancellationTokenOnDestroy();
		// �t�F�[�h�J�n
		FadeInAsync(token).Forget();
	}

	/// <summary>
	/// �t�F�[�h�A�E�g
	/// </summary>
	public void FadeOut()
	{
		// �L�����Z���[�V�����g�[�N���擾
		var token = this.GetCancellationTokenOnDestroy();
		// �t�F�[�h�J�n
		FadeOutAsync(token).Forget();
	}

	/// <summary>
	/// �񓯊��t�F�[�h�C��
	/// </summary>
	/// <param name="token">�L�����Z���[�V�����g�[�N��</param>
	/// <returns></returns>
	async UniTask FadeInAsync(CancellationToken token)
	{
		// �t�F�[�h���ɂ���
		IsFading = true;
		// �t�F�[�h�I����҂�
		await UniTask.DelayFrame(1, cancellationToken: token);
		// �t�F�[�h�I����Ԃɂ���
		IsFading = false;
	}

	/// <summary>
	/// �񓯊��t�F�[�h�A�E�g
	/// </summary>
	/// <param name="token">�L�����Z���[�V�����g�[�N��</param>
	/// <returns></returns>
	async UniTask FadeOutAsync(CancellationToken token)
	{
		// �t�F�[�h���ɂ���
		IsFading = true;
		// �t�F�[�h�I����҂�
		await UniTask.DelayFrame(1, cancellationToken: token);
		// �t�F�[�h�I����Ԃɂ���
		IsFading = false;
	}
}