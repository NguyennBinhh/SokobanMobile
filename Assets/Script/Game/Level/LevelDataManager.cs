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
        filePath = Application.persistentDataPath + "/LevelData.json";
        levelDataDict = new Dictionary<int, LevelData>();
        dataList = new LevelDataList();
        instance = this;

        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            dataList = JsonUtility.FromJson<LevelDataList>(content);
            if (dataList == null || dataList.levels == null)
                dataList = new LevelDataList();
        }
        else
        {
            Debug.Log("No save file found, creating new.");
            dataList = new LevelDataList();
        }

        ConvertToDict();
    }

    private void SaveData()
    {
        string content = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(filePath, content);
    }

    private void ConvertToDict()
    {
        levelDataDict.Clear();
        foreach (var level in dataList.levels)
        {
            levelDataDict[level.LevelNumber] = level;
        }
    }

    public LevelData GetLevelData(int levelNumber)
    {
        if (levelDataDict.TryGetValue(levelNumber, out var data))
            return data;

        // Nếu chưa có thì tạo mới
        LevelData newData = new LevelData { LevelNumber = levelNumber };
        dataList.levels.Add(newData);
        levelDataDict[levelNumber] = newData;
        return newData;
    }

    public void UpdateLevelData(int levelNumber, Vector3 posstionLevel, float timePlay, bool isComplete, float camFieldOfView)
    {
        LevelData data = GetLevelData(levelNumber);
        data.PosstionLevel = posstionLevel;
        data.TimePlay = timePlay;
        data.IsComplete = isComplete;
        data.CamFieldOfView = camFieldOfView;

        SaveData();
    }
}
