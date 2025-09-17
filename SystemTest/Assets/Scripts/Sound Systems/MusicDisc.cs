using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDisc : MonoBehaviour
{
    public AudioClip SceneTrack;
    void Start()
    {
        MusicPlayer.Instance.ChangeTrack(SceneTrack);
    }
}
