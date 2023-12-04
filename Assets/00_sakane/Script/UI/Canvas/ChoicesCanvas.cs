using System.Collections.Generic;
using UnityEngine;

// 選択肢を表示するキャンバス
public class ChoicesCanvas : CanvasBase
{
	// 選択肢のボタンの数
	int selectBtnValue = 0;

	// 選択肢ボタンプレハブ
	[SerializeField]
	GameObject selectBtnPrefab;

	// 選択肢を表示するボタン
	[SerializeField]
	List<GameObject> selectBtns = new List<GameObject>();

	// ボタンの親オブジェクト
	[SerializeField]
	GameObject content;

	// ボタン用のテキスト
	[SerializeField]
	List<string> buttonText = new List<string>();

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize()
	{
		foreach (var v in buttonText)
		{
			// ボタン生成
			var button = Instantiate(selectBtnPrefab, content.transform);
			// ボタン登録
			selectBtns.Add(button);
			// ボタン初期化
			button.GetComponent<SelectButton>().Initialized(v);
			// ボタンの数追加
			++selectBtnValue;
		}
	}
}
