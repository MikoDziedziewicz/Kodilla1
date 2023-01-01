using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallComponent : MonoBehaviour
{

    public float BallSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * BallSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }
            
                

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * BallSpeed;
            transform.localScale = new Vector3(1, -1, 1);
        }
          

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * BallSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
            

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * BallSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }
            

        if (Input.GetKeyDown(KeyCode.Space) & transform.localScale.x < 2)
        {
            transform.localScale = Vector3.one * 2;
        }
        else if (Input.GetKeyDown(KeyCode.Space) & transform.localScale.x != 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}





