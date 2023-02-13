using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadSprite
{
 [MenuItem("Tool/Load sprite")]
 private static void LoadAssets()
    {
        SpriteAssetLoader.Instance.LoadSpriteAsset();
    }
}
