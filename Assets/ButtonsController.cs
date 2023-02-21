using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public Button loadSprite;
    public Button loadScene;

    void Start()
    {
        loadSprite.onClick.AddListener(delegate { 
         SpriteAssetLoader.Instance.LoadSpriteAsset(); });

        loadScene.onClick.AddListener(delegate
        {
            AssetBundlesManager.Instance.loadScene();
        });
   
    }

}
