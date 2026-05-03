using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester : MonoBehaviour
{
    public AudioClip StageMusic;

    public void CallSong()
    {
        StageSound.instance.ChangeDisc(StageMusic);
    }

    public void EjectDisc()
    {
        StageSound.instance.Mute();
    }
}
