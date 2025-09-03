using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCordination : MonoBehaviour
{

    public Color color1;
    public Color color2;

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
