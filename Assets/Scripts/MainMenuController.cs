using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : Singleton<MainMenuController>
{
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;

    public GameObject MainPanel;
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;

    public void Start()
    {
        PlayButton.onClick.AddListener(delegate { OnPlay(); });
        OptionsButton.onClick.AddListener(delegate { ShowOptions(true); });
        QuitButton.onClick.AddListener(delegate { OnQuit(); });

        SetPanelVisible(true);
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void SetPanelVisible(bool visible)
    {
        MainPanel.SetActive(visible);
    }

    private void OnPlay()
    {
        SetPanelVisible(false);
        GameplayManager.Instance.Restart();
    }

    public void ShowOptions(bool bShow)
    {
        OptionsPanel.SetActive(bShow);
        MainMenuPanel.SetActive(!bShow);
    }

    private void OnQuit()
    {
        Application.Quit();
    }
}
