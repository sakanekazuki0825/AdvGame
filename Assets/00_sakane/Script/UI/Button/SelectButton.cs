using UnityEngine;
using UnityEngine.UI;

// �I���{�^��
public class SelectButton : MonoBehaviour
{
	// �{�^���̃e�L�X�g
	Text text;

	private void Start()
	{
		// �e�L�X�g�擾
		text = GetComponentInChildren<Text>();
	}

	/// <summary>
	/// ������
	/// </summary>
	/// <param name="message">�e�L�X�g�ɕ\�����镶��</param>
	public void Initialized(string message)
	{
		// ������ݒ�
		text.text = message;
	}
}