using UnityEngine;

// �Q�[���C���X�^���X
public sealed class GameInstance
{
	// �Q�[���̏��
	public enum GameState
	{
		Title,
		Option,
		MainGame,
	}

	// �C���X�^���X
	static GameInstance instance;
	// �C���X�^���X�擾
	public static GameInstance Instance
	{
		get => instance;
	}

	/// <summary>
	/// �R���X�g���N�^
	/// </summary>
	private GameInstance()
	{

	}

	// �Q�[���J�n���ɐ���
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void Initialize()
	{
		// �Q�[���C���X�^���X����
		instance = new GameInstance();

		saveData = FileManager.LoadJson<SaveData>(Application.persistentDataPath + "/saveData.json");
	}

	// �ۑ�����f�[�^
	public static SaveData saveData = new SaveData();

#if UNITY_EDITOR
	// �f�o�b�O�@�\
	public readonly static bool isDebug = true;
#endif
}