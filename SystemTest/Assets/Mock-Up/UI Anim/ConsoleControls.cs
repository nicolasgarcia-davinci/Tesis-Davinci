using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControls : MonoBehaviour
{
    public Animator Controls;

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
    }
    public void ClickLeft()
    {
        Controls.SetTrigger("ClickLeft");
    }
    public void ClickUp()
    {
        Controls.SetTrigger("ClickUp");
    }
    public void ClickDown()
    {
        Controls.SetTrigger("ClickDown");
    }
    public void ClickSpace()
    {
        Controls.SetTrigger("ClickSpace");
    }
    public void ClickE()
    {
        Controls.SetTrigger("ClickE");
    }
    public void ConsoleExit()
    {
        Controls.SetTrigger("Exit");
    }
    public void EndScreen()
    {
        gameObject.SetActive(false);
    }
}
