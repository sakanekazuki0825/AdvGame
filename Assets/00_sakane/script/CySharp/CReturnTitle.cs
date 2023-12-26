using Naninovel;
using UnityEngine.SceneManagement;

[CommandAlias("ReturnTitle")]
public class CReturnTitle : Command
{
	public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
	{
		SceneManager.LoadScene("TitleScene");
		// naninovel�I��

		// IScriptPlayer�T�[�r�X���擾
		var scriptPlayer = Engine.GetService<IScriptPlayer>();

		// ���ݍĐ����̃X�N���v�g�̖��O���擾
		string currentScriptName = scriptPlayer.PlayedScript.Name;

		scriptPlayer.Stop();

		return UniTask.CompletedTask;
	}
}