using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnTrigger : MonoBehaviour
{
    [SerializeField] protected Slider sldMusic;
    [SerializeField] protected Slider sldSFX;
    [SerializeField] protected Toggle toggleMusic;
    [SerializeField] protected Toggle toggleSFX;
    private void OnEnable() => LoadDataAudio();

    private void Start()
    {
        LoadDataAudio();
    }

    private void LoadDataAudio()
    {
        this.sldMusic.value = AudioManager.Instance.music.volume;
        this.toggleMusic.isOn = !AudioManager.Instance.music.mute;
        this.sldSFX.value = AudioManager.Instance.sFX.volume;
        this.toggleSFX.isOn = !AudioManager.Instance.sFX.mute;
    }    
    public void OnchangedSliderMusic()
    {
        if (this.sldMusic == null) return;
        AudioSettingsManager.Instance.SetMusicVolume(this.sldMusic.value);
    }

    public void OnchangedSliderSFX()
    {
        if (this.sldSFX == null) return;
        AudioSettingsManager.Instance.SetSFXVolume(this.sldSFX.value);
    }

    public void OnChangedToggleMusic()
    {
        if (this.toggleMusic == null) return;
        AudioSettingsManager.Instance.SetMusicMute(this.toggleMusic.isOn);
    }
    public void OnChangedToggleSFX()
    {
        if (this.toggleSFX == null) return;
        AudioSettingsManager.Instance.SetSFXMute(this.toggleSFX.isOn);
    }
}
