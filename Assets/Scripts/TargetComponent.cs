using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : InteractiveComponent
{
    private ParticleSystem t_particles;
    public AudioClip CollisionSound;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Debug.Log("it works");
            t_particles.Play();
            MakeSound(CollisionSound);
            GameplayManager.Instance.Points += 1;
        }

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        t_particles = GetComponentInChildren<ParticleSystem>();
        m_audioSource = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_startPosition = transform.position;
        m_startRotation = transform.rotation;
    }
}