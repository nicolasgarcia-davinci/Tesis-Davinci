using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Image[] MLifeBar;
    public Image[] PowerBar;
    public TextMeshProUGUI[] ParteName;
    
    public void SetRarmDisplay(float life, float speed, string name)
    {
        ParteName[0].text = name;
        MLifeBar[0].fillAmount = life/100;
        PowerBar[0].fillAmount = speed/100;
    }
    public void SetLarmDisplay(float life, float speed, string name)
    {
        ParteName[1].text = name;
        MLifeBar[1].fillAmount = life/100;
        PowerBar[1].fillAmount = speed/100;
    }
    public void SetLegDisplay(float life, float speed, string name)
    {
        ParteName[2].text = name;
        MLifeBar[2].fillAmount = life/100;
        PowerBar[2].fillAmount = speed/100;
    }
    public void SetHeadDisplay(float life, float speed, string name)
    {
        ParteName[3].text = name;
        MLifeBar[3].fillAmount = life/100;
        PowerBar[3].fillAmount = speed/100;
    }
    public void SetChestDisplay(float life, float speed, string name)
    {
        ParteName[4].text = name;
        MLifeBar[4].fillAmount = life/100;
        PowerBar[4].fillAmount = speed/100;
    }
}
