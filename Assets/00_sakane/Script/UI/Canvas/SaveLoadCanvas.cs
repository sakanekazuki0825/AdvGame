using System.Collections.Generic;
using UnityEngine;

// 保存読み込みキャンバス
public class SaveLoadCanvas : CanvasBase
{
	// 保存と読み込みを行うボタン
	[SerializeField]
	GameObject seveLoadButtonPrefab;
	List<GameObject> saveLoadButtons = new List<GameObject>();

	// ボタンの親オブジェクト
	[SerializeField]
	GameObject content;

	protected override void Start()
	{
		base.Start();
		// ボタン生成
		for (int i = 0; i < SaveLoadManager.Instance.MaxSaveValue; ++i)
		{
			saveLoadButtons.Add(Instantiate(seveLoadButtonPrefab, content.transform));
		}
	}
}