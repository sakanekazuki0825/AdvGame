// �ۑ��ǂݍ��݊Ǘ��N���X
public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// �ۑ��ł���ő吔
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	private void OnApplicationQuit()
	{
		// �ۑ�����
	}
}