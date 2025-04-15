using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private string filePath;
    private List<LevelData> levelDataList;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/LevelData.json";

    }
}
