using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    public float scaleUp = 2.0f;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

     

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (transform.localScale.x < 3.0f)
        {
            transform.localScale += scaleUp * Time.deltaTime * Vector3.one;
            Debug.Log(" Time passed: " + timer);
        }

    }

    
}
