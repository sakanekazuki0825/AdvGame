using UnityEngine;

// �v���C���[�����ʒu
public class PlayerStarter : MonoBehaviour
{
	private void Awake()
	{
		// �Q�[���}�l�[�W���[�̐����ʒu�ɂ��̃I�u�W�F�N�g��ǉ�
		GameManagerBase.Instance.AddStarter(gameObject);
	}
}