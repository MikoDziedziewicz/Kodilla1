using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Button BuyButton;
    public Button CancelButton;

    public MainMenuController MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        CancelButton.onClick.AddListener(delegate { OnCancel(); });
        BuyButton.onClick.AddListener(delegate { OnBuy(); });
    }


    private void OnCancel()
    {
        MainMenu.ShowShop(false);
    }

    private void OnBuy()
    {
        if (PlayerPrefs.GetInt("AdsRemoved", 0) !=1 )
        {
            PurchasingManager.Instance.BuyRemoveAds();
            MainMenu.ShowShop(false);
        }
        else
        {
            Debug.Log("You have already bought this product");
        }
    }
}
