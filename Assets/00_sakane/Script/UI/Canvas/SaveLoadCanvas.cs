using System.Collections.Generic;
using UnityEngine;

// �ۑ��ǂݍ��݃L�����o�X
public class SaveLoadCanvas : CanvasBase
{
	// �ۑ��Ɠǂݍ��݂��s���{�^��
	[SerializeField]
	GameObject seveLoadButtonPrefab;
	List<GameObject> saveLoadButtons = new List<GameObject>();

	// �{�^���̐e�I�u�W�F�N�g
	[SerializeField]
	GameObject content;

	protected override void Start()
	{
		base.Start();
		// �{�^������
		for (int i = 0; i < SaveLoadManager.Instance.MaxSaveValue; ++i)
		{
			saveLoadButtons.Add(Instantiate(seveLoadButtonPrefab, content.transform));
		}
	}
}