// オプションキャンバス
public class OptionCanvas : CanvasBase
{
	/// <summary>
	/// マスターの大きさ
	/// </summary>
	/// <param name="volume"></param>
	public void MasterVolume(float volume)
	{
		SoundManager.Instance.MasterVolume = volume;
	}

	/// <summary>
	/// BGMの大きさ
	/// </summary>
	/// <param name="volume"></param>
	public void BGMVolume(float volume)
	{
		SoundManager.Instance.BGMVolume = volume;
	}

	/// <summary>
	/// SE大きさ
	/// </summary>
	/// <param name="volume"></param>
	public void SEVolume(float volume)
	{
		SoundManager.Instance.SEVolume = volume;
	}

	/// <summary>
	/// 言語
	/// </summary>
	public void Language()
	{

	}

	/// <summary>
	/// 文字送り速度
	/// </summary>
	/// <param name="speed"></param>
	public void SetCharacterFeedSpeed(float speed)
	{

	}
}