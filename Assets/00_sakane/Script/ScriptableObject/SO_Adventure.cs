using System.Collections.Generic;
using UnityEngine;

// �A�h�x���`���[�̃X�N���v�^�u���I�u�W�F�N�g
[CreateAssetMenu(fileName = "Adv", menuName = "ScriptableObject/Adv")]
public class SO_Adventure : ScriptableObject
{
	// �A�h�x���`���[�f�[�^
	public List<AdventureBase> adv = new List<AdventureBase>();
}