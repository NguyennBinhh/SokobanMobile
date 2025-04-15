using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int LevelNumber;

    public Vector3 PosstionLevel;

    public float TimePlay;

    public bool IsComplete = false;

    public float CamFieldOfView;

}
