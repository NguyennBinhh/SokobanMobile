
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected LoadLevel _loadLevel;
    [SerializeField] protected PlayerController _playerController;
    [SerializeField] protected TimerTool _timerTool;

    [SerializeField] private List<Transform> ListBoxStart;
    [SerializeField] private int StepsInitial;
    [SerializeField] private Vector3 PlayerPossionInitial;

    public List<BoxManager> allBoxes;
    public List<GameObject> allCheckpoints;
    public Stack<GameStateData> gameStates = new Stack<GameStateData>();

    private float timer;
    public int steps;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        this._loadLevel = GetComponent<LoadLevel>();
        this._timerTool = GetComponent<TimerTool>();
        this.timer = 0;
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
        LevelData levelData = LevelDataManager.instance.GetLevelData(levelCurruent);
        if(levelData == null) return;
        if (levelData.TimePlay > this.timer)
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
        this.timer = 0;
        this.steps = this.StepsInitial;
        HeaderUI.Instance.UpdateUiStep(this.steps);
    }

    public void SavePossitonBoxStart(int steps, Vector3 PlayerPossion)
    {
        if (GameManager.Instance.allBoxes == null) return;
        foreach (BoxManager possion in GameManager.Instance.allBoxes)
        {
            this.ListBoxStart.Add(possion.transform);
        }
        this.StepsInitial = steps;
        this.PlayerPossionInitial = PlayerPossion;

    }

}
