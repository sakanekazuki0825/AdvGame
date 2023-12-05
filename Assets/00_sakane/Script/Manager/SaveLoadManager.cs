// 保存読み込み管理クラス
public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// 保存できる最大数
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	private void OnApplicationQuit()
	{
		// 保存する
	}
}