using Naninovel;
using UnityEngine.SceneManagement;

[CommandAlias("ReturnTitle")]
public class CReturnTitle : Command
{
	public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
	{
		SceneManager.LoadScene("TitleScene");
		// naninovel終了

		// IScriptPlayerサービスを取得
		var scriptPlayer = Engine.GetService<IScriptPlayer>();

		// 現在再生中のスクリプトの名前を取得
		string currentScriptName = scriptPlayer.PlayedScript.Name;

		scriptPlayer.Stop();

		return UniTask.CompletedTask;
	}
}