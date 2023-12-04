using Cysharp.Threading.Tasks;

// フェードを行うキャンバスのインターフェイス
public interface IFadeCanvas
{
	UniTask FadeIn();
	UniTask FadeOut();
}