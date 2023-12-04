using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

// ���x���Ǘ��N���X
public sealed class LevelManager : ManagerBase<LevelManager>
{
	// true = ���x���ǂݍ��ݒ�
	static bool isLevelLoading = false;
	public static bool IsLevelLoading
	{
		get => isLevelLoading;
	}

	// true = ���x�����ړ����邱�Ƃ��ł���
	public static bool canLevelMove = true;

	/// <summary>
	/// �V�[���؂�ւ�
	/// </summary>
	/// <param name="levelName">�V�[����</param>
	/// <returns></returns>
	public static async UniTaskVoid OpenLevel(string levelName)
	{
		// �ǂݍ��ݒ��ɂ���
		isLevelLoading = true;
		// �ǂݍ���
		var operation = SceneManager.LoadSceneAsync(levelName);
		operation.allowSceneActivation = false;
		await UniTask.WaitUntil(() => operation.progress >= 0.9f);
		// �ǂݍ��ݒ�������
		isLevelLoading = false;
		// �ړ��ł����ԂɂȂ�܂ő҂�
		await UniTask.WaitUntil(() => canLevelMove);
		// �ړ��ł����Ԃɂ���
		operation.allowSceneActivation = true;
	}

	/// <summary>
	/// �Q�[���I��
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