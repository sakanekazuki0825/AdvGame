using System;
using System.Collections.Generic;
using UnityEngine;

// �A�h�x���`���[�̃x�[�X
[Serializable]
public class AdventureBase
{
	// �A�h�x���`���[�̔ԍ�
	public int adventureNumber = 0;

	// �w�i�摜
	public Sprite backGroundSprite;

	// �L�����N�^�[�摜
	public List<Sprite> characters = new List<Sprite>();

	// �\������e�L�X�g
	public List<string> messagese = new List<string>();

	// true = �C�x���g
	//public bool isEvent = false;
}