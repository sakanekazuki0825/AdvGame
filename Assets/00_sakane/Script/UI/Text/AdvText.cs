using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

// �A�h�x���`���[�̃e�L�X�g
public class AdvText : MonoBehaviour,IAdvText
{
	// �Z���t�Ȃǂ�\������e�L�X�g
	TextMeshProUGUI messageTxt;

	// true = �������蒆
	bool isCharacterFeeding = false;

	private void Start()
	{
		// �e�L�X�g�擾
		messageTxt = GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// �e�L�X�g��ݒ�
	/// </summary>
	/// <param name="message"></param>
	public void SetMessageTxt(string message)
	{
		// �e�L�X�g�ݒ�
		messageTxt.text = message;
		// �L�����Z���[�V�����g�[�N���擾
		var token = this.GetCancellationTokenOnDestroy();
		// ��������J�n
		CharacterFeed(token).Forget();
	}

	/// <summary>
	/// ��������
	/// </summary>
	/// <param name="token">�L�����Z���[�V�����g�[�N��</param>
	/// <returns></returns>
	async UniTask CharacterFeed(CancellationToken token)
	{
		// �������蒆
		isCharacterFeeding = true;
		// ������\�����Ȃ�
		messageTxt.maxVisibleCharacters = 0;
		while (messageTxt.maxVisibleCharacters < messageTxt.text.Length && isCharacterFeeding)
		{
			// ��������̑��x�҂�
			await UniTask.WaitForSeconds(GameInstance.saveData.characterFeedSpeed);
			// �ꕶ���ǉ�
			++messageTxt.maxVisibleCharacters;
		}
		// ��������I��
		isCharacterFeeding = false;
	}

	/// <summary>
	/// ����������I�����đS�Ẵe�L�X�g��\������
	/// </summary>
	public void AllMessageDisplay()
	{
		messageTxt.maxVisibleCharacters = messageTxt.text.Length;
		isCharacterFeeding = false;
	}

	/// <summary>
	/// ��������̏�Ԏ擾
	/// </summary>
	/// <returns></returns>
	public bool IsCharacterFeeding()
	{
		return isCharacterFeeding;
	}
}