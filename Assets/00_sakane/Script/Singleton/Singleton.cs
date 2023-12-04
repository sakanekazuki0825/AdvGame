using System;
using UnityEngine;

// �V���O���g��
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// �C���X�^���X
	static T instance;
	// �C���X�^���X�擾
	public static T Instance
	{
		get
		{
			// null�Ȃ琶��
			if (instance == null)
			{
				Type t = typeof(T);
				instance = (T)FindObjectOfType(t);
				// �����Ɏ��s������null��Ԃ�
				if(instance == null )
				{
					Debug.LogError("�I�u�W�F�N�g�����݂��܂���");
					return null;
				}
			}
			// �C���X�^���X��Ԃ�
			return instance;
		}
	}

	// �R���X�g���N�^
	void Awake()
	{
		instance = this as T;
	}

	private void OnDestroy()
	{
		instance = null;
	}

	protected virtual void Update()
	{
		
	}
}