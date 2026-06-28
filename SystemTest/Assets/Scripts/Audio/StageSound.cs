using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class StageSound : MonoBehaviour
{
    public static StageSound instance;
    public AudioMixer GameMixer;
    public AudioSource Musicplayer;
    public AudioClip StageMusic;
    [Range(.02f, 1f)] public float InicialMasterAudio;
    [Range(.02f, 1f)] public float InicialMusicAudio;
    [Range(.02f, 1f)] public float InicialSoundAudio;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Musicplayer.PlayOneShot(StageMusic);
        GameMixer.SetFloat("MasterVolume", Mathf.Log10(InicialMasterAudio) * 20);
        GameMixer.SetFloat("MusicVolume", Mathf.Log10(InicialMusicAudio) * 20);
        GameMixer.SetFloat("SoundsVolume", Mathf.Log10(InicialSoundAudio) * 20);
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
