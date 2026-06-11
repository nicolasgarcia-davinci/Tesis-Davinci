using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsToPaint : MonoBehaviour
{
    public List<Arm> Rarms;
    public List<Arm> Larms;
    public List<Head> Heads;
    public List<Leg> Legs;
    public List<Chest> Chests;

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
