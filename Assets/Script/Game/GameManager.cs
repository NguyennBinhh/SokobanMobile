﻿
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected LoadLevel _loadLevel;
    [SerializeField] protected PlayerController _playerController;
    [SerializeField] protected TimerTool _timerTool;
    
    [SerializeField] private int StepsInitial;
    [SerializeField] private Vector3 PlayerPossionInitial;

    public List<BoxManager> allBoxes;
    public List<GameObject> allCheckpoints;
    public Stack<GameStateData> gameStates = new Stack<GameStateData>();

    private float timer;
    [SerializeField] private List<Vector3> ListBoxStart;
    public int steps;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        this._loadLevel = GetComponent<LoadLevel>();
        this._timerTool = GetComponent<TimerTool>();
        this.timer = 0;
        this.ResetAllList();
    }

    private void OnEnable()
    {
        WinChecker.LevelSuccess += OnLevelSuccess;
    }

    private void Update()
    {
        if(this._loadLevel.IsLoadLVComplete)
        {
            this.timer = this._timerTool.Timer();
            HeaderUI.Instance.UpdateUiTime(this.timer);
            this.GameOver();
        }
    }

    private void OnDisable()
    {
        WinChecker.LevelSuccess -= OnLevelSuccess;
    }

    public void SaveGameState()
    {
        if(this.allBoxes.Count <= 0) return;

        List<Vector2> boxPositions = new List<Vector2>();
        foreach (BoxManager box in allBoxes)
        {
            boxPositions.Add(box.transform.position);
        }

        this.gameStates.Push(new GameStateData(this._playerController.transform.position, boxPositions));
    }

    private void OnLevelSuccess()
    {
        HeaderUI.Instance.SetActiveFormLevelUp(true);
        Time.timeScale = 0;
        int levelCurruent = PlayerPrefs.GetInt("LevelCurrent");
        Debug.Log(levelCurruent);
        LevelData levelData = LevelDataManager.instance.GetLevelData(levelCurruent);
        if(levelData == null) return;
        if (levelData.TimePlay == 0 || levelData.TimePlay > this.timer)
        {
            HeaderUI.Instance.IsHighScore(true);
            LevelDataManager.instance.UpdateLevelData(levelCurruent, levelData.PosstionLevel, this.timer, true, levelData.CamFieldOfView, levelData.PosstionPlayer, levelData.TotalSteps, this.steps);
        } 
        else
            HeaderUI.Instance.IsHighScore(false);
        HeaderUI.Instance.UpdateUiLevelUp(levelCurruent, this.timer, this.steps);
        Debug.Log("Đã cập nhật level");
    }   

    public void ResetLevel()
    {
        this._playerController.transform.position = this.PlayerPossionInitial;
        this._playerController.RotatePlayerInFront();
        this._timerTool.elapsedTime = 0;
        this.steps = this.StepsInitial;
        this.UpdateAllBoxColors();
        HeaderUI.Instance.UpdateUiStep(this.steps);
        int i = 0;
        foreach (BoxManager possion in this.allBoxes)
        {
            possion.gameObject.transform.position = this.ListBoxStart[i];
            i++;
        }
    }

    public void SavePossitonBoxStart(int steps, Vector3 PlayerPossion)
    {
        if (this.allBoxes == null) return;
        foreach (BoxManager possion in this.allBoxes)
        {
            this.ListBoxStart.Add(possion.transform.position);
        }
        this.StepsInitial = steps;
        this.PlayerPossionInitial = PlayerPossion;

    }

    public void ResetAllList()
    {
        this.allBoxes.Clear();
        this.allCheckpoints.Clear();
        this.ListBoxStart.Clear();
        this.gameStates.Clear();
    }

    public void GameOver()
    {
        if(this.steps > 0) return; 
        if(this.steps == 0)
        {
            Time.timeScale = 0;
            HeaderUI.Instance.SetActiveFormGameOver(true);
        }
    }

    public void UpdateAllBoxColors()
    {
        if (this.allBoxes.Count <= 0) return;
        if (this.allCheckpoints.Count <= 0) return;
        foreach (var box in this.allBoxes)
        {
            box.UpdateColorIfOnCheckpoint(this.allCheckpoints.Select(go => go.transform).ToList());
        }
    }
}
