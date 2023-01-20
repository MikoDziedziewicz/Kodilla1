using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallLevitate : MonoBehaviour
{
    private Vector3 m_startPosition;
    private Vector3 m_startScale;
    private float m_curYPos = 0.0f;
    private float m_curZRot = 0.0f;
    public float Amplitude = 1.0f;
    public float RotationSpeed = 50;

    float m_curScale = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_startPosition = transform.position;

        m_startScale = transform.localScale;

        StartCoroutine(BeachBallCoroutine());
    }

    IEnumerator BeachBallCoroutine()
    {
        while (true)
        {
            m_curYPos = Mathf.PingPong(Time.time, Amplitude) - Amplitude * 0.5f;
            transform.position = new Vector3(m_startPosition.x,
                                             m_startPosition.y + m_curYPos,
                                             m_startPosition.z);

            m_curZRot += Time.deltaTime * RotationSpeed;
            transform.rotation = Quaternion.Euler(0, 0, m_curZRot);

            m_curScale = Mathf.PingPong(Time.time, Amplitude) - Amplitude * 0.5f;
            transform.localScale = new Vector3(m_startScale.x + m_curScale, m_startScale.y + m_curScale, m_startScale.z);

            yield return new WaitForSeconds(1.0f);
        }
    }

    void Destroy()
    {
        StopAllCoroutines();
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
