using System.Collections.Generic;
using UnityEngine;

// �I������\������L�����o�X
public class ChoicesCanvas : CanvasBase
{
	// �I�����̃{�^���̐�
	int selectBtnValue = 0;

	// �I�����{�^���v���n�u
	[SerializeField]
	GameObject selectBtnPrefab;

	// �I������\������{�^��
	[SerializeField]
	List<GameObject> selectBtns = new List<GameObject>();

	// �{�^���̐e�I�u�W�F�N�g
	[SerializeField]
	GameObject content;

	// �{�^���p�̃e�L�X�g
	[SerializeField]
	List<string> buttonText = new List<string>();

	/// <summary>
	/// ������
	/// </summary>
	public void Initialize()
	{
		foreach (var v in buttonText)
		{
			// �{�^������
			var button = Instantiate(selectBtnPrefab, content.transform);
			// �{�^���o�^
			selectBtns.Add(button);
			// �{�^��������
			button.GetComponent<SelectButton>().Initialized(v);
			// �{�^���̐��ǉ�
			++selectBtnValue;
		}
	}
}
