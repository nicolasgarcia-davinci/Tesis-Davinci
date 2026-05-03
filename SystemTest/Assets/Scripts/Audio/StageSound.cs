using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StageSound : MonoBehaviour
{
    public static StageSound instance;
    public AudioMixer GameMixer;
    public AudioSource Musicplayer;
    public AudioClip StageMusic;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Musicplayer.PlayOneShot(StageMusic);
    }

    public void ChangeDisc(AudioClip disc)
    {
        Musicplayer.Stop();
        StageMusic=disc;
        Musicplayer.PlayOneShot(StageMusic);
    }
    public void Mute()
    {
        Musicplayer.Stop();
    }

}
