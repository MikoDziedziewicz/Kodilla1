using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : InteractiveComponent
{
    public GameSettingsDatabase GameDatabase;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            m_particles.Play();
            MakeSound(GameDatabase.ImpactSound);
            GameplayManager.Instance.Points += 1;
            SaveManager.Instance.SaveData.hitsSinceLastSave += 1;
        }

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_audioSource = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_particles = GetComponentInChildren<ParticleSystem>();
        m_startPosition = transform.position;
        m_startRotation = transform.rotation;
    }
}