using Cysharp.Threading.Tasks;

// アドベンチャーのインターフェイス
public interface IAdventureCanvas
{
	void ChapterChange(Chapter chapter);
	UniTask CutChange(OneCut cut);
}