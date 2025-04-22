using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{

    private Vector2 targetPos;
    private Vector2 origPos;
    public static Action OnBoxMoved;
    public IEnumerator IEnumMoveBox(Vector2 direction)
    {
        float eleptime = 0;
        this.origPos = transform.position;
        this.targetPos = this.origPos + direction;
        while (eleptime < 0.25f)
        {
            transform.position = Vector2.Lerp(origPos, targetPos, (eleptime / 0.25f));
            eleptime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        transform.position = targetPos;
        OnBoxMoved?.Invoke();
    }
}
