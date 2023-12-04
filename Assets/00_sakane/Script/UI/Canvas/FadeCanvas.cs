using UnityEngine;
using Cysharp.Threading.Tasks;

// フェードを行うキャンバス
public class FadeCanvas : MonoBehaviour, IFadeCanvas
{
	public async UniTask FadeIn()
	{
	// キャンセレーショントークン
		var token = this.GetCancellationTokenOnDestroy();
		// フェードを行う
		await UniTask.DelayFrame(1, cancellationToken: token);
	}

	public async UniTask FadeOut()
	{
		var token = this.GetCancellationTokenOnDestroy();
		await UniTask.DelayFrame(1, cancellationToken: token);
	}
}