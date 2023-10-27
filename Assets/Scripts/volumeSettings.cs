using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider masterSlider;
    public Slider sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string MasterVolumeKey = "MasterVolume";
    private const string SFXVolumeKey = "SFXVolume";

    private void Start()
    {
        // Load saved volume settings from PlayerPrefs and set the sliders
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            musicSlider.value = savedMusicVolume;
            SetVolumeMusic(savedMusicVolume);
        }
        if (PlayerPrefs.HasKey(MasterVolumeKey))
        {
            float savedMasterVolume = PlayerPrefs.GetFloat(MasterVolumeKey);
            masterSlider.value = savedMasterVolume;
            SetVolumeMaster(savedMasterVolume);
        }
        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
            sfxSlider.value = savedSFXVolume;
            SetVolumeSFX(savedSFXVolume);
        }
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MasterVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
