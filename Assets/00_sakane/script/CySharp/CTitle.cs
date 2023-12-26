using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CTitle : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
		{
			GameStartAsync().Forget();
		}
	}

	public async UniTask GameStartAsync()
	{
		if (Engine.Initialized)
		{
			return;
		}

		await RuntimeInitializer.InitializeAsync();

		SceneManager.LoadScene("MainGame");
	}
}
