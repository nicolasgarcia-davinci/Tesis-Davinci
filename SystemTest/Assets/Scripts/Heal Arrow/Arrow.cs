using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{

    public bool IsUp;
    public bool IsDown;
    public bool IsRight;
    public bool IsLeft;
    public Image theSprite;

    public Color Normal;
    public Color Correct;
    public Color Wrong;

    public void ChangeToCorrect()
    {
        theSprite.color = Correct;
    }
    public void ChangeToWrong()
    {
        theSprite.color = Wrong;
    }
    public void ChangeToNormal()
    {
        theSprite.color = Normal;
    }
}
