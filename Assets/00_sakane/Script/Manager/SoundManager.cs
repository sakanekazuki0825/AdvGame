using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// ���Ǘ��N���X
public class SoundManager : ManagerBase<SoundManager>
{
	// bgm���Đ�����N���X
	[SerializeField]
	AudioSource bgmSource;

	// �����Đ�����N���X
	[SerializeField]
	List<AudioSource> seSources = new List<AudioSource>();

	// �I�[�f�B�I�~�L�T�[
	[SerializeField]
	AudioMixer audioMixer;

	public float MasterVolume
	{
		get => 0;
		set
		{
			audioMixer.SetFloat("", VolumeAdjustment(value));
			GameInstance.saveData.masterVolume = value;
		}
	}

	public float BGMVolume
	{
		get => 0;
		set
		{
			audioMixer.SetFloat("", VolumeAdjustment(value));
			GameInstance.saveData.bgmVolume = value;
		}
	}

	public float SEVolume
	{
		get => 0;
		set
		{
			audioMixer.SetFloat("", VolumeAdjustment(value));
			GameInstance.saveData.seVolume = value;
		}
	}

	/// <summary>
	/// BGM�Đ�
	/// </summary>
	/// <param name="clip">�Đ����鉹</param>
	public void BGMPlay(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			// �Đ����ł���Ύ~�߂�
			bgmSource.Stop();
		}
		// ���[�v�Đ�������
		bgmSource.loop = true;
		// �Đ����鉹��ݒ�
		bgmSource.clip = clip;
		// �Đ��J�n
		bgmSource.Play();
	}

	/// <summary>
	/// BGM�ύX
	/// </summary>
	/// <param name="clip">�Đ����鉹</param>
	public void BGMChange(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			// �Đ����ł���Ύ~�߂�
			bgmSource.Stop();
		}
		// ���[�v�Đ�������
		bgmSource.loop = true;
		// �Đ����鉹��ݒ�
		bgmSource.clip = clip;
		// �Đ��J�n
		bgmSource.Play();
	}

	/// <summary>
	/// SE�Đ�
	/// </summary>
	/// <param name="clip">�Đ����鉹</param>
	public void PlaySE(AudioClip clip)
	{
		// �Đ����Ă��Ȃ��N���b�v��T���Ă���
		var v = seSources.Find(x => !x.isPlaying);
		if (v != null)
		{
			// �N���b�v�ݒ�
			v.clip = clip;
			// ���[�v�����Ȃ�
			v.loop = false;
			// �Đ�����
			v.Play();
		}
	}

	/// <summary>
	/// ���ʒ���
	/// </summary>
	/// <param name="volume"></param>
	float VolumeAdjustment(float volume)
	{
		var db = Mathf.Sqrt(Mathf.Sqrt(volume)) * 80 - 80;

		return db;
	}
}