using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{

    public float scaleUpSpeed = 0.025f;
 
    

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" FPS: " + (1 / Time.deltaTime));


        if (transform.localScale.y < 3.0f)
        {
            transform.localScale += Vector3.one * scaleUpSpeed;
        }



    }
}
