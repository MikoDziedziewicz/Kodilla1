using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : Singleton<SaveManager>
{
    public GameSaveData SaveData;
    private string m_pathBin;
    private string m_pathJSON;
    public bool UseBinary = true;

    private void ApplySettings()
    {
        AudioListener.volume = SaveData.m_masterVolume;
    }
    public void SaveSettings()
    {
        if (UseBinary)
        {
            FileStream file = new FileStream(m_pathBin, FileMode.OpenOrCreate);
            BinaryFormatter binFormat = new BinaryFormatter();
            binFormat.Serialize(file, SaveData);
            file.Close();
        }
        else
        {
            string saveData = JsonUtility.ToJson(SaveData);
            File.WriteAllText(m_pathJSON, saveData);
        }

        SaveData.m_overallTime += SaveData.m_timeSinceLastSave;
        Debug.Log("Saving overall time value: " + SaveData.m_overallTime);
        PlayerPrefs.SetFloat("OverallTime", SaveData.m_overallTime);
        SaveData.m_timeSinceLastSave = 0.0f;

        SaveData.LifetimeHits += SaveData.hitsSinceLastSave;
        Debug.Log("Saving lifetime hits value: " + SaveData.LifetimeHits);
        PlayerPrefs.SetInt("LifetimeHits", SaveData.LifetimeHits);
        SaveData.hitsSinceLastSave = 0;

    }

    public void LoadSettings()
    {

        SaveData.m_overallTime = PlayerPrefs.GetFloat("OverallTime", 0.0f);
        Debug.Log("Loaded overall time value: " + SaveData.m_overallTime);

        SaveData.LifetimeHits = PlayerPrefs.GetInt("LifetimeHits", 0);
        Debug.Log("Loaded lifetime hits value: " + SaveData.LifetimeHits);

        if (UseBinary && File.Exists(m_pathBin))
        {
            FileStream file = new FileStream(m_pathBin, FileMode.Open);
            BinaryFormatter binFormat = new BinaryFormatter();
            SaveData = (GameSaveData)binFormat.Deserialize(file);
            ApplySettings();
            file.Close();
        }
        else if (!UseBinary && File.Exists(m_pathJSON))
        {
            string saveData = File.ReadAllText(m_pathJSON);
            SaveData = JsonUtility.FromJson<GameSaveData>(saveData);

        }
        else
        {
            SaveData.m_timeSinceLastSave = 0.0f;
            SaveData.hitsSinceLastSave = 0;
            SaveData.m_overallTime = 0;
            SaveData.LifetimeHits = 0;
            SaveData.m_masterVolume = AudioListener.volume;

        }

        }

    public void Start()
    {
        m_pathBin = Path.Combine(Application.persistentDataPath, "save.bin");
        m_pathJSON = Path.Combine(Application.persistentDataPath, "save.json");

        SaveData.hitsSinceLastSave = 0;
        SaveData.m_timeSinceLastSave = 0.0f;
        SaveData.m_masterVolume = AudioListener.volume;
        LoadSettings();
        Debug.Log(Application.persistentDataPath);
    }
    private void Update()
    {
        SaveData.m_timeSinceLastSave += Time.deltaTime;
    }
}

[Serializable]
public struct GameSaveData
{
    public float m_timeSinceLastSave;
    public float m_overallTime;
    public int hitsSinceLastSave;
    public int LifetimeHits;
    public float m_masterVolume;

}

