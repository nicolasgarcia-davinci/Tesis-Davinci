using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Image MLifeBar;
    public Image ASpeedBar;
    public TextMeshProUGUI ParteName;
    
    public void SetDisplay(float life, float speed, string name)
    {
        ParteName.text = name;
        MLifeBar.fillAmount = life/100;
        ASpeedBar.fillAmount = speed/100;
    }
}
