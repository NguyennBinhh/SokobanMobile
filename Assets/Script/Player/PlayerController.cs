using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 origPos;
    private float timeToMove;
    private bool isMoving;
    [SerializeField] private List<Vector2> listPossionPlay;

    [SerializeField] private Tilemap tileMapWall;
    [SerializeField] private LayerMask boxLayer;    
    [SerializeField] private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        this.isMoving = false;
        this.timeToMove = 0.25f;
        if (this._playerAnimator == null)
            this._playerAnimator = GetComponent<PlayerAnimator>();
        if (this.tileMapWall == null)
            this.tileMapWall = GameObject.Find("TilemapWall").GetComponent<Tilemap>();
        this.listPossionPlay = new List<Vector2>();
    }

    private void OnEnable()
    {
        PlayerInputEvent.OnMoveInput += Move;
        PlayerInputEvent.OnReMoveInput += ReMove;
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {  
        PlayerInputEvent.OnMoveInput -= Move;
        PlayerInputEvent.OnReMoveInput -= ReMove;

    }
    private void Move(Vector2 direction)
    {
        if (this.isMoving) return;
        CheckMovementAllowed(direction);
    }

    private void ReMove()
    {
        if (this.isMoving) return;
        if (GameManager.Instance.gameStates.Count <= 0) return;
        GameStateData gameState = GameManager.Instance.gameStates.Pop();
        StartCoroutine(IEnumReMovePlayer(gameState.playerPos - (Vector2)transform.position));
        for (int i = 0; i < GameManager.Instance.allBoxes.Count; i++)
        {
            BoxManager box = GameManager.Instance.allBoxes[i];
            StartCoroutine(box.IEnumMoveBox(gameState.boxPositions[i] - (Vector2)box.transform.position));
        }
        GameManager.Instance.steps++;
        HeaderUI.Instance.UpdateUiStep(GameManager.Instance.steps);
    }
  
    private IEnumerator IEnumMovePlayer(Vector2 direction)
    {
        this.isMoving = true;
        this.origPos = transform.position;
        float eleptime = 0;
        this.targetPos = this.origPos + direction;

        if (direction == Vector2.up)
            _playerAnimator.SetTriggerAnim("MoveUp");
        else if (direction == Vector2.down)
            _playerAnimator.SetTriggerAnim("MoveDown");
        else if (direction == Vector2.left)
            _playerAnimator.SetTriggerAnim("MoveLeft");
        else if (direction == Vector2.right)
            _playerAnimator.SetTriggerAnim("MoveRight");

        while (eleptime < timeToMove)
        {
            transform.position = Vector2.Lerp(this.origPos, this.targetPos, (eleptime / this.timeToMove));
            eleptime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.steps--;
        HeaderUI.Instance.UpdateUiStep(GameManager.Instance.steps);
        this._playerAnimator.SetIdleDirection("Horizontal", direction.x);
        this._playerAnimator.SetIdleDirection("Vertical", direction.y);
        transform.position = this.targetPos;
        this.isMoving = false;
        
    }

    private IEnumerator IEnumReMovePlayer(Vector2 direction)
    {
        this.isMoving = true;
        this.origPos = transform.position;
        float eleptime = 0;
        this.targetPos = this.origPos + direction;

        if (direction == Vector2.down)
            _playerAnimator.SetTriggerAnim("MoveUp");
        else if (direction == Vector2.up)
            _playerAnimator.SetTriggerAnim("MoveDown");
        else if (direction == Vector2.right)
            _playerAnimator.SetTriggerAnim("MoveLeft");
        else if (direction == Vector2.left)
            _playerAnimator.SetTriggerAnim("MoveRight");

        while (eleptime < timeToMove)
        {
            transform.position = Vector2.Lerp(this.origPos, this.targetPos, (eleptime / this.timeToMove));
            eleptime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        this._playerAnimator.SetIdleDirection("Horizontal", -direction.x);
        this._playerAnimator.SetIdleDirection("Vertical", -direction.y);
        transform.position = this.targetPos;
        this.isMoving = false;
    }

    private void CheckMovementAllowed(Vector2 direction)
    {
        Vector3 CurrentPos = transform.position;
        Vector3Int CurrentCellPos = tileMapWall.WorldToCell(transform.position);
        Vector3Int NextCellPos = new Vector3Int((int)(CurrentCellPos.x + direction.x), (int)(CurrentCellPos.y + direction.y), 0);
        Vector3Int NextnextCellPos = NextCellPos + new Vector3Int((int)direction.x, (int)direction.y, 0);

        Collider2D BoxCol = HasBox(NextCellPos);

        if (IsWall(NextCellPos))
            return;
   
        else if(BoxCol != null && !IsWall(NextCellPos))
        {
            Collider2D BoxColNext = HasBox(NextnextCellPos);
            if (IsWall(NextnextCellPos))
                return;
            else if (!IsWall(NextnextCellPos) && BoxColNext != null)
                return;
            else
            {
                BoxManager _boxManager = BoxCol.GetComponent<BoxManager>();
                GameManager.Instance.SaveGameState();
                StartCoroutine(_boxManager.IEnumMoveBox(direction));
                StartCoroutine(IEnumMovePlayer(direction));
                return;
            }    
        }
        GameManager.Instance.SaveGameState();
        StartCoroutine(IEnumMovePlayer(direction));
    }  
    private bool IsWall(Vector3Int vector3Int) => this.tileMapWall.HasTile(vector3Int);

    private Collider2D HasBox(Vector3Int vector3Int)
    {
        Vector2 worldBoxPos = tileMapWall.GetCellCenterWorld(vector3Int);
        return Physics2D.OverlapPoint(worldBoxPos, this.boxLayer);
    }

    public void RotatePlayerInFront()
    {
        this._playerAnimator.SetIdleDirection("Vertical", -1);
    }
}