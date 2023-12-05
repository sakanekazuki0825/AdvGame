using UnityEngine;

// タイトルマネージャー
public sealed class GM_Title : GameManagerBase
{
	// タイトルキャンバス
	[SerializeField]
	GameObject titleCanvasPrefab;
	GameObject titleCanvas;

	// オプション
	[SerializeField]
	GameObject optionCanvasPrefab;
	GameObject optionCanvas;

	// クレジット
	[SerializeField]
	GameObject creditCanvasPrefab;
	GameObject creditCanvas;

	protected override void Start()
	{
		base.Start();
		// キャンバス生成
		titleCanvas = Instantiate(titleCanvasPrefab);
		// タイトルキャンバス表示
		titleCanvas.SetActive(true);

		// クレジットキャンバス生成
		creditCanvas = Instantiate(creditCanvasPrefab);
		// クレジットキャンバス非表示
		creditCanvas.SetActive(false);

		// オプションキャンバス生成
		optionCanvas = Instantiate(optionCanvasPrefab);
		// オプションキャンバス非表示
		optionCanvas.SetActive(false);
	}

	/// <summary>
	/// ゲーム開始
	/// </summary>
	public void GameStart()
	{
		LevelManager.OpenLevel("MainScene").Forget();
	}

	/// <summary>
	/// クレジット
	/// </summary>
	public void Credit()
	{
		creditCanvas.SetActive(true);
	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	public void Quit()
	{
		LevelManager.GameQuit();
	}
}