// タイトルキャンバス
public class TitleCanvas : CanvasBase
{
	/// <summary>
	/// ゲーム開始
	/// </summary>
	public void GameStart()
	{
		// セーブデータ選択

		
		(GM_Title.Instance as GM_Title).GameStart();// 今はゲーム開始
	}

	/// <summary>
	/// 設定画面
	/// </summary>
	public void Option()
	{
		// オプション表示
	}

	/// <summary>
	/// ギャラリー
	/// </summary>
	public void Gallery()
	{
		// ギャラリー表示
	}

	/// <summary>
	/// クレジット画面
	/// </summary>
	public void Credit()
	{
		// クレジット画面表示
	}

	/// <summary>
	/// ゲーム終了
	/// </summary>
	public void GameQuit()
	{
		// ゲーム終了
	}
}