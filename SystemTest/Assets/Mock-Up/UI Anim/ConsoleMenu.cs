using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMenu : MonoBehaviour
{
    public MenuNavigation Menu;
    public Animator Controls;
    public AudioSource KeySounds;
    public AudioClip Enter, Action, Key;
    void Start()
    {
        if(Menu!=null)
        Menu.act1();
    }
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ConsoleAction();
    }
    public void ConsoleEnter()
    {
        KeySounds.PlayOneShot(Enter);
    }

    public void ConsoleAction()
    {
        KeySounds.PlayOneShot(Action);
    }
    public void MenuExit()
    {
        gameObject.SetActive(false);
    }
    public void SetExit()
    {
        KeySounds.PlayOneShot(Key);
        Controls.SetTrigger("Exit");
    }

    public void SetMenu()
    {
        Menu.gameObject.SetActive(true);
        Menu.act2();
    }
}
