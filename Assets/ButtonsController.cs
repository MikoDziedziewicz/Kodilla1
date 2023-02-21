using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public Button loadSprite;
    public Button loadScene;

    // Start is called before the first frame update
    void Start()
    {
        loadSprite.onClick.AddListener(delegate { 
         SpriteAssetLoader.Instance.LoadSpriteAsset(); });

        loadScene.onClick.AddListener(delegate
        {
            AssetBundlesManager.Instance.loadScene();
        });
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
