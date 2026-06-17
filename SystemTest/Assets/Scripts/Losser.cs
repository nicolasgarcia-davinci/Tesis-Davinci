using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losser : MonoBehaviour
{
    [Header("Part Collection")]
    public Part[] RarmCollection;
    public Part[] LarmCollection;
    public Part[] LegCollection;
    public Part[] HeadCollection;
    public Part[] ChestCollection;

    [Header("Active Parts")]
    public Part Rarm;
    public Part Larm;
    public Part Leg;
    public Part Head;
    public Part Chest;
    void Start()
    {
        if(LifeTraker.Instance.IsEnemy)
        {
            Rarm.ActiveParts();
            Larm.ActiveParts();
            Leg.ActiveParts();
            Head.ActiveParts();
            Chest.ActiveParts();
        }
        if (!LifeTraker.Instance.IsEnemy)
        {
            Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
            Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
            Leg = LegCollection[LifeTraker.Instance.LegsIndex];
            Head = HeadCollection[LifeTraker.Instance.HeadIndex];
            Chest = ChestCollection[LifeTraker.Instance.ChestIndex];

            Rarm.ActiveParts();
            Rarm.FullColor(ColorCordination.Instance.Rightcolor1, ColorCordination.Instance.Rightcolor2);
            Larm.ActiveParts();
            Larm.FullColor(ColorCordination.Instance.Leftcolor1, ColorCordination.Instance.Leftcolor2);
            Leg.ActiveParts();
            Leg.FullColor(ColorCordination.Instance.Legscolor1, ColorCordination.Instance.Legscolor2);
            Head.ActiveParts();
            Head.FullColor(ColorCordination.Instance.Headcolor1, ColorCordination.Instance.Headcolor2);
            Chest.ActiveParts();
            Chest.FullColor(ColorCordination.Instance.Chestcolor1, ColorCordination.Instance.Chestcolor2);
        }
    }
}
