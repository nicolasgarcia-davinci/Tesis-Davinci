using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : Part
{
    public bool isLeft;
    public void SetColor()
    {
        foreach (var part in components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            if(isLeft)
            {
                coloring.material.SetColor("_Color_1", ColorCordination.Instance.Leftcolor1);
                coloring.material.SetColor("_Color_2", ColorCordination.Instance.Leftcolor2);
            }
            else 
            {
                coloring.material.SetColor("_Color_1", ColorCordination.Instance.Rightcolor1);
                coloring.material.SetColor("_Color_2", ColorCordination.Instance.Rightcolor2);
            }
        }
    }
}
