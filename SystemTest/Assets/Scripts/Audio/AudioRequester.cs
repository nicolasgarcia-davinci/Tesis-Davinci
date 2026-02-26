using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester : MonoBehaviour
{
    public AudioClip StageMusic;
    void Start()
    {
        StageSound.instance.ChangeDisc(StageMusic);
    }
}
