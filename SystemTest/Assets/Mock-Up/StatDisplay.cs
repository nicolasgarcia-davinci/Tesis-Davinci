using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Image[] MLifeBar;
    public Image[] PowerBar;
    
    public void SetRarmDisplay(float life, float attack)
    {
        MLifeBar[0].fillAmount = life/100;
        PowerBar[0].fillAmount = attack / 100;
    }
    public void SetLarmDisplay(float life, float attack)
    {
        MLifeBar[1].fillAmount = life/100;
        PowerBar[1].fillAmount = attack / 100;
    }
    public void SetLegDisplay(float life, float attack)
    {
        MLifeBar[2].fillAmount = life/100;
        PowerBar[2].fillAmount = attack / 100;
    }
    public void SetHeadDisplay(float life, float attack)
    {
        MLifeBar[3].fillAmount = life/100;
        PowerBar[3].fillAmount = attack / 100;
    }
    public void SetChestDisplay(float life, float attack)
    {
        MLifeBar[4].fillAmount = life/100;
        PowerBar[4].fillAmount = attack / 100;
    }
}
