using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComponent : MonoBehaviour, IRestartableObject
{
    public virtual void DoRestart() { }

    protected virtual void DoPlay(){ }

    protected virtual void DoPause() { }

    protected virtual void OnStart()
    {
        GameplayManager.OnGamePaused += DoPause;
        GameplayManager.OnGamePlaying += DoPlay;
    }

    protected virtual void OnDestroy()
    {
        GameplayManager.OnGamePaused -= DoPause;
        GameplayManager.OnGamePlaying -= DoPlay;
    }
    protected virtual void MakeSound() { }

    
    
}
