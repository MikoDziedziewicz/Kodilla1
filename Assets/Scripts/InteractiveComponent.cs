using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComponent : MonoBehaviour, IRestartableObject
{
    protected AudioSource m_audioSource;
    protected Vector3 m_startPosition;
    protected Quaternion m_startRotation;
    protected Rigidbody2D m_rigidbody;

    public bool IsSimulated()
    {
        return m_rigidbody.simulated;
    }
    public virtual void DoRestart()
    {
        transform.position = m_startPosition;
        transform.rotation = m_startRotation;
    }

    protected void DoPlay()
    {
        m_rigidbody.simulated = true;
    }

    protected void DoPause() 
    {
        m_rigidbody.simulated = false;
    }

    protected virtual void Start()
    {
        GameplayManager.OnGamePaused += DoPause;
        GameplayManager.OnGamePlaying += DoPlay;
    }

    protected virtual void OnDestroy()
    {
        GameplayManager.OnGamePaused -= DoPause;
        GameplayManager.OnGamePlaying -= DoPlay;
    }
    protected void MakeSound(AudioClip dzwiek) 
    {
        m_audioSource.PlayOneShot(dzwiek);
    }

}
