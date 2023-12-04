using System.IO;
using UnityEngine;

// 保存読み込み管理クラス
public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// 保存できる最大数
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	// 保存読み込みキャンバス
	[SerializeField]
	GameObject saveLoadCanvasPrefab;
	GameObject saveLoadCanvas;

	private void Start()
	{
		// 保存読み込みキャンバス生成
		saveLoadCanvas = Instantiate(saveLoadCanvasPrefab);
		// 保存読み込みキャンバス非表示
		saveLoadCanvas.SetActive(false);
	}

	/// <summary>
	/// 保存読み込みキャンバスを開く
	/// </summary>
	public void SaveLoadCanvasOpen()
	{
		saveLoadCanvas.SetActive(true);
	}
}