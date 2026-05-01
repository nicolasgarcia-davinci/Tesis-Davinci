using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public MenuNavigation[] Menues;
    public AudioRequester _stageTheme;

    void Start()
    {
        //_stageTheme.CallSong();
    }


    void Update()
    {
        
    }

    public void ChangeWindow(int Close, int Open)
    {
        foreach(MenuNavigation menu in Menues)
        {
            if(menu.ID==Close)
            {
                menu.gameObject.SetActive(false);
            }
            if (menu.ID == Open)
            {
                menu.gameObject.SetActive(true);
                menu.act2();
            }
        }
    }
}
