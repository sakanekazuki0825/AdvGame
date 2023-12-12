using System.Collections.Generic;

// 保存するデータ
public class SaveData
{
	// 音量
	public float masterVolume = 1;
	public float bgmVolume = 0.5f;
	public float seVolume = 0.5f;

	// 文字送りの速度
	public float characterFeedSpeed = 0.08f;

	// アドベンチャーのデータ
	public List<AdvData> advDatas = new List<AdvData>();
}