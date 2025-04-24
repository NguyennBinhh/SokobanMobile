using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound/SoundDatabaseSO")]
public class SoundDatabaseSO : ScriptableObject
{
    public List<SoundDataSO> allSounds;

    public SoundDataSO GetSound(string name)
    {
        return allSounds.FirstOrDefault(s => s.soundName == name);
    }
}
