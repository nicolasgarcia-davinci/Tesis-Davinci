using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public Transform[] drama;

    public static CamPos Instance;

    public int index = 0;

    public void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    public void changePos()
    {
        if (index == drama.Length) return;
        transform.position = drama[index].position;
        transform.rotation = drama[index].rotation;
        index++;
    }
}
