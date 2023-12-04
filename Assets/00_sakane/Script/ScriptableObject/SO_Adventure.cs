using System.Collections.Generic;
using UnityEngine;

// アドベンチャーのスクリプタブルオブジェクト
[CreateAssetMenu(fileName = "Adv", menuName = "ScriptableObject/Adv")]
public class SO_Adventure : ScriptableObject
{
	// アドベンチャーデータ
	public List<AdventureBase> adv = new List<AdventureBase>();
}