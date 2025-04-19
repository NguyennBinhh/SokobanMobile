using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] protected Camera mainCamera;
    [SerializeField] protected GameObject frmHome;
    [SerializeField] protected Transform playerTransform;

    [SerializeField] public List<GameObject> Boxs;
    [SerializeField] public List<GameObject> Checkpoints;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        ButtonHandle.OnLevelButtonClicked += OnLoadLevel;
    }
    private void OnDisable()
    {
        ButtonHandle.OnLevelButtonClicked -= OnLoadLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLoadLevel(int level)
    {
        LevelData levelData = LevelDataManager.instance.GetLevelData(level);
        if(levelData != null)
        {
            this.frmHome.SetActive(false);
            this.playerTransform.position = levelData.PosstionPlayer;
            this.mainCamera.transform.position = levelData.PosstionLevel;
            this.mainCamera.fieldOfView = levelData.CamFieldOfView;
            this.LoadBoxInLevel(level);
            this.LoadCheckpointInLevel(level);  
        }
        
        Debug.Log("Level: " + levelData.LevelNumber);
        Debug.Log("Thời gian chơi: " + levelData.TimePlay);
        Debug.Log("Hoàn thành chưa: " + levelData.IsComplete);
        Debug.Log("Vị trí: " + levelData.PosstionLevel);
        Debug.Log("FOV: " + levelData.CamFieldOfView);
    } 
    
    private void LoadBoxInLevel(int level)
    {
        this.Boxs.Clear();
        string pathLevelBoxs = "Level" + level + "/Boxs";
        this.Boxs = GameObject.Find(pathLevelBoxs)
                  .GetComponentsInChildren<Transform>()
                  .Where(t => t != GameObject.Find(pathLevelBoxs).transform)
                  .Select(t => t.gameObject)
                  .ToList();
    }

    private void LoadCheckpointInLevel(int level)
    {
        this.Checkpoints.Clear();
        string pathLevelCheckpoints = "Level" + level + "/Checkpoints";
        this.Checkpoints = GameObject.Find(pathLevelCheckpoints)
                  .GetComponentsInChildren<Transform>()
                  .Where(t => t != GameObject.Find(pathLevelCheckpoints).transform)
                  .Select(t => t.gameObject)
                  .ToList();
    }
}
