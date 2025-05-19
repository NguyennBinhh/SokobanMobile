using UnityEngine;

public class AudioSettingsManager : MonoBehaviour
{
    public static AudioSettingsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadingSettingPlayer();
    }
    private void LoadingSettingPlayer()
    {
        if(!PlayerPrefs.HasKey("MusicVolume")) PlayerPrefs.SetFloat("MusicVolume", 1);
        if(!PlayerPrefs.HasKey("SFXVolume")) PlayerPrefs.SetFloat("SFXVolume", 1);
        if (!PlayerPrefs.HasKey("MusicIsOn")) PlayerPrefs.SetInt("MusicIsOn", 0);
        if (!PlayerPrefs.HasKey("SFXIsOn")) PlayerPrefs.SetInt("SFXIsOn", 0);
        AudioManager.Instance.music.volume = PlayerPrefs.GetFloat("MusicVolume");
        AudioManager.Instance.music.mute = PlayerPrefs.GetInt("MusicIsOn") == 0;
        AudioManager.Instance.sFX.volume = PlayerPrefs.GetFloat("SFXVolume");
        AudioManager.Instance.sFX.mute = PlayerPrefs.GetInt("SFXIsOn") == 0;
    }

    public void SetMusicVolume(float Volume)
    {
        if (AudioManager.Instance.music == null) return;
        AudioManager.Instance.music.volume = Volume;
        PlayerPrefs.SetFloat("MusicVolume", Volume);
    }

    public void SetSFXVolume(float Volume)
    {
        if (AudioManager.Instance.sFX == null) return;
        AudioManager.Instance.sFX.volume = Volume;
        PlayerPrefs.SetFloat("SFXVolume", Volume);
    }

    public void SetMusicMute(bool check)
    {
        if (AudioManager.Instance.music == null) return;
        AudioManager.Instance.music.mute = !check;
        PlayerPrefs.SetInt("MusicIsOn", check ? 1 : 0);
    }

    public void SetSFXMute(bool check)
    {
        if (AudioManager.Instance.sFX == null) return;
        AudioManager.Instance.sFX.mute = !check;
        PlayerPrefs.SetInt("SFXIsOn", check ? 1 : 0);
    }
}
