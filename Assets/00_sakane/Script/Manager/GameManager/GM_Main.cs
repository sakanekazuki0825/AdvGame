using UnityEngine;

// ���C���̃Q�[���}�l�[�W���[
public sealed class GM_Main : GameManagerBase
{
	// ���C���̃L�����o�X
	[SerializeField]
	GameObject mainCanvasPrefab;
	GameObject mainCanvas;

	// �I�v�V�����L�����o�X
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	protected override void Start()
	{
		base.Start();
		// ���C���̃L�����o�X����
		mainCanvas = Instantiate(mainCanvasPrefab);
		// ���C���̃L�����o�X�\��
		mainCanvas.SetActive(true);
	}

	/// <summary>
	/// �A�h�x���`���[�X�L�b�v
	/// </summary>
	public void AdvSkip()
	{

	}
}