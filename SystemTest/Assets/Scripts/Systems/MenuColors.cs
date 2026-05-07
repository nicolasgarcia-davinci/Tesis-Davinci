using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColors : MonoBehaviour
{
    public SkinnedMeshRenderer body;
    void Start()
    {
        ColorChange();
    }
    void Update()
    {
        ColorChange();
    }
    public void ColorChange()
    {
        Debug.Log("sa");
        body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
        //body.material.SetFloat("_Transparencia", 1);
    }
}
