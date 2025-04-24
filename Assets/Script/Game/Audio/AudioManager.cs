using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected SoundDatabaseSO _soundDatabaseSO;
    [SerializeField] public AudioSource music;
    [SerializeField] public AudioSource sFX;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        PlayMusic("Music1");
    }

    public void PlayMusic(string name)
    {
        var soundData = this._soundDatabaseSO.GetSound(name);
        if (soundData == null) return;
        this.music.clip = soundData.clip;
        this.music.loop = soundData.loop;
        this.music.Play();
    }

    public void PlaySFX(string name)
    {
        var soundData = this._soundDatabaseSO.GetSound(name);
        if (soundData == null) return;
        this.sFX.PlayOneShot(soundData.clip);
    }

    public void StopMusic()
    {
        this.music.Stop();
    }
}
