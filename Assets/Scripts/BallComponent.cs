using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallComponent : MonoBehaviour
{
    Rigidbody2D m_rigidbody;

    private void OnMouseDrag()
    {
        m_rigidbody.simulated = false;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(worldPos.x, worldPos.y, 0);
    }

    private void OnMouseUp()
    {
        m_rigidbody.simulated = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameplayManager.Instance.Pause)
        {
            m_rigidbody.simulated = false;

        }
         else
        {
            m_rigidbody.simulated = true;
        }


    }

}





