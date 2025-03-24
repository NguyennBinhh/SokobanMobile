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
    }
    private void Start()
    {
        this.buttonUp.onClick.AddListener(this.MoveUp);
        this.buttonDown.onClick.AddListener(this.MoveDown);
        this.buttonLeft.onClick.AddListener(this.MoveLeft);
        this.buttonRight.onClick.AddListener(this.MoveRight);
    }

    public void MoveUp() => PlayerInputEvent.TriggerMove(new Vector2(0, 0.64f));
    public void MoveDown() => PlayerInputEvent.TriggerMove(new Vector2(0, -0.64f));
    public void MoveRight() => PlayerInputEvent.TriggerMove(new Vector2(0.64f, 0));
    public void MoveLeft() => PlayerInputEvent.TriggerMove(new Vector2(-0.64f, 0));
}
