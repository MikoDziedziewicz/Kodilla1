using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private ParticleSystem t_particles;
    private AudioSource t_audioSource;
    public AudioClip CollisionSound;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Debug.Log("it works");
            t_particles.Play();
            t_audioSource.PlayOneShot(CollisionSound);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        t_particles = GetComponentInChildren<ParticleSystem>();
        t_audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
