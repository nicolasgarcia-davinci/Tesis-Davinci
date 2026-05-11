using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAnim : MonoBehaviour
{
    public Animator Anim;
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

    [Header("Particles")]
    public GameObject HeadGlich;
    public GameObject RightArmGlich;
    public GameObject LeftArmGlich;
    public GameObject LegsGlich;

    void Start()
    {
        body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
        body.material.SetFloat("_Transparencia", 1);
        //InputCheker.Instance.player=this;
    }

    public void SetBody()
    {
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
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

    public void CallCam()
    {
        StageCam.Instance.GoToRound2();
    }
}
