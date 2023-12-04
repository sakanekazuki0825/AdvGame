using System;
using System.Collections.Generic;
using UnityEngine;

// アドベンチャーのベース
[Serializable]
public class AdventureBase
{
	// アドベンチャーの番号
	public int adventureNumber = 0;

	// 背景画像
	public Sprite backGroundSprite;

	// キャラクター画像
	public List<Sprite> characters = new List<Sprite>();

	// 表示するテキスト
	public List<string> messagese = new List<string>();

	// true = イベント
	//public bool isEvent = false;
}