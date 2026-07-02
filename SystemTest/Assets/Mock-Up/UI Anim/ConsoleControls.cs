using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControls : ConsoleMenu
{
    public GameObject MainConsole;
    public bool IsColoring;
    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) ClickUp();
        if(Input.GetKeyDown(KeyCode.DownArrow)) ClickDown();
        if(Input.GetKeyDown(KeyCode.RightArrow)) ClickRight();
        if(Input.GetKeyDown(KeyCode.LeftArrow)) ClickLeft();
        if (Input.GetKeyDown(KeyCode.Space)) ClickSpace();
        if (Input.GetKeyDown(KeyCode.E)) ClickE();
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
        Controls.SetTrigger("ClickUP");
        KeySounds.PlayOneShot(Key);
    }
    public void ClickDown()
    {
        Controls.SetTrigger("ClickDown");
        KeySounds.PlayOneShot(Key);
    }
    
    public void ClickE()
    {
        IsColoring = true;
        Controls.SetTrigger("ClickE");
        KeySounds.PlayOneShot(Key);
    }
    public void ClickSpace()
    {
        Controls.SetTrigger("ClickSpace");
        if (!IsColoring)
            Controls.SetTrigger("Exit");
    }
    public void BackToMain()
    {
        Debug.Log("dada");
        MainConsole.SetActive(true);
    }
}
