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


    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition zamiast globalnej, bo obiekt ma rodzica
        m_startPosition = transform.localPosition;
        m_startScale = transform.localScale;
        StartCoroutine(BeachBallCoroutine());
    }

    IEnumerator BeachBallCoroutine()
    {
        // zamiast tworzyc nowy obiekt WaitForSeconds za kazdym razem, gdy wywoluje yield return new WaitForSeconds(1.0f), tworze go tylko raz i przechowuje w zmiennej wait. 
        WaitForSeconds wait = new WaitForSeconds(1.0f);
        while (true)
        {
            /* obliczam wartosc jednorazowo a potem uzywam zmiennej 
             minimalizacja zbednych operacji w petlli i tworzenia nowych obiektow */
           
            float pingPongValue = Mathf.PingPong(Time.time, Amplitude) - Amplitude * 0.5f;
            m_curYPos = pingPongValue;
            transform.localPosition = new Vector3(m_startPosition.x, m_startPosition.y + m_curYPos, m_startPosition.z);

            m_curZRot += Time.deltaTime * RotationSpeed;
            transform.localRotation = Quaternion.Euler(0, 0, m_curZRot);

            float scaleValue = pingPongValue;
            transform.localScale = new Vector3(m_startScale.x + scaleValue, m_startScale.y + scaleValue, m_startScale.z);

            yield return wait;
        }
    }

    void Destroy()
    {
        StopAllCoroutines();
    }
  
}
