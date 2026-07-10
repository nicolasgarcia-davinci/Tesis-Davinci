using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public ButtomAction[] _menu;
    public MenuControler _controler;
    public int ID;
    public int Index;
    public bool hasEnter;
    void Start()
    {
        foreach (var menu in _menu)
        {
            menu.DeSelect();  
        }
    }

    public void Zero()
    {
        foreach (var menu in _menu)
        {
            menu.DeSelect();
        }
        hasEnter = false;
        Index=0;
        //act2();
    }

    void Update()
    {
        if(!hasEnter)
        {
            hasEnter = true;
            act2();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) CycleUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) CycleDown();
    }
    public void act1()
    {
        _menu[0].DeSelect();
    }
    public void act2()
    {
        _menu[0].Select();
    }
    public void Menu(int target)
    {
        Zero();
        _controler.ChangeWindow(ID,target);
    }

    public void CycleUp()
    {
        Index--;
        if (Index < 0) Index = _menu.Length-1;
        foreach(ButtomAction button in _menu)
        {
            if (button == _menu[Index])
            {
                button.Select();
            }
            else button.DeSelect();
        }
    }
    public void CycleDown()
    {
        Index++;
        if (Index > _menu.Length-1) Index =0;
        foreach (ButtomAction button in _menu)
        {
            if (button == _menu[Index])
            {
                button.Select();
            }
            else button.DeSelect();
        }
    }
}
