using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AssetBundlesManager : Singleton<AssetBundlesManager>
{
    public string assetBundleName;
    public string assetBundleURL;
    public uint ab1Version;
    private AssetBundle ab;
    private AssetBundle ab1;
    private string [] scenePaths;


    private IEnumerator Start()
    {

        yield return StartCoroutine(LoadAssets(assetBundleName, result => ab = result));
        yield return StartCoroutine(LoadAssetsFromURL());
    }

    private IEnumerator LoadAssets(string name, Action<AssetBundle> bundle)
    {
        AssetBundleCreateRequest abcr;
        string path = Path.Combine(Application.streamingAssetsPath, name);
        abcr = AssetBundle.LoadFromFileAsync(path);
        yield return abcr;
        bundle.Invoke(abcr.assetBundle);
        Debug.LogFormat(abcr.assetBundle == null ? "Failed to Load Asset Bundle : {0}" : "Asset Bundle {0} loaded", name);
    }

    public Sprite GetSprite(string assetName)
    {
        return ab.LoadAsset<Sprite>(assetName);
    }

    private IEnumerator LoadAssetsFromURL()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleURL, ab1Version, 0);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            ab1 = DownloadHandlerAssetBundle.GetContent(uwr);
        }

        Debug.Log(ab1 == null ? "Failed to download Asset Bundle" : "Asset Bundle downloaded");
        Debug.Log("Downloaded bytes : " + uwr.downloadedBytes);
    }

    public void loadScene()
    {
        scenePaths = ab1.GetAllScenePaths();
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }
   
}
