using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
    [SerializeField] protected Button btnPlay;
    [SerializeField] protected Button btnPauseGame;
    [SerializeField] protected Button btnHidePauseGame;
    [SerializeField] protected Button btnCloseChossemap;
    public static event Action<int> OnLevelButtonClicked;
    
    private void Awake()
    {

    }

    private void OnEnable()
    {
        this.btnPlay.onClick.AddListener(this.HandleBtnPlay);
        this.btnCloseChossemap.onClick.AddListener(this.HandleBtnHideForm);
        this.btnPauseGame.onClick.AddListener(this.HandleBtnPause);
        this.btnHidePauseGame.onClick.AddListener(this.HandleBtnPause);
    }

    private void OnDisable()
    {
        this.btnPlay.onClick.RemoveAllListeners();
        this.btnCloseChossemap.onClick.RemoveAllListeners();
        this.btnPauseGame.onClick.RemoveAllListeners();
        this.btnHidePauseGame.onClick.RemoveAllListeners();
    }

    private void HandleBtnPlay()
    {
        HeaderUI.Instance.SetActiveFormChosseMap(true);
    }

    public void BtnLevelClick(int level)
    {
        //LevelDataManager.instance.LoadData();
        OnLevelButtonClicked?.Invoke(level);
        HandleBtnHideForm();
    } 
    
    public void HandleBtnHideForm()
    {
        HeaderUI.Instance.SetActiveFormChosseMap(false);
    }

    public void HandleBtnHome()
    {
        HeaderUI.Instance.SetActiveFormHome(true);
        HeaderUI.Instance.SetActiveFormLevelUp(false);
        HeaderUI.Instance.SetActiveFormGameOver(false);
        HeaderUI.Instance.SetActiveFormPause(false);
        Time.timeScale = 1;
        GameManager.Instance.ResetLevel();
        GameManager.Instance.ResetAllList();
    }
    public void HandleBtnRePlay()
    {
        HeaderUI.Instance.SetActiveFormLevelUp(false);
        HeaderUI.Instance.SetActiveFormGameOver(false);
        HeaderUI.Instance.SetActiveFormPause(false);
        Time.timeScale = 1;
        GameManager.Instance.ResetLevel();
    }
    public void HandleBtnNextLevel()
    {
        GameManager.Instance.ResetLevel();
        GameManager.Instance.ResetAllList();
        int nextLevel = PlayerPrefs.GetInt("LevelCurrent") + 1;
        OnLevelButtonClicked?.Invoke(nextLevel);
        Time.timeScale = 1;
        HeaderUI.Instance.SetActiveFormLevelUp(false);
    }

    public void HandleBtnPause()
    {
        Time.timeScale = 0;
        HeaderUI.Instance.SetActiveFormPause(true);
    }

    public void HandleBtnRessume()
    {
        Time.timeScale = 1;
        HeaderUI.Instance.SetActiveFormPause(false);
    }
}
