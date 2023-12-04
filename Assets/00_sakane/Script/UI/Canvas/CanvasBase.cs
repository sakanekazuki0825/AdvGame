using UnityEngine;
using UnityEngine.UI;

// キャンバスの基底クラス
public class CanvasBase : MonoBehaviour
{
	protected virtual void Start()
	{
		// カメラを設定
		GetComponent<Canvas>().worldCamera = Camera.main;
		// 解像度設定
		GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
	}

	/// <summary>
	/// 閉じる
	/// </summary>
	public void Close()
	{
		gameObject.SetActive(false);
	}
}
