using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControls : MonoBehaviour
{
    public Animator Controls;
    public AudioSource KeySounds;
    public AudioClip Key , Accion , Enter;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) ClickUp();
        if(Input.GetKeyDown(KeyCode.DownArrow)) ClickDown();
        if(Input.GetKeyDown(KeyCode.RightArrow)) ClickRight();
        if(Input.GetKeyDown(KeyCode.LeftArrow)) ClickLeft();
        if(Input.GetKeyDown(KeyCode.Space)) ClickSpace();
        if(Input.GetKeyDown(KeyCode.E)) ClickE();
    }
    public void ClickRight()
    {
        Controls.SetTrigger("ClickRight");
        KeySounds.PlayOneShot(Key);
    }
    public void ClickLeft()
    {
        Controls.SetTrigger("ClickLeft");
        KeySounds.PlayOneShot(Key);
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
        KeySounds.PlayOneShot(Accion);
    }
    public void ClickE()
    {
        Controls.SetTrigger("ClickE");
        KeySounds.PlayOneShot(Key);
    }
    public void ConsoleExit()
    {
        Controls.SetTrigger("Exit");
        KeySounds.PlayOneShot(Enter);
    }
    public void ConsoleEnter()
    {
        KeySounds.PlayOneShot(Enter);
    }
    public void EndScreen()
    {
        gameObject.SetActive(false);
    }
}
