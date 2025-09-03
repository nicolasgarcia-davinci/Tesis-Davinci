using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public ButtomAction[] _menu;
    public MenuControler _controler;
    public int ID;
    public int Index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) CycleUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) CycleDown();
    }
    public void Menu(int target)
    {
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
