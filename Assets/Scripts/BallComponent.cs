using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallComponent : MonoBehaviour
{
    private SpringJoint2D m_connectedJoint;
    private Rigidbody2D m_connectedBody;
    public float SlingStart = 0.5f;
    private Rigidbody2D m_rigidbody;
    public float MaxSpringDistance = 2.5f;

    private LineRenderer m_lineRenderer;
    private TrailRenderer m_trailRenderer;

    private bool m_hitTheGround = false;

    private Vector3 m_startPosition;
    private Quaternion m_startRotation;

    private Vector3 c_startPosition;
    private CameraController cameraPosition;
    public bool IsSimulated()
    {
        return m_rigidbody.simulated;
    }
    private void OnMouseDrag()
    {
        m_hitTheGround = false;
        m_rigidbody.simulated = false;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(worldPos.x, worldPos.y, 0);

        Vector2 newBallPos = new Vector3(worldPos.x, worldPos.y);
        float CurJointDistance = Vector3.Distance(newBallPos, m_connectedBody.transform.position);

        if (CurJointDistance > MaxSpringDistance)
        {
            Vector2 direction = (newBallPos - m_connectedBody.position).normalized;
            transform.position = m_connectedBody.position + direction * MaxSpringDistance;
        }
        else
        {
            transform.position = newBallPos;
        }

        SetLineRendererPoints();
        
    }


    private void OnMouseUp()
    {
        m_rigidbody.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            m_hitTheGround = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_connectedJoint = GetComponent<SpringJoint2D>();
        m_connectedBody = m_connectedJoint.connectedBody;
        
        m_lineRenderer = GetComponent<LineRenderer>();
        m_trailRenderer = GetComponent<TrailRenderer>();

        m_startPosition = transform.position;
        m_startRotation = transform.rotation;

        CameraController component = FindObjectOfType<CameraController>();
        cameraPosition = FindObjectOfType<CameraController>();
        c_startPosition = cameraPosition.transform.position;

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

        if (transform.position.x > m_connectedBody.transform.position.x + SlingStart)
        {
            m_connectedJoint.enabled = false;
            m_lineRenderer.enabled = false;
            m_trailRenderer.enabled = true;

        }

        if (transform.position.x < m_connectedBody.transform.position.x + SlingStart)
        {
            m_trailRenderer.enabled = false;
        }

        m_trailRenderer.enabled = !m_hitTheGround;

        if (Input.GetKeyUp(KeyCode.R))
            Restart();

    }

    private void Restart()
    {
        transform.position = m_startPosition;
        transform.rotation = m_startRotation;

        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = 0.0f;
        m_rigidbody.simulated = true;

        m_connectedJoint.enabled = true;
        m_lineRenderer.enabled = true;
        m_trailRenderer.enabled = false;

        SetLineRendererPoints();

        cameraPosition.transform.position = c_startPosition;
    }

    private void SetLineRendererPoints()
    {
        m_lineRenderer.positionCount = 3;
        Vector2 leftArm = m_connectedBody.position + Vector2.left;
        m_lineRenderer.SetPositions(new Vector3[] { leftArm, transform.position, m_connectedBody.position });
    }    
}





