using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textTimer;
    [SerializeField] protected TextMeshProUGUI textStep;

    public static HeaderUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateUiTime(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        this.textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }    

    public void UpdateUiStep(int step)
    {
        this.textStep.text = step.ToString();
    }    
}
