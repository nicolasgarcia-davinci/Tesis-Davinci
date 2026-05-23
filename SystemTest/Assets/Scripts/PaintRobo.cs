using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRobo : MonoBehaviour
{
    public SkinnedMeshRenderer body;
    [Header("Part Collection")]
    public Arm[] RarmCollection;
    public Arm[] LarmCollection;
    public Leg[] LegCollection;
    public Head[] HeadCollection;

    [Header("Active Parts")]
    public Arm Rarm;
    public Arm Larm;
    public Leg Leg;
    public Head Head;
    void Start()
    {
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
        Rarm.ActiveParts();
        Larm.ActiveParts();
        Leg.ActiveParts();
        Head.ActiveParts();
        ColorChange();
    }
    public void ColorChange()
    {
        body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
        body.material.SetFloat("_Transparencia", 1f);
    }
}
