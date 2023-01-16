using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button ResumeButton;
    public Button QuitButton;
    public GameObject Panel;


    public void SetPanelVisible(bool visible)
    {
        Panel.SetActive(visible);
    }

    private void OnPause()
    {
        SetPanelVisible(true);
    }

    private void OnResume()
    {
        GameplayManager.Instance.GameState = GameplayManager.EGameState.Playing;

        SetPanelVisible(false);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(delegate { OnResume(); });
        QuitButton.onClick.AddListener(delegate { OnQuit(); });

        SetPanelVisible(false);

        GameplayManager.OnGamePaused += OnPause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
