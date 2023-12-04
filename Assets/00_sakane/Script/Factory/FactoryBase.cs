using UnityEngine;

// ��������N���X�̃x�[�X
public abstract class FactoryBase<T> : Singleton<T> where T : Singleton<T>
{
	// ��������I�u�W�F�N�g
	[SerializeField]
	GameObject prefab;

	/// <summary>
	/// �I�u�W�F�N�g����
	/// </summary>
	/// <param name="position">�����ʒu</param>
	/// <returns>���������I�u�W�F�N�g</returns>
	public GameObject Create(Vector3 position)
	{
		return GameObject.Instantiate(prefab, position, Quaternion.identity);
	}
}