using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionCheckpoint : MonoBehaviour
{
    public void CheckPosstion()
    {
        if (GameManager.Instance.allBoxes.Count <= 0) return;
        if (GameManager.Instance.allCheckpoints.Count <= 0) return;

        foreach (var checkpoint in GameManager.Instance.allCheckpoints)
        {
            foreach (var box in GameManager.Instance.allBoxes)
            {
                if (Vector2.Distance(box.transform.position, checkpoint.transform.position) < 0.1f)
                {
                    this.ChangeStateCloorBox(box);
                }
                else
                {
                    this.ResetStateCloorBox(box);
                }
            }

        }
    }
    public void ChangeStateCloorBox(BoxManager box)
    {
        box.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("chang");
    }

    public void ResetStateCloorBox(BoxManager box)
    {
       box.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
