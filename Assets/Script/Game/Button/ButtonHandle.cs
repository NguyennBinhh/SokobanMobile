using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
    [SerializeField] protected GameObject formChossemap;
    [SerializeField] protected Button btnPlay;
    [SerializeField] protected Button btnCloseChossemap;
    public static event Action<int> OnLevelButtonClicked;
    
    private void Awake()
    {

    }

    private void Start()
    {
        this.btnPlay.onClick.AddListener(HandleBtnPlay);
        this.btnCloseChossemap.onClick.AddListener(HandleBtnHideForm);
    }

    private void HandleBtnPlay()
    {
        this.formChossemap.SetActive(true);
    }

    public void BtnLevelClick(int level)
    {
        //LevelDataManager.instance.LoadData();
        OnLevelButtonClicked?.Invoke(level);
    } 
    
    public void HandleBtnHideForm()
    {
        this.formChossemap.SetActive(false);
    }
}
