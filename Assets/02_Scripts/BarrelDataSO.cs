using UnityEngine;

[CreateAssetMenu(fileName = "BarrelDataSO", menuName = "Scriptable Objects/BarrelDataSO")]
public class BarrelDataSO : ScriptableObject
{
    public AudioClip expAudioClip;
    public GameObject effectPrefab;
    public Texture[] textures;
}
