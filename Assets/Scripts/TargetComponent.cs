using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private ParticleSystem t_particles;
    private AudioSource t_audioSource;
    public AudioClip CollisionSound;
    private Rigidbody2D m_rigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Debug.Log("it works");
            t_particles.Play();
            t_audioSource.PlayOneShot(CollisionSound);
        }

    }

    private void DoPlay()
    {
        m_rigidbody.simulated = true;
    }


    private void DoPause()
    {
        m_rigidbody.simulated = false;
    }
    void OnDestroy()
    {
        GameplayManager.OnGamePaused -= DoPause;
        GameplayManager.OnGamePlaying -= DoPlay;
    }


    // Start is called before the first frame update
    void Start()
    {
        t_particles = GetComponent<ParticleSystem>();
        t_audioSource = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();

        GameplayManager.OnGamePaused += DoPause;
        GameplayManager.OnGamePlaying += DoPlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
