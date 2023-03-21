using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallComponent : InteractiveComponent
{
    private SpringJoint2D m_connectedJoint;
    private Rigidbody2D m_connectedBody;
    public float SlingStart = 0.5f;
    public float MaxSpringDistance = 2.5f;

    private LineRenderer m_lineRenderer;
    private TrailRenderer m_trailRenderer;

    private bool m_hitTheGround = false;

    private Vector3 c_startPosition;
    private CameraController cameraPosition;

    private Animator m_animator;

    public GameSettingsDatabase GameDatabase;

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
    }
    public override void DoRestart()
    {
        base.DoRestart();
        m_rigidbody.simulated = true;

        m_connectedJoint.enabled = true;
        m_lineRenderer.enabled = true;
        m_trailRenderer.enabled = false;

        SetLineRendererPoints();

        cameraPosition.transform.position = c_startPosition;
    }

    private void OnMouseUp()
    {
        m_rigidbody.simulated = true;
        m_particles.Play();
        MakeSound(GameDatabase.PullSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            m_hitTheGround = true;
            m_animator.enabled = true;
            m_animator.Play(0);
            MakeSound(GameDatabase.ImpactSound);
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

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

        m_audioSource = GetComponent<AudioSource>();

        m_animator = GetComponentInChildren<Animator>();
        m_particles = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(JointCoroutine());  
    }

    #if UNITY_IOS || UNITY_ANDROID
    private void OnTouchDown()
    {
        MakeSound(GameDatabase.PullSound);
    }
    private void OnTouchUp()
    {
        m_rigidbody.simulated = true;
        m_particles.Play();
        MakeSound(GameDatabase.PullSound);
    }
    private void OnTouchDrag()
    {
        m_hitTheGround = false;
        m_rigidbody.simulated = false;
        
        if (Input.touchCount <= 0)
            return;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
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
    }
    #endif

    #if UNITY_IOS || UNITY_ANDROID
    private void UpdateTouch()
    {
        if (Input.touchCount <= 0)
            return;

        switch (Input.touches[0].phase)
        {
            case TouchPhase.Began:
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                            OnTouchDown();
                    }
                }
                break;

            case TouchPhase.Moved:
                {
                    OnTouchDrag();
                }
                break;

            case TouchPhase.Ended:
                {
                    OnTouchUp();
                }
                break;
        };
    }
    #else
    #endif

    // Update is called once per frame
    void Update()
    {
        #if UNITY_IOS || UNITY_ANDROID
        UpdateTouch();
        #endif

        m_trailRenderer.enabled = !m_hitTheGround;
        if (transform.position.x < m_connectedBody.transform.position.x + SlingStart)
        {
            m_trailRenderer.enabled = false;
        }
    }

    IEnumerator JointCoroutine()
    {
        while (true)
        {
            SetLineRendererPoints();
            if (transform.position.x > m_connectedBody.transform.position.x + SlingStart)
            {
                m_connectedJoint.enabled = false;
                m_lineRenderer.enabled = false;
                m_trailRenderer.enabled = true;
            }

            yield return null;
            yield return null;
            
        }
    }
    private void SetLineRendererPoints()
    {
        m_lineRenderer.positionCount = 3;
        Vector2 leftArm = m_connectedBody.position + Vector2.left;
        m_lineRenderer.SetPositions(new Vector3[] { leftArm, transform.position, m_connectedBody.position });
    }

    private void OnMouseDown()
    {
        MakeSound(GameDatabase.PullSound);
    }

}





