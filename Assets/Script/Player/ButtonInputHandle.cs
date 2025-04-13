using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInputHandle : MonoBehaviour
{

    [SerializeField] private Button buttonUp;
    [SerializeField] private Button buttonDown;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button buttonReMove;

    private void Awake()
    {
        if(this.buttonUp == null)
            this.buttonUp = GameObject.Find("ButtonUp").GetComponent<Button>();

        if(this.buttonDown == null)
            this.buttonDown = GameObject.Find("ButtonDown").GetComponent<Button>();

        if (this.buttonLeft == null)
            this.buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();

        if (this.buttonRight == null)
            this.buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();

        if (this.buttonReMove == null)
            this.buttonReMove = GameObject.Find("ButtonReMove").GetComponent<Button>();
    }
    private void Start()
    {
        this.buttonUp.onClick.AddListener(this.MoveUp);
        this.buttonDown.onClick.AddListener(this.MoveDown);
        this.buttonLeft.onClick.AddListener(this.MoveLeft);
        this.buttonRight.onClick.AddListener(this.MoveRight);
        this.buttonReMove.onClick.AddListener(this.ReMove);
    }

    public void MoveUp() => PlayerInputEvent.TriggerMove(Vector2.up);
    public void MoveDown() => PlayerInputEvent.TriggerMove(Vector2.down);
    public void MoveRight() => PlayerInputEvent.TriggerMove(Vector2.right);
    public void MoveLeft() => PlayerInputEvent.TriggerMove(Vector2.left);
    public void ReMove() => PlayerInputEvent.PlayerReMove();
}
