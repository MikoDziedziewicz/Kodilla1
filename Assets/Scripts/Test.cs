using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Singleton<Test>
{
    public List<GameObject> PrefabsList = new List <GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DoTest();
        }
    }

    void DoTest()
    {
        if (PrefabsList.Count == 3)
        {
            Debug.Log("it works");
        }
        else
        {
            Debug.Log("something went wrong");
        }
    }
}
