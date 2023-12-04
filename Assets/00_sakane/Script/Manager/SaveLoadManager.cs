using System.IO;
using UnityEngine;

// �ۑ��ǂݍ��݊Ǘ��N���X
public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// �ۑ��ł���ő吔
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	// �ۑ��ǂݍ��݃L�����o�X
	[SerializeField]
	GameObject saveLoadCanvasPrefab;
	GameObject saveLoadCanvas;

	private void Start()
	{
		// �ۑ��ǂݍ��݃L�����o�X����
		saveLoadCanvas = Instantiate(saveLoadCanvasPrefab);
		// �ۑ��ǂݍ��݃L�����o�X��\��
		saveLoadCanvas.SetActive(false);
	}

	/// <summary>
	/// �ۑ��ǂݍ��݃L�����o�X���J��
	/// </summary>
	public void SaveLoadCanvasOpen()
	{
		saveLoadCanvas.SetActive(true);
	}
}