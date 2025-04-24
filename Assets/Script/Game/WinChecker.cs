using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public static Action LevelSuccess;
    private void OnEnable()
    {
        BoxManager.OnBoxMoved += CheckWinCondition;
    }
    private void OnDisable()
    {
        BoxManager.OnBoxMoved -= CheckWinCondition;
    }
    public void CheckWinCondition()
    {
        if (GameManager.Instance.allBoxes.Count <= 0) return;
        if (GameManager.Instance.allCheckpoints.Count <= 0) return;

        int matchedCount = 0;

        foreach (var checkpoint in GameManager.Instance.allCheckpoints)
        {
            bool hasBox = false;

            foreach (var box in GameManager.Instance.allBoxes)
            {
                if (Vector2.Distance(box.transform.position, checkpoint.transform.position) < 0.1f)
                {
                    hasBox = true;
                    break;
                }
            }

            if (hasBox)
                matchedCount++;
        }
        if (matchedCount == GameManager.Instance.allCheckpoints.Count)
        {
            LevelSuccess?.Invoke();
            Debug.Log("YOU WIN!");
        }
    }
       
}
