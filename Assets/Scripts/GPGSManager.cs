using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour
{ 
    void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);
            }
            else
                Debug.Log("Authentication failed");
        });

        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkI8dSryNUREAIQAQ", 100.0f, success => {
                if (success)
                {
                    Debug.Log("Achievement unlocked!");
                }
                else
                {
                    Debug.Log("Failed to unlock achievement.");
                }
            });
        }
    }
}
