using Cysharp.Threading.Tasks;

// �A�h�x���`���[�̃C���^�[�t�F�C�X
public interface IAdventureCanvas
{
	void ChapterChange(Chapter chapter);
	UniTask CutChange(OneCut cut);
}