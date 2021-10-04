using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
            s.AudioSource.loop = s.Loop;
        }
    }

    private void Start()
    {
        Play("BackgroundTheme");
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            return;
        }
        s.AudioSource.Play();
    }
    
    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            return;
        }
        s.AudioSource.Stop();
    }
}
