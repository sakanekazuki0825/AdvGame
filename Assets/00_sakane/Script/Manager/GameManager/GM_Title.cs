using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// タイトルマネージャー
public class GM_Title : GameManagerBase
{
	// タイトルキャンバス
	[SerializeField]
	GameObject titleCanvasPrefab;
	GameObject titleCanvas;

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
	}

	/// <summary>
	/// ゲーム開始
	/// </summary>
	public void GameStart()
	{

	}

	/// <summary>
	/// クレジット
	/// </summary>
	public void Credit()
	{

	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	public void Quit()
	{
		LevelManager.GameQuit();
	}
}