using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected SoundDatabaseSO _soundDatabaseSO;
    [SerializeField] protected AudioSource mussic;
    [SerializeField] protected AudioSource sFX;

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
        this.mussic.clip = soundData.clip;
        this.mussic.loop = soundData.loop;
        this.mussic.Play();
    }

    public void PlaySFX(string name)
    {
        var soundData = this._soundDatabaseSO.GetSound(name);
        if (soundData == null) return;
        this.sFX.PlayOneShot(soundData.clip);
    }

    public void StopMusic()
    {
        this.mussic.Stop();
    }
}
