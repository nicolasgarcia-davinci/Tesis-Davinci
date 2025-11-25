using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixelation : MonoBehaviour
{
    public Material Pixels;
    public float LD;
    public float HD;
    public static Pixelation Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void Pixelate()
    {
        Pixels.SetFloat("_Number_of_Pixels", LD);
    }
    public void HighDefinition()
    {
        Pixels.SetFloat("_Number_of_Pixels", HD);
    }
}
