using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : Part
{
    public void SetColor()
    {
        foreach (var part in components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", ColorCordination.Instance.Legscolor1);
            coloring.material.SetColor("_Color_2", ColorCordination.Instance.Legscolor2);
        }
    }
}
