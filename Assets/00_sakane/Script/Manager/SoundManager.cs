using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// 音管理クラス
public class SoundManager : ManagerBase<SoundManager>
{
	// bgmを再生するクラス
	[SerializeField]
	AudioSource bgmSource;

	// 音を再生するクラス
	[SerializeField]
	List<AudioSource> seSources = new List<AudioSource>();

	// オーディオミキサー
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
	/// BGM再生
	/// </summary>
	/// <param name="clip">再生する音</param>
	public void BGMPlay(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			// 再生中であれば止める
			bgmSource.Stop();
		}
		// ループ再生させる
		bgmSource.loop = true;
		// 再生する音を設定
		bgmSource.clip = clip;
		// 再生開始
		bgmSource.Play();
	}

	/// <summary>
	/// BGM変更
	/// </summary>
	/// <param name="clip">再生する音</param>
	public void BGMChange(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			// 再生中であれば止める
			bgmSource.Stop();
		}
		// ループ再生させる
		bgmSource.loop = true;
		// 再生する音を設定
		bgmSource.clip = clip;
		// 再生開始
		bgmSource.Play();
	}

	/// <summary>
	/// SE再生
	/// </summary>
	/// <param name="clip">再生する音</param>
	public void PlaySE(AudioClip clip)
	{
		// 再生していないクリップを探してくる
		var v = seSources.Find(x => !x.isPlaying);
		if (v != null)
		{
			// クリップ設定
			v.clip = clip;
			// ループさせない
			v.loop = false;
			// 再生する
			v.Play();
		}
	}

	/// <summary>
	/// 音量調整
	/// </summary>
	/// <param name="volume"></param>
	float VolumeAdjustment(float volume)
	{
		var db = Mathf.Sqrt(Mathf.Sqrt(volume)) * 80 - 80;

		return db;
	}
}