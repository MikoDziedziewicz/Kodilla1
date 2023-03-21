using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public ObjectPool TargetPool = new ObjectPool();
    private void Start()
    {
        TargetPool.Init(GameplayManager.Instance.GameDatabase.TargetPrefab, 5);
    }
}
