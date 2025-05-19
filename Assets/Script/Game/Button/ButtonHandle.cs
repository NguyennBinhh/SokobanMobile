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
    [SerializeField] protected Button btnSetting;
    [SerializeField] protected Button btnHideSetting;
    [SerializeField] protected Button btnExitGame;

    public static event Action<int> OnLevelButtonClicked;
    
    private void Awake()
    {

    }

    private void OnEnable()
    {
        this.btnPlay.onClick.AddListener(this.HandleBtnPlay);
        this.btnCloseChossemap.onClick.AddListener(this.HandleBtnHideForm);
        this.btnPauseGame.onClick.AddListener(this.HandleBtnPause);
        this.btnHidePauseGame.onClick.AddListener(this.HandleBtnHidePause);
        this.btnSetting.onClick.AddListener(this.HandleBtnSetting);
        this.btnHideSetting.onClick.AddListener(this.HandleBtnHideSetting);
        this.btnExitGame.onClick.AddListener(this.HandeBtnExitGame);
    }

    private void OnDisable()
    {
        this.btnPlay.onClick.RemoveAllListeners();
        this.btnCloseChossemap.onClick.RemoveAllListeners();
        this.btnPauseGame.onClick.RemoveAllListeners();
        this.btnHidePauseGame.onClick.RemoveAllListeners();
        this.btnSetting.onClick.RemoveAllListeners();
        this.btnHideSetting.onClick.RemoveAllListeners();
        this.btnExitGame.onClick.RemoveAllListeners();
    }

    private void HandleBtnPlay()
    {
        HeaderUI.Instance.SetActiveFormChosseMap(true);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }

    public void BtnLevelClick(int level)
    {
        //LevelDataManager.instance.LoadData();
        OnLevelButtonClicked?.Invoke(level);
        HandleBtnHideForm();
        AudioManager.Instance.PlaySFX("ButtonClick");
    } 
    
    public void HandleBtnHideForm()
    {
        HeaderUI.Instance.SetActiveFormChosseMap(false);
        AudioManager.Instance.PlaySFX("ButtonClick");
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
        AudioManager.Instance.PlaySFX("ButtonClick");
    }
    public void HandleBtnRePlay()
    {
        HeaderUI.Instance.SetActiveFormLevelUp(false);
        HeaderUI.Instance.SetActiveFormGameOver(false);
        HeaderUI.Instance.SetActiveFormPause(false);
        Time.timeScale = 1;
        GameManager.Instance.ResetLevel();
        GameManager.Instance.UpdateAllBoxColors();
        AudioManager.Instance.PlaySFX("ButtonClick");
    }
    public void HandleBtnNextLevel()
    {
        GameManager.Instance.ResetLevel();
        GameManager.Instance.ResetAllList();
        int nextLevel = PlayerPrefs.GetInt("LevelCurrent") + 1;
        OnLevelButtonClicked?.Invoke(nextLevel);
        Time.timeScale = 1;
        HeaderUI.Instance.SetActiveFormLevelUp(false);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }

    public void HandleBtnPause()
    {
        Time.timeScale = 0;
        HeaderUI.Instance.SetActiveFormPause(true);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }
    public void HandleBtnHidePause()
    {
        Time.timeScale = 1;
        HeaderUI.Instance.SetActiveFormPause(false);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }
    public void HandleBtnSetting()
    {
        HeaderUI.Instance.SetActiveFormSetting(true);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }
    
    public void HandleBtnHideSetting()
    {
        HeaderUI.Instance.SetActiveFormSetting(false);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }

    public void HandleBtnRessume()
    {
        AudioManager.Instance.PlaySFX("ButtonClick");
        Time.timeScale = 1;
        HeaderUI.Instance.SetActiveFormPause(false);
    }

    public void HandeBtnExitGame()
    {
        Application.Quit();
    }    
}
