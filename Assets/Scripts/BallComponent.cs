using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{

    float minFPS = float.MaxValue;
    float maxFPS = float.MinValue;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
     float currentFPS = 1 / Time.deltaTime;
     
     minFPS = Mathf.Min(minFPS, currentFPS);
     maxFPS = Mathf.Max(maxFPS, currentFPS);

     Debug.Log("FPS: " + currentFPS + " (Min: " + minFPS + ", Max: " + maxFPS + ")");
     

    }




}
