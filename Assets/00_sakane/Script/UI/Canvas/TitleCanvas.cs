// �^�C�g���̃L�����o�X
public class TitleCanvas : CanvasBase
{
	/// <summary>
	/// �Q�[���J�n
	/// </summary>
	public void GameStart()
	{
		// �Z�[�u�f�[�^�I��
	}

	/// <summary>
	/// �I�v�V�������J��
	/// </summary>
	public void Option()
	{
		OptionManager.Instance.OptionOpen();
	}

	/// <summary>
	/// �N���W�b�g���J��
	/// </summary>
	public void Credit()
	{
		(GM_Title.Instance as GM_Title).Credit();
	}

	/// <summary>
	/// �Q�[���I��
	/// </summary>
	public void Quit()
	{
		(GM_Title.Instance as GM_Title).Quit();
	}
}