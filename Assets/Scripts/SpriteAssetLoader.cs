using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssetLoader : Singleton<SpriteAssetLoader>
{
    public string assetName;
    private Sprite spriteToLoad;
    private SpriteRenderer m_spriterenderer;
    
    private void Start()
    {
        m_spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void LoadSpriteAsset()
    {
        spriteToLoad = AssetBundlesManager.Instance.GetSprite(assetName);
        
        if (spriteToLoad != null)
        {
            m_spriterenderer.sprite = spriteToLoad;
        }
        else
        {
            Debug.Log("Sprite named  " + assetName + "  not found");
        }
    }

}
