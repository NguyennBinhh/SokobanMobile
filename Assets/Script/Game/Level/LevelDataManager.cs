using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private string filePath;
    private LevelDataList dataList;
    private Dictionary<int, LevelData> levelDataDict;
    public static LevelDataManager instance;
   

    private void Awake()
    {
        this.filePath = Application.persistentDataPath + "/LevelData.json";
        Debug.Log(filePath);
        this.levelDataDict = new Dictionary<int, LevelData>();
        this.dataList = new LevelDataList();
        instance = this;
        LoadData();
    }

    public void LoadData()
    {
        if (File.Exists(this.filePath))
        {
            string content = File.ReadAllText(this.filePath);
            this.dataList = JsonUtility.FromJson<LevelDataList>(content);
            if (this.dataList == null || dataList.levels == null)
                this.dataList = new LevelDataList();
        }
        else
        {
            Debug.Log("No save file found, creating new.");
            this.dataList = new LevelDataList();

        }

        ConvertToDict();
    }

    private void SaveData()
    {
        string content = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(this.filePath, content);
    }

    private void ConvertToDict()
    {
        this.levelDataDict.Clear();
        foreach (var level in dataList.levels)
        {
            this.levelDataDict[level.LevelNumber] = level;
        }
    }

    public LevelData GetLevelData(int levelNumber)
    {
        if (this.levelDataDict.TryGetValue(levelNumber, out var data))
            return data;

        // Nếu chưa có thì tạo mới
        LevelData newData = new LevelData { LevelNumber = levelNumber };
        this.dataList.levels.Add(newData);
        this.levelDataDict[levelNumber] = newData;
        SaveData();
        return newData;
    }

    public void UpdateLevelData(int levelNumber, Vector3 posstionLevel, float timePlay, bool isComplete, float camFieldOfView, Vector3 posstionPlayer, int totalSteps, int totalStepsPlay)
    {
        LevelData data = GetLevelData(levelNumber);
        data.PosstionLevel = posstionLevel;
        data.TimePlay = timePlay;
        data.IsComplete = isComplete;
        data.CamFieldOfView = camFieldOfView;
        data.PosstionPlayer = posstionPlayer;
        data.TotalSteps = totalSteps;
        data.TotalStepsPlay = totalStepsPlay;
        SaveData();
    }
}
