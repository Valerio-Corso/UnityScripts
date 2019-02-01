using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MultipleSongsHandler : MonoBehaviour
{
    public AudioSource[] Audio;

    int nextTrack = 0;
    int previousTrack = 0;

    private static MultipleSongsHandler instance = null;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        Audio[0].Play();

        QueueNextTrack();
    }

    void Awake()
    {
        //Keep a single instance of this class always running by destroying any duplicates
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void LateUpdate()
    {
        //When the previous song has ended, queue the next one
        if(!Audio[previousTrack].isPlaying)
        {
            QueueNextTrack();
        }
    }

    void QueueNextTrack()
    {
        previousTrack = nextTrack;
        //next track value, reset to 0 if it exceeds the length
        //Remember that Audio.Length returns the exact value, f.e: 2 audioSource will give you a length of 2
        nextTrack = nextTrack + 1 >= Audio.Length ? 0 : nextTrack + 1;
        //Queue the next song to be played
        Audio[nextTrack].PlayDelayed(Audio[previousTrack].clip.length);
    }
}