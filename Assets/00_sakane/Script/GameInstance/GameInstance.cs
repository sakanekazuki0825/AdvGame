using UnityEngine;

// ゲームインスタンス
public sealed class GameInstance
{
	// ゲームの状態
	public enum GameState
	{
		Title,
		Option,
		MainGame,
	}

	// インスタンス
	static GameInstance instance;
	// インスタンス取得
	public static GameInstance Instance
	{
		get => instance;
	}

	/// <summary>
	/// コンストラクタ
	/// </summary>
	private GameInstance()
	{

	}

	// ゲーム開始時に生成
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void Initialize()
	{
		// ゲームインスタンス生成
		instance = new GameInstance();

		saveData = FileManager.LoadJson<SaveData>(Application.persistentDataPath + "/saveData.json");
	}

	// 保存するデータ
	public static SaveData saveData = new SaveData();

#if UNITY_EDITOR
	// デバッグ機能
	public readonly static bool isDebug = true;
#endif
}