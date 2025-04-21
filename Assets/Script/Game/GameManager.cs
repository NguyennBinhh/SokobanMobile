
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected LoadLevel _loadLevel;
    [SerializeField] protected PlayerController _playerController;
    public List<BoxManager> allBoxes;
    public List<GameObject> allCheckpoints;
    public Stack<GameStateData> gameStates = new Stack<GameStateData>();

    public static GameManager Instance;

    private void OnEnable()
    {
       // ButtonHandle.OnLevelButtonClicked += OnCreateListBox;
    }
    private void Awake()
    {
        Instance = this;
        this._loadLevel = GetComponent<LoadLevel>();
    }

    private void OnDisable()
    {
       // ButtonHandle.OnLevelButtonClicked -= OnCreateListBox;
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

}
