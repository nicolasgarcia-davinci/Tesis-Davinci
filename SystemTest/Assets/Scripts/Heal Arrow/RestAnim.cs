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
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
        SetBody();
        InputCheker.Instance.player=this;
    }

    public void SetBody()
    {
        if (LifeTraker.Instance.pRight > 0)
        {
            Rarm.ActiveParts();
        }
        if (LifeTraker.Instance.pLeft > 0)
        {
            Larm.ActiveParts();
        }
        if (LifeTraker.Instance.pLegs > 0)
        {
            Leg.ActiveParts();
        }
        if (LifeTraker.Instance.pHead > 0)
        {
            Head.ActiveParts();
        }
    }
    public void GoToFight()
    {
        StageCam.Instance.GoToFightCamFromRepair();
    }

    public void SetRepairUp()
    {
        //Anim.SetBool("RepairUp", true);
        HeadGlich.SetActive(true);
    }
    public void SetRepairRight()
    {
       // Anim.SetBool("RepairRight", true);
        RightArmGlich.SetActive(true);
    }
    public void SetRepairLeft()
    {
        //Anim.SetBool("RepairLeft", true);
        LeftArmGlich.SetActive(true);
    }
    public void SetRepairDown()
    {
        //Anim.SetBool("RepairDown", true);
        LegsGlich.SetActive(true);
    }
    public void ResetRepair()
    {
        //Anim.SetBool("RepairUp", false);
        //Anim.SetBool("RepairRight", false);
        //Anim.SetBool("RepairLeft", false);
        //Anim.SetBool("RepairDown", false);
        RightArmGlich.SetActive(false);
        LeftArmGlich.SetActive(false);
        LegsGlich.SetActive(false);
        HeadGlich.SetActive(false);
    }

    public void CallCam()
    {
        StageCam.Instance.GoToFightCamFromRepair();
    }
}
