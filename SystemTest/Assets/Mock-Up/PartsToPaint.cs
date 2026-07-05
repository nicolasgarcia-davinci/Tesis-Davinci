using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsToPaint : MonoBehaviour
{
    public PartSelector PartsOnDisplay;

    public List<Arm> Rarms;
    public List<Arm> Larms;
    public List<Head> Heads;
    public List<Leg> Legs;
    public List<Chest> Chests;

    public void Start()
    {
        Clean();

        Rarms.Add(PartsOnDisplay.rArms[LifeTraker.Instance.RarmIndex]);
        Larms.Add(PartsOnDisplay.lArms[LifeTraker.Instance.LarmIndex]);
        Heads.Add(PartsOnDisplay.heads[LifeTraker.Instance.HeadIndex]);
        Legs.Add(PartsOnDisplay.legs[LifeTraker.Instance.LegsIndex]);
        Chests.Add(PartsOnDisplay.chests[LifeTraker.Instance.ChestIndex]);

        PaintThem();
    }
    public void Clean()
    {
        Rarms = new List<Arm>();
        Larms = new List<Arm>();
        Heads = new List<Head>();
        Legs = new List<Leg>();
        Chests = new List<Chest>();
    }
    public void PaintThem()
    {
        foreach (var part in Rarms)
        {
            part.SetColor();
        }

        foreach (var part in Larms)
        {
            part.SetColor();
        }

        foreach (var part in Heads)
        {
            part.SetColor();
        }

        foreach (var part in Legs)
        {
            part.SetColor();
        }

        foreach (var part in Chests)
        {
            part.SetColor();
        }
    }
}
