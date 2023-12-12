using UnityEngine;

// メインのゲームマネージャー
public sealed class GM_Main : GameManagerBase
{
	// メインのキャンバス
	[SerializeField]
	GameObject mainCanvasPrefab;
	GameObject mainCanvas;

	// オプションキャンバス
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	protected override void Start()
	{
		base.Start();
		// メインのキャンバス生成
		mainCanvas = Instantiate(mainCanvasPrefab);
		// メインのキャンバス表示
		mainCanvas.SetActive(true);
	}

	/// <summary>
	/// アドベンチャースキップ
	/// </summary>
	public void AdvSkip()
	{

	}
}