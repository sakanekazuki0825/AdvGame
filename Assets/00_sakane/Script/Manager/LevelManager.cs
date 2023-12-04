using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

// レベル管理クラス
public sealed class LevelManager : ManagerBase<LevelManager>
{
	// true = レベル読み込み中
	static bool isLevelLoading = false;
	public static bool IsLevelLoading
	{
		get => isLevelLoading;
	}

	// true = レベルを移動することができる
	public static bool canLevelMove = true;

	/// <summary>
	/// シーン切り替え
	/// </summary>
	/// <param name="levelName">シーン名</param>
	/// <returns></returns>
	public static async UniTaskVoid OpenLevel(string levelName)
	{
		// 読み込み中にする
		isLevelLoading = true;
		// 読み込み
		var operation = SceneManager.LoadSceneAsync(levelName);
		operation.allowSceneActivation = false;
		await UniTask.WaitUntil(() => operation.progress >= 0.9f);
		// 読み込み中を解除
		isLevelLoading = false;
		// 移動できる状態になるまで待つ
		await UniTask.WaitUntil(() => canLevelMove);
		// 移動できる状態にする
		operation.allowSceneActivation = true;
	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	public static void GameQuit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}