using UnityEngine;
using Cysharp.Threading.Tasks;

// �t�F�[�h���s���L�����o�X
public class FadeCanvas : MonoBehaviour, IFadeCanvas
{
	public async UniTask FadeIn()
	{
	// �L�����Z���[�V�����g�[�N��
		var token = this.GetCancellationTokenOnDestroy();
		// �t�F�[�h���s��
		await UniTask.DelayFrame(1, cancellationToken: token);
	}

	public async UniTask FadeOut()
	{
		var token = this.GetCancellationTokenOnDestroy();
		await UniTask.DelayFrame(1, cancellationToken: token);
	}
}