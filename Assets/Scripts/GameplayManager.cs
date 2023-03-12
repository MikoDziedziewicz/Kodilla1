using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class GameplayManager : Singleton<GameplayManager>
{
    private HudController m_HUD;
    public int m_points = 0;
    public Button PauseButton;
    public Button RestartButton;

    public GameSettingsDatabase GameDatabase;

    public int Points
    {
        get { return m_points; }
        set
        {
            m_points = value;
            m_HUD.UpdatePoints(m_points);
        }
    }
    public enum EGameState
    {
        Playing,
        Paused
    }

    private EGameState m_state;
    public EGameState GameState
    {
        get { return m_state; }
        set
        {
            m_state = value;
            switch (m_state)
            {
                case EGameState.Paused:
                    if (OnGamePaused != null)
                        OnGamePaused();
                    break;

                case EGameState.Playing:
                    if (OnGamePlaying != null)
                        OnGamePlaying();
                    break;
            }
        }
    }

    public delegate void GameStateCallback();
    public static event GameStateCallback OnGamePaused;
    public static event GameStateCallback OnGamePlaying;

    List<IRestartableObject> m_restartableObjects = new List<IRestartableObject>();

    private void GetAllRestartableObjects()
    {
        m_restartableObjects.Clear();

        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            IRestartableObject[] childrenInterfaces = rootGameObject.GetComponentsInChildren<IRestartableObject>();

            foreach (var childInterface in childrenInterfaces)
                m_restartableObjects.Add(childInterface);
        }

        /*
         * tutaj tez moglbym uzyc petli for zamiast foreach
         for (int i = 0; i < rootGameObjects.Length; i++)
        {
            IRestartableObject[] childrenInterfaces = rootGameObjects[i].GetComponentsInChildren<IRestartableObject>();

            for (int j = 0; j < childrenInterfaces.Length; j++)
                m_restartableObjects.Add(childrenInterfaces[j]);
        }
         */
    }

    // Start is called before the first frame update
    void Start()
    {
        m_state = EGameState.Playing;
        ObjectPool.Instance.Init(GameDatabase.TargetPrefab, 5);
        ObjectPool.Instance.SpawnObject(new Vector3(7.6f, 2.86f, 0), Quaternion.identity);

        GetAllRestartableObjects();

        m_HUD = FindObjectOfType<HudController>();
        Points = 0;
    }
  
    void Destroy()
    {
        StopAllCoroutines();
    }

    public void Restart()
    {
        // wszystkie obiekty restartableObject dziedzicza po tym samym interfejsie, wiec zmieniam typ zmiennej z var na IRestartableObject
        foreach (IRestartableObject restartableObject in m_restartableObjects)
            restartableObject.DoRestart();
        /* moglbym tez zmienic petle z foreach na for, ale nie wiem czy byloby to bardziej wydajne? 
         for (int i = 0; i < m_restartableObjects.Length; i++)
        {
             m_restartableObjects[i].DoRestart();
        }
        */
        Points = 0;
        GameState = EGameState.Playing;
    }

    public void PlayPause()
    {
        switch (GameState)
        {
            case EGameState.Playing: { GameState = EGameState.Paused; } break;
            case EGameState.Paused: { GameState = EGameState.Playing; } break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayPause();
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
        if (Input.GetKeyDown(KeyCode.Escape))
            PlayPause();
    }

}
