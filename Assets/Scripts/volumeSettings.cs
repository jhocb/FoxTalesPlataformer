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

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
}
