// �I�v�V�����L�����o�X
public class OptionCanvas : CanvasBase
{
	/// <summary>
	/// �}�X�^�[�̑傫��
	/// </summary>
	/// <param name="volume"></param>
	public void MasterVolume(float volume)
	{
		SoundManager.Instance.MasterVolume = volume;
	}

	/// <summary>
	/// BGM�̑傫��
	/// </summary>
	/// <param name="volume"></param>
	public void BGMVolume(float volume)
	{
		SoundManager.Instance.BGMVolume = volume;
	}

	/// <summary>
	/// SE�傫��
	/// </summary>
	/// <param name="volume"></param>
	public void SEVolume(float volume)
	{
		SoundManager.Instance.SEVolume = volume;
	}

	/// <summary>
	/// ����
	/// </summary>
	public void Language()
	{

	}

	/// <summary>
	/// �������葬�x
	/// </summary>
	/// <param name="speed"></param>
	public void SetCharacterFeedSpeed(float speed)
	{

	}
}