using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : InteractiveComponent
{
    private ParticleSystem t_particles;
    private AudioSource t_audioSource;
    public AudioClip CollisionSound;
    private Rigidbody2D m_rigidbody;
    private Vector3 m_startPosition;
    private Quaternion m_startRotation;

    protected override void MakeSound() { }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Debug.Log("it works");
            t_particles.Play();
            MakeSound();
            {
                t_audioSource.PlayOneShot(CollisionSound);
            }
        }
    

    }

    protected override void DoPlay()
    {
        m_rigidbody.simulated = true;
    }


    protected override void DoPause()
    {
        m_rigidbody.simulated = false;
    }
    protected override void OnDestroy() { }
    public override void DoRestart()
    {
        transform.position = m_startPosition;
        transform.rotation = m_startRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        t_particles = GetComponentInChildren<ParticleSystem>();
        t_audioSource = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();

        OnStart();

        m_startPosition = transform.position;
        m_startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
