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

    [SerializeField] public List<BoxManager> Boxs;
    [SerializeField] public List<GameObject> Checkpoints;

    private void OnEnable()
    {
        ButtonHandle.OnLevelButtonClicked += OnLoadLevel;
    }
    private void OnDisable()
    {
        ButtonHandle.OnLevelButtonClicked -= OnLoadLevel;
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
            GameManager.Instance.allBoxes.Clear();
            GameManager.Instance.allBoxes = this.Boxs;
            GameManager.Instance.allCheckpoints.Clear();
            GameManager.Instance.allCheckpoints = this.Checkpoints;
        }
        
    } 
    
    private void LoadBoxInLevel(int level)
    {
        this.Boxs.Clear();
        string pathLevelBoxs = "Level" + level + "/Boxs";
        GameObject levelBoxsObj = GameObject.Find(pathLevelBoxs);
        this.Boxs = levelBoxsObj
            .GetComponentsInChildren<BoxManager>()
            .Where(box => box.gameObject != levelBoxsObj)
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
