// •Û‘¶“Ç‚İ‚İŠÇ—ƒNƒ‰ƒX
public sealed class SaveLoadManager : ManagerBase<SaveLoadManager>
{
	// •Û‘¶‚Å‚«‚éÅ‘å”
	int maxSaveValue = 10;
	public int MaxSaveValue
	{
		get => maxSaveValue;
	}

	private void OnApplicationQuit()
	{
		// •Û‘¶‚·‚é
	}
}