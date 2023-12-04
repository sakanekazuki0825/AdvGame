using UnityEngine;

// ゲームインスタンス
public class GameInstance
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
		//Debug.Log(Application.persistentDataPath);
		instance = new GameInstance();
	}

	// 保存するデータ
	public static SaveData saveData = new SaveData();

#if UNITY_EDITOR
	// デバッグ機能
	public readonly static bool isDebug = true;
#endif
}