using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : Singleton<MainMenuController>
{
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button ShopButton;

    public GameObject MainPanel;
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject ShopPanel;

    public void Start()
    {
        PlayButton.onClick.AddListener(delegate { OnPlay(); });
        OptionsButton.onClick.AddListener(delegate { ShowOptions(true); });
        QuitButton.onClick.AddListener(delegate { OnQuit(); });
        ShopButton.onClick.AddListener(delegate { ShowShop(true); });

        SetPanelVisible(true);
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        ShopPanel.SetActive(false);
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

    public void ShowShop(bool bShow)
    {
        ShopPanel.SetActive(bShow);
        MainMenuPanel.SetActive(!bShow);
    }
}
