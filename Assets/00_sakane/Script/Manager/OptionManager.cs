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
		OptionClose();
	}

	/// <summary>
	/// オプションキャンバス表示
	/// </summary>
	public void OptionOpen()
	{
		optionCanvas.SetActive(true);
	}

	/// <summary>
	/// オプションキャンバス非表示
	/// </summary>
	public void OptionClose()
	{
		optionCanvas.SetActive(false);
	}
}