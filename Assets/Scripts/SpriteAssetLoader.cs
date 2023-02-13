using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssetLoader : MonoBehaviour 
{
    public string spriteAssetName;
    private Sprite spriteToLoad;
    private SpriteRenderer m_spriterenderer;
    
    private void Start()
    {
        m_spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void LoadSpriteAsset()
    {
        spriteToLoad = AssetBundlesManager.Instance.GetSprite(spriteAssetName);
        
        if (spriteToLoad != null)
        {
            m_spriterenderer.sprite = spriteToLoad; 
        }
        else
        {
            Debug.Log("Sprite named " + spriteAssetName + " not found");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadSpriteAsset();
        }
    }
}
