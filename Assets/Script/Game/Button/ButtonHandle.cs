using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
    [SerializeField] protected Button btnPlay;

    private void Awake()
    {
        if(btnPlay == null)
            btnPlay = GameObject.Find("Btn_Play").GetComponent<Button>();
    }

    private void Start()
    {
        this.btnPlay.onClick.AddListener(HandleBtnPlay);
    }

    private void HandleBtnPlay()
    {
        var data = LevelDataManager.instance.GetLevelData(2);
        LevelDataManager.instance.UpdateLevelData(2, Vector3.zero, 0f, false, 0f);
    }
}
