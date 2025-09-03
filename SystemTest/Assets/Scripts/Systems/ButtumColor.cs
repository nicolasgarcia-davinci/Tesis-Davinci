using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtumColor : ButtomAction
{
    public Color color;
    public Image colorCatalog;
    public void Awake()
    {
        colorCatalog.color = color;
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) && _isSelected)
        {
            if (_thisType == ButtomType.Color1)
            {
                ColorCordination.Instance.color1= color;
                ChangeMenu();
            }
            if (_thisType == ButtomType.Color2)
            {
                ColorCordination.Instance.color2 = color;
                ChangeMenu();
            }
        }
    }  
}
