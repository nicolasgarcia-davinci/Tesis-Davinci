using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartDisplay : MonoBehaviour
{
    public Material Display;

    public void UpdateDisplay(float Curent, float max)
    {
        Display.SetFloat("_Actual_Life", Curent/max);
    }
}
