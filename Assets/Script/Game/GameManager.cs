
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected LoadLevel _loadLevel;
    [SerializeField] protected PlayerController _playerController;
    [SerializeField] protected TimerTool _timerTool;
    

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
        Debug.Log("Ok");
    }    

}
