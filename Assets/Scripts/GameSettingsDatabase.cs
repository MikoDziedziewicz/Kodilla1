
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/Create Game Settings", order = 1)]
public class GameSettingsDatabase : ScriptableObject
{
    [Header("Prefabs")]
    public GameObject TargetPrefab;

    [Header("AudioClips")]
    public AudioClip PullSound;
    public AudioClip ShootSound;
    public AudioClip RestartSound;
    public AudioClip ImpactSound;
}
