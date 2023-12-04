using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

// フェード管理クラス
public class FadeManager : ManagerBase<FadeManager>
{
	// true = フェード中
	public bool IsFading
	{
		get;
		private set;
	}

	// フェードキャンバスのプレハブ
	[SerializeField]
	GameObject fadeCanvasPrefab;
	GameObject fadeCanvas;
	IFadeCanvas iFadeCanvas;

	private void Start()
	{
		// フェードしていない
		IsFading = false;
		// キャンバス生成
		fadeCanvas = Instantiate(fadeCanvasPrefab);
		// フェードキャンバス非表示
		fadeCanvas.SetActive(false);
		// フェードを行うキャンバスのインターフェイス取得
		iFadeCanvas = fadeCanvas.GetComponent<IFadeCanvas>();
	}

	/// <summary>
	/// フェードイン
	/// </summary>
	public void FadeIn()
	{
		// キャンセレーショントークン取得
		var token = this.GetCancellationTokenOnDestroy();
		// フェード開始
		FadeInAsync(token).Forget();
	}

	/// <summary>
	/// フェードアウト
	/// </summary>
	public void FadeOut()
	{
		// キャンセレーショントークン取得
		var token = this.GetCancellationTokenOnDestroy();
		// フェード開始
		FadeOutAsync(token).Forget();
	}

	/// <summary>
	/// 非同期フェードイン
	/// </summary>
	/// <param name="token">キャンセレーショントークン</param>
	/// <returns></returns>
	async UniTask FadeInAsync(CancellationToken token)
	{
		// フェード中にする
		IsFading = true;
		// フェード終了を待つ
		await UniTask.DelayFrame(1, cancellationToken: token);
		// フェード終了状態にする
		IsFading = false;
	}

	/// <summary>
	/// 非同期フェードアウト
	/// </summary>
	/// <param name="token">キャンセレーショントークン</param>
	/// <returns></returns>
	async UniTask FadeOutAsync(CancellationToken token)
	{
		// フェード中にする
		IsFading = true;
		// フェード終了を待つ
		await UniTask.DelayFrame(1, cancellationToken: token);
		// フェード終了状態にする
		IsFading = false;
	}
}