using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Part
{
    public void SetColor()
    {
        foreach (var part in components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", ColorCordination.Instance.Chestcolor1);
            coloring.material.SetColor("_Color_2", ColorCordination.Instance.Chestcolor2);
        }
    }
}
