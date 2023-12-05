using System;
using System.Threading;
using Cysharp.Threading.Tasks;

// アドベンチャー
[Serializable]
public class OneCut
{
	// カット番号
	public int cutNumber = 0;
	// セリフやテキスト
	public string message = "";
	// true = 選択肢
	public bool isChoice = false;

	/// <summary>
	/// カットに入る前の演出
	/// </summary>
	/// <param name="token">キャンセレーショントークン</param>
	/// <returns></returns>
	public virtual async UniTask CutBeforeEvent(CancellationToken token)
	{
		await UniTask.DelayFrame(0, cancellationToken: token);
	}

	/// <summary>
	/// カット後の演出
	/// </summary>
	/// <param name="token">キャンセレーショントークン</param>
	/// <returns></returns>
	public virtual async UniTask CurAfterEvent(CancellationToken token)
	{
		await UniTask.DelayFrame(0, cancellationToken: token);
	}
}