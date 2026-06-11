using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCordination : MonoBehaviour
{
    [Header("Right Colors")]
    public Color Rightcolor1;
    public Color Rightcolor2;

    [Header("Left Colors")]
    public Color Leftcolor1;
    public Color Leftcolor2;

    [Header("Head Colors")]
    public Color Headcolor1;
    public Color Headcolor2;

    [Header("Legs Colors")]
    public Color Legscolor1;
    public Color Legscolor2;

    [Header("Chest Colors")]
    public Color Chestcolor1;
    public Color Chestcolor2;

    [Header("Full Colors")]
    public Color[] Fullcolor1;
    public Color[] Fullcolor2;

    public static ColorCordination Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }
}
