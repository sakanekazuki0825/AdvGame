using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// プレイヤークラス
public class Player : MonoBehaviour
{
	// 入力
	MainInput input;

	// true = UIにカーソルをあわせている
	bool isOnUI = false;

	void Start()
	{
		// 入力システム生成
		input = new MainInput();
		// 入力システム有効化
		input.Enable();
		// 入力による反応設定
		input.Player.NextMessage.started += Input;
	}

	private void OnEnable()
	{
		// 入力有効化
		input?.Enable();
	}

	private void Update()
	{
		isOnUI = EventSystem.current.IsPointerOverGameObject();
	}

	private void OnDisable()
	{
		// 入力無効化
		input.Disable();
	}

	private void OnDestroy()
	{
		input.Player.NextMessage.started -= Input;
	}

	void Input(InputAction.CallbackContext context)
	{
		// オブジェクトにカーソルがあっている場合入力無視
		if (isOnUI)
		{
			return;
		}
		AdventureManager.Instance.NextCut();
	}
}