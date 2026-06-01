using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRobo : MonoBehaviour
{
    [Header("Part Collection")]
    public Arm[] RarmCollection;
    public Arm[] LarmCollection;
    public Leg[] LegCollection;
    public Head[] HeadCollection;
    public Chest[] ChestCollection;

    [Header("Active Parts")]
    public Arm Rarm;
    public Arm Larm;
    public Leg Leg;
    public Head Head;
    public Chest Chest;
    void Start()
    {
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
        Chest = ChestCollection[LifeTraker.Instance.ChestIndex];

        Rarm.ActiveParts();
        Rarm.SetColor();
        Larm.ActiveParts();
        Larm.SetColor();
        Leg.ActiveParts();
        Leg.SetColor();
        Head.ActiveParts();
        Head.SetColor();
        Chest.ActiveParts();
        Chest.SetColor();
    }
}
