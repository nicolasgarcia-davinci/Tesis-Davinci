using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealConsole : MonoBehaviour
{
    public Animator Controls;
    public AudioSource KeySounds;
    public AudioClip Key;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ClickSpace();
        if (Input.GetKeyDown(KeyCode.UpArrow)) ClickUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) ClickDown();
    }

    public void ClickUp()
    {
        Controls.SetTrigger("ClickUp");
        KeySounds.PlayOneShot(Key);
    }
    public void ClickDown()
    {
        Controls.SetTrigger("ClickDown");
        KeySounds.PlayOneShot(Key);
    }
    public void ClickSpace()
    {
        Controls.SetTrigger("ClickSpace");
    }


}
