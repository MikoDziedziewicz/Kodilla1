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
    public GameObject panelQuestion;
    public Button YesButton;
    public Button NoButton;
    public Button SaveButton;
    public Button LoadButton;
    private HudController m_HUD;

    public void SetPanelVisible(bool visible)
    {
        Panel.SetActive(visible);
    }

    public void SetPanelQuestionVisible(bool visible)
    {
        panelQuestion.SetActive(visible);
    }

    private void OnPause()
    {
        SetPanelVisible(true);
        m_HUD.PauseButton.enabled = false;
        m_HUD.RestartButton.enabled = false;

    }

    private void OnPlay()
    {
        SetPanelQuestionVisible(false);
        SetPanelVisible(false);
        m_HUD.PauseButton.enabled = true;
        m_HUD.RestartButton.enabled = true;
    }
   
    private void OnResume()
    {
        GameplayManager.Instance.GameState = GameplayManager.EGameState.Playing;
    }

    private void OnRestart()
    {
       GameplayManager.Instance.Restart();
    }

    private void QuestionPopup()
    {
        SetPanelVisible(false);
        SetPanelQuestionVisible(true);
    }

    private void BackToMenu()
    {
        SetPanelVisible(true);
        SetPanelQuestionVisible(false);
    }    
    private void OnQuit()
    {
        SaveManager.Instance.SaveSettings();
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

        ResumeButton.onClick.AddListener(OnResume);
        QuitButton.onClick.AddListener(QuestionPopup);
        RestartButton.onClick.AddListener(OnRestart);
        YesButton.onClick.AddListener(OnQuit);
        NoButton.onClick.AddListener(BackToMenu);
        SaveButton.onClick.AddListener(SaveManager.Instance.SaveSettings);
        LoadButton.onClick.AddListener(SaveManager.Instance.LoadSettings);

        SetPanelVisible(false);
        SetPanelQuestionVisible(false);

        GameplayManager.OnGamePaused += OnPause;
        GameplayManager.OnGamePlaying += OnPlay;

        m_HUD = FindObjectOfType<HudController>();

    }

    private void OnDestroy()
    {
        GameplayManager.OnGamePaused -= OnPause;
        GameplayManager.OnGamePlaying -= OnPlay;
    }
}
