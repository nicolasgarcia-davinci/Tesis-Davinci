using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsToPaint : MonoBehaviour
{
    public List<Part> PtP;
    public void PaintThem()
    {
        foreach (var part in PtP)
        {
            part.SetColor();
        }
    }
}
