using System.Collections.Generic;
using UnityEngine;

// �Q�[���}�l�[�W���[�̃x�[�X
public abstract class GameManagerBase : ManagerBase<GameManagerBase>
{
	// ��������I�u�W�F�N�g
	[SerializeField]
	protected GameObject defaultPlayerObjectPrefab;

	// �v���C���[�𐶐�����ʒu
	protected List<GameObject> playerStarter = new List<GameObject>();

	// ���������L�����N�^�[
	public GameObject character
	{
		get;
		private set;
	}

	protected virtual void Start()
	{
		// �v���C���[�X�^�[�^�[�����ꍇ�G���[
		if (playerStarter.Count == 0)
		{
			//Debug.LogError("�v���C���[�X�^�[�^�[������܂���");
		}
		foreach (var starter in playerStarter)
		{
			// �v���C���[����
			character = Instantiate(defaultPlayerObjectPrefab, starter.transform.position, Quaternion.identity);
		}
	}

	/// <summary>
	/// �v���C���[�X�^�[�g�ǉ�
	/// </summary>
	/// <param name="starter">�v���C���[�X�^�[�g�̈ʒu�ɑ��݂���I�u�W�F�N�g</param>
	public void AddStarter(GameObject starter)
	{
		playerStarter.Add(starter);
	}
}