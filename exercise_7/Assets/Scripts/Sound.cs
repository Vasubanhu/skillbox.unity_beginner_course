using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource AudioSource;
    [Range(0f, 1f)] public float Volume;
    [Range(.1f, 1f)] public float Pitch;
    public string Name;
    public AudioClip Clip;   
    public bool Loop;
}
