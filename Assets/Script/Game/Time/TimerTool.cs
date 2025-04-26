using JetBrains.Annotations;
using UnityEngine;

public class TimerTool : MonoBehaviour
{
    //public float remainingTime;
    public float elapsedTime = 0;
    public float Timer()
    {
        elapsedTime += Time.deltaTime;
        return elapsedTime;
    }

    public void Cooldown(float remainingTime)
    {
        if(remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
    }
}
