using System;
using UnityEngine;
using UnityEditor.Animations;

// チャプター
[Serializable]
public class Chapter
{
	// 背景画像
	public Sprite backGround = null;
	// キャラクター画像
	public Sprite characterSprite = null;
	// キャラクターのアニメーター
	public AnimatorController characterAnimatorController;
}
