using UnityEngine;

// �I�v�V�����Ǘ��N���X
public class OptionManager : ManagerBase<OptionManager>
{
	// �I�v�V�����L�����o�X
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	private void Start()
	{
		// �I�v�V�����L�����o�X����
		optionCanvas = Instantiate(optionCanvasPrefab);
		// �I�v�V�����L�����o�X��\��
		OptionClose();
	}

	/// <summary>
	/// �I�v�V�����L�����o�X�\��
	/// </summary>
	public void OptionOpen()
	{
		optionCanvas.SetActive(true);
	}

	/// <summary>
	/// �I�v�V�����L�����o�X��\��
	/// </summary>
	public void OptionClose()
	{
		optionCanvas.SetActive(false);
	}
}