using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : Singleton<PauseMenuController>
{
    public Button ResumeButton;
    public Button QuitButton;
    public Button RestartButton;
    public GameObject Panel;


    public void SetPanelVisible(bool visible)
    {
        Panel.SetActive(visible);
    }

    private void OnPause()
    {
        SetPanelVisible(true);
    }
    private void OnPlay()
    {
        SetPanelVisible(false);
    }

    private void OnResume()
    {
        GameplayManager.Instance.GameState = GameplayManager.EGameState.Playing;
        //SetPanelVisible(false);
    }

    private void OnRestart()
    {
       GameplayManager.Instance.Restart();
       //SetPanelVisible(false);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(OnResume);
        QuitButton.onClick.AddListener(OnQuit);
        RestartButton.onClick.AddListener(OnRestart);
        SetPanelVisible(false);

        GameplayManager.OnGamePaused += OnPause;
        GameplayManager.OnGamePlaying += OnPlay;
    }

    private void OnDestroy()
    {
        GameplayManager.OnGamePaused -= OnPause;
        GameplayManager.OnGamePlaying -= OnPlay;
    }


}
