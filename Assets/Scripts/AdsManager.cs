using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private const string ANDROID_AD_ID = "5180792";
    private bool testMode = true;
    private string bannerID = "banner";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(ANDROID_AD_ID, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    private IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (PlayerPrefs.GetInt("AdsRemoved", 0) != 1)
        {
            Advertisement.Show(bannerID);
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        }
    }
}
