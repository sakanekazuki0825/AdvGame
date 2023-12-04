using UnityEngine;

// オプション管理クラス
public class OptionManager : ManagerBase<OptionManager>
{
	// オプションキャンバス
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	private void Start()
	{
		// オプションキャンバス生成
		optionCanvas = Instantiate(optionCanvasPrefab);
		// オプションキャンバス非表示
		optionCanvas.SetActive(false);
	}

	/// <summary>
	/// オプションを開く
	/// </summary>
	public void OptionOpen()
	{
		optionCanvas.SetActive(true);
	}

	/// <summary>
	/// オプションを閉じる
	/// </summary>
	public void OptionClose()
	{
		optionCanvas.SetActive(false);
	}
}