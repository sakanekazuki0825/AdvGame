using System;
using System.Threading;
using Cysharp.Threading.Tasks;

// �A�h�x���`���[
[Serializable]
public class OneCut
{
	// �J�b�g�ԍ�
	public int cutNumber = 0;
	// �Z���t��e�L�X�g
	public string message = "";
	// true = �I����
	public bool isChoice = false;

	/// <summary>
	/// �J�b�g�ɓ���O�̉��o
	/// </summary>
	/// <param name="token">�L�����Z���[�V�����g�[�N��</param>
	/// <returns></returns>
	public virtual async UniTask CutBeforeEvent(CancellationToken token)
	{
		await UniTask.DelayFrame(0, cancellationToken: token);
	}

	/// <summary>
	/// �J�b�g��̉��o
	/// </summary>
	/// <param name="token">�L�����Z���[�V�����g�[�N��</param>
	/// <returns></returns>
	public virtual async UniTask CurAfterEvent(CancellationToken token)
	{
		await UniTask.DelayFrame(0, cancellationToken: token);
	}
}