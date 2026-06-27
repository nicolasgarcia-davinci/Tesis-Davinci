using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAnim : MonoBehaviour
{
    public Animator Anim;

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

    [Header("Particles")]
    public GameObject HeadGlich;
    public GameObject RightArmGlich;
    public GameObject LeftArmGlich;
    public GameObject LegsGlich;

    void Start()
    {
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Rarm.ActiveParts();
        Rarm.FullColor(ColorCordination.Instance.Rightcolor1, ColorCordination.Instance.Rightcolor2);

        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Larm.ActiveParts();
        Larm.FullColor(ColorCordination.Instance.Leftcolor1, ColorCordination.Instance.Leftcolor2);

        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Leg.ActiveParts();
        Leg.FullColor(ColorCordination.Instance.Legscolor1, ColorCordination.Instance.Legscolor2);

        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
        Head.ActiveParts();
        Head.FullColor(ColorCordination.Instance.Headcolor1, ColorCordination.Instance.Headcolor2);

        Chest = ChestCollection[LifeTraker.Instance.ChestIndex];
        Chest.ActiveParts();
        Chest.FullColor(ColorCordination.Instance.Chestcolor1, ColorCordination.Instance.Chestcolor2);
    }

    public void SetBody()
    {
        ResetRepair();
        CheckParts();
    }

    public void CheckParts()
    {
        if (LifeTraker.Instance.pRight > 0)
        {
            Rarm.ActiveParts();
        }
        else Rarm.DeActiveParts();
        if (LifeTraker.Instance.pLeft > 0)
        {
            Larm.ActiveParts();
        }
        else Larm.DeActiveParts();
        if (LifeTraker.Instance.pLegs > 0)
        {
            Leg.ActiveParts();
        }
        else Leg.DeActiveParts();
        if (LifeTraker.Instance.pHead > 0)
        {
            Head.ActiveParts();
        }
        else Head.DeActiveParts();
    }

    public void ResetRepair()
    {
        RightArmGlich.SetActive(false);
        LeftArmGlich.SetActive(false);
        LegsGlich.SetActive(false);
        HeadGlich.SetActive(false);
    }

    public void RepairUP()
    {
        StartCoroutine(HeadRepairSpark());
    }
    public void RepairDown()
    {
        StartCoroutine(LegsRepairSpark());
    }
    public void RepairRight()
    {
        StartCoroutine(RightRepairSpark());
    }
    public void RepairLeft()
    {
        StartCoroutine(LeftRepairSpark());
    }

    public IEnumerator RightRepairSpark()
    {
        RightArmGlich.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RightArmGlich.SetActive(true);
    }
    public IEnumerator LeftRepairSpark()
    {
        LeftArmGlich.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LeftArmGlich.SetActive(true);
    }
    public IEnumerator LegsRepairSpark()
    {
        LegsGlich.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LegsGlich.SetActive(true);
    }
    public IEnumerator HeadRepairSpark()
    {
        HeadGlich.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        HeadGlich.SetActive(true);
    }
}
