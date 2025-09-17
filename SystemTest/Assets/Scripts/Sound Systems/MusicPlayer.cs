using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    public AudioSource MP;

    public AudioClip _inicialClip;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this);
    }
    void Start()
    {
        MP.PlayOneShot(_inicialClip);
    }

    public void ChangeTrack(AudioClip clip)
    {
        MP.PlayOneShot(clip);
    }
}
