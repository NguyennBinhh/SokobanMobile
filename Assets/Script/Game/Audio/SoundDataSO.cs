using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound/SoundDataSO")]
public class SoundDataSO : ScriptableObject
{
    public string soundName;
    public AudioClip clip;
    public bool loop;
}
