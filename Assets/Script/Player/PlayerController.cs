
using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 origPos;
    private float timeToMove;
    private bool isMoving;

    private PlayerAnimator _playerAnimator;
    
    private void OnEnable() => PlayerInputEvent.OnMoveInput += Move;
    private void OnDisable() => PlayerInputEvent.OnMoveInput -= Move;
    private void Awake()
    {
        this.isMoving = false;
        this.timeToMove = 0.3f;
        if(this._playerAnimator == null)
            this._playerAnimator = GetComponent<PlayerAnimator>();
        
    }
    private void Move(Vector2 direction)
    {
        if(!this.isMoving)
            StartCoroutine(IEnumMovePlayer(direction));
    }

    private IEnumerator IEnumMovePlayer(Vector2 direction)
    {
        this.isMoving = true;
        this.origPos = transform.position;
        float eleptime = 0;
        int index = 0;
        this.targetPos = this.origPos + direction;

        if (direction == new Vector2(0, 0.64f))
            this._playerAnimator.SetTriggerAnim("MoveUp");
        else if (direction == new Vector2(0, -0.64f))
            this._playerAnimator.SetTriggerAnim("MoveDown");
        else if (direction == new Vector2(-0.64f, 0))
            this._playerAnimator.SetTriggerAnim("MoveLeft");
        else if (direction == new Vector2(0.64f, 0f))
            this._playerAnimator.SetTriggerAnim("MoveRight");
        while (eleptime < timeToMove)
        {
            transform.position = Vector2.Lerp(this.origPos, this.targetPos, (eleptime / this.timeToMove));
            eleptime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        this._playerAnimator.SetIdleDirection("Horizontal", direction.x);
        this._playerAnimator.SetIdleDirection("Vertical", direction.y);
        transform.position = this.targetPos;
        this.isMoving = false;
    }    
}