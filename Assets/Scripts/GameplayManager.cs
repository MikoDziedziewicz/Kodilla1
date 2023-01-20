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
    private int m_points = 0;
    public Button PauseButton;
    public Button RestartButton;

    
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
                    {
                        if (OnGamePaused != null)
                            OnGamePaused();
                    }
                    break;

                case EGameState.Playing:
                    {
                        if (OnGamePlaying != null)
                            OnGamePlaying();
                    }
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
    }

    /* private void TestThrow()
    {
        throw new NullReferenceException("Test exception");
    }
    */ 

    // Start is called before the first frame update
    void Start()
    {
        /* Cwiczenie - lapanie wyjatku, ktory wyrzuca metoda TestThrow();
        int[] Test = new int[2] { 0, 0 };
        try
        {
            Test[2] = 1;
            TestThrow();
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log("Index Exception: " + e.Message);
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Null Refrence Exception: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.Message);
        }
       */
        // StartCoroutine(FPSCoroutine());
        // StartCoroutine(TestCoroutine());

        // TestAsync();

        m_state = EGameState.Playing;
        GetAllRestartableObjects();

        m_HUD = FindObjectOfType<HudController>();
        Points = 0;
    }

    /*IEnumerator FPSCoroutine()
    {
        Debug.Log("Starting TestCoroutine");
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            Debug.Log("FPS: " + (Time.frameCount / Time.time));
            yield return new WaitForSeconds(0.5f);
        }
    } */
    /*async void TestAsync()
    {
        Debug.Log("Starting async method");
        while (true)
        {
            Debug.Log("FPS: " + Time.frameCount / Time.time);
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
    */

    /* IEnumerator TestCoroutine()
    {
        Debug.Log("Starting coroutine method");
        yield return new WaitForSeconds(3);
        Debug.Log("Coroutine done after 3 seconds");
    }
    */

    void Destroy()
    {
        StopAllCoroutines();
    }
    

    public void Restart()
    {
        foreach (var restartableObject in m_restartableObjects)
            restartableObject.DoRestart();
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
        if (Input.GetKeyUp(KeyCode.Space))
            PlayPause();
        if (Input.GetKeyUp(KeyCode.R))
            Restart();
        if (Input.GetKeyUp(KeyCode.Escape))
            PlayPause();

    }

}
