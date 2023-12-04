using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �^�C�g���}�l�[�W���[
public class GM_Title : GameManagerBase
{
	// �^�C�g���L�����o�X
	[SerializeField]
	GameObject titleCanvasPrefab;
	GameObject titleCanvas;

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
	}

	/// <summary>
	/// �Q�[���J�n
	/// </summary>
	public void GameStart()
	{

	}

	/// <summary>
	/// �N���W�b�g
	/// </summary>
	public void Credit()
	{

	}

	/// <summary>
	/// �Q�[���I��
	/// </summary>
	public void Quit()
	{
		LevelManager.GameQuit();
	}
}