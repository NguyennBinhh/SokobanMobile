using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textTimer;
    [SerializeField] protected TextMeshProUGUI textStep;
    [SerializeField] protected TextMeshProUGUI textLevelLVup;
    [SerializeField] protected TextMeshProUGUI textTimerLVup;
    [SerializeField] protected TextMeshProUGUI textStepsLVup;
    [SerializeField] protected GameObject highScore;
    [SerializeField] protected GameObject formLevelUp;

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

    public void UpdateUiLevelUp(float level, float timer, float steps)
    {
        this.textLevelLVup.text = level.ToString();
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        this.textTimerLVup.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        this.textStepsLVup.text = steps.ToString();
    }

    public void IsHighScore(bool check)
    {
        this.highScore.SetActive(check);
    }

    public void SetActiveFormLevelUp(bool check)
    {
        this.formLevelUp.SetActive(check);
    }

}
