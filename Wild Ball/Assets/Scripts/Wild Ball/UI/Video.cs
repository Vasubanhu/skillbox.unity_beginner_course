using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private VideoPlayer _videoplayer;

    private void Awake()
    {
        _videoplayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
    }

    public void Play() => _videoplayer.Play();
    
    public void Stop() => _videoplayer.Pause();
}
