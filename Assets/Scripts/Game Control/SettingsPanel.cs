using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;

    private void Start()
    {
        soundToggle.isOn = PlayerPrefs.GetInt("SoundEnabled") == 1;
        musicSlider.value = PlayerPrefs.GetFloat("Music", 1);
        fxSlider.value = PlayerPrefs.GetFloat("FX", 1);
    }

    public void ToggleSound(bool enabled)
    {
        if(enabled)
        {
            _audioMixer.audioMixer.SetFloat("Master", 0f);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("Master", -80f);
        }
        PlayerPrefs.SetInt("SoundEnabled", enabled ? 1 : 0);

    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void ChangeEffectsVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("FX", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("FX", volume);
    }
}
