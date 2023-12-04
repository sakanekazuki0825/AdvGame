using UnityEngine;
using TMPro;
using System.Collections;

// �e�L�X�g�Ǘ��N���X
public class MainMessageText : Singleton<MainMessageText>
{
	// ������\������e�L�X�g
	[SerializeField]
	TextMeshProUGUI text;

	// ���̕�����\������܂ł̎���
	[SerializeField]
	float nextLetterTime = 0;

	// �������肪�I�������ɕ\���������
	[SerializeField]
	GameObject arrow;

	// true = ��������I��
	bool isFinish = false;
	public bool IsFinish
	{
		get => isFinish;
	}

	private void Start()
	{
		arrow?.SetActive(false);
	}

	/// <summary>
	/// �����̕\��
	/// </summary>
	/// <param name="message">�\�����镶��</param>
	public void TextDisplay(string message)
	{
		text.text = message;
		StartCoroutine(CharacterFeedJP());
	}

	/// <summary>
	/// �S�Ă̕����\��
	/// </summary>
	public void CharacterFeedSkip()
	{
		// ������S�ĕ\������
		text.maxVisibleCharacters = text.text.Length;
	}

	/// <summary>
	/// ��������
	/// </summary>
	/// <returns></returns>
	IEnumerator CharacterFeedJP()
	{
		// ����\��
		arrow?.SetActive(false);
		// �������蒆
		isFinish = false;

		// �ꕶ���ڂ͍ŏ�����\��
		text.maxVisibleCharacters = 1;
		// �������Ō�܂ŕ\������
		while (text.text.Length > text.maxVisibleCharacters)
		{
			// ���̕�����\������܂ő҂�
			yield return new WaitForSeconds(nextLetterTime);
			// ��������
			++text.maxVisibleCharacters;
		}

		// ���\��
		arrow?.SetActive(true);

		// ��������I��
		isFinish = true;

		yield break;
	}
}