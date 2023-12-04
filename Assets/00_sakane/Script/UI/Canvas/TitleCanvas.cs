// タイトルのキャンバス
public class TitleCanvas : CanvasBase
{
	/// <summary>
	/// ゲーム開始
	/// </summary>
	public void GameStart()
	{
		// セーブデータ選択
	}

	/// <summary>
	/// オプションを開く
	/// </summary>
	public void Option()
	{
		OptionManager.Instance.OptionOpen();
	}

	/// <summary>
	/// クレジットを開く
	/// </summary>
	public void Credit()
	{
		(GM_Title.Instance as GM_Title).Credit();
	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	public void Quit()
	{
		(GM_Title.Instance as GM_Title).Quit();
	}
}