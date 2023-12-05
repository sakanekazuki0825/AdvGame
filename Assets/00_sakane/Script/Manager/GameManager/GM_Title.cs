using UnityEngine;

// �^�C�g���}�l�[�W���[
public sealed class GM_Title : GameManagerBase
{
	// �^�C�g���L�����o�X
	[SerializeField]
	GameObject titleCanvasPrefab;
	GameObject titleCanvas;

	// �I�v�V����
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	// �N���W�b�g
	[SerializeField]
	GameObject creditCanvasPrefab;
	GameObject creditCanvas;

	protected override void Start()
	{
		base.Start();
		// �L�����o�X����
		titleCanvas = Instantiate(titleCanvasPrefab);
		// �^�C�g���L�����o�X�\��
		titleCanvas.SetActive(true);

		// �N���W�b�g�L�����o�X����
		creditCanvas = Instantiate(creditCanvasPrefab);
		// �N���W�b�g�L�����o�X��\��
		creditCanvas.SetActive(false);

		// �I�v�V�����L�����o�X����
		optionCanvas = Instantiate(optionCanvasPrefab);
		// �I�v�V�����L�����o�X��\��
		optionCanvas.SetActive(false);
	}

	/// <summary>
	/// �Q�[���J�n
	/// </summary>
	public void GameStart()
	{
		LevelManager.OpenLevel("MainScene").Forget();
	}

	/// <summary>
	/// �N���W�b�g
	/// </summary>
	public void Credit()
	{
		creditCanvas.SetActive(true);
	}

	/// <summary>
	/// �Q�[���I��
	/// </summary>
	public void Quit()
	{
		LevelManager.GameQuit();
	}
}