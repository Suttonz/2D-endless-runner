using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider backGroundMusicSlider;
    [SerializeField] Slider soundEffectSlider;
    private float backGroundMusicVolume;
    private float soundEffectVolume;


    void Start()
    {
        //Remember player last volume setting
        backGroundMusicSlider.value = PlayerPrefs.GetFloat("BackgroundMusicVolume");
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume");
    }


    void Update()
    {
        SetBackgroundMusicVolume();
        SetSoundEffectVolume();
    }

    public void SetBackgroundMusicVolume()
    {
        backGroundMusicVolume = backGroundMusicSlider.value;
        PlayerPrefs.SetFloat("BackgroundMusicVolume", backGroundMusicVolume);
    }

    public void SetSoundEffectVolume()
    {
        soundEffectVolume = soundEffectSlider.value;
        PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectVolume);
    }
}
