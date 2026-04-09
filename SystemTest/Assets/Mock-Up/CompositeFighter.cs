using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeFighter : MonoBehaviour
{
    public Arm[] RarmCollection;
    public Arm[] LarmCollection;
    public Leg[] LegCollection;
    public Head[] HeadCollection;

    public Arm Rarm;
    public Arm Larm;
    public Leg Leg;
    public Head Head;

    Animator anim;

    
    void Start()
    {
        Set();
        anim = GetComponent<Animator>();
    }

    public void Set()
    {
        Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
        Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
        Leg = LegCollection[LifeTraker.Instance.LegsIndex];
        Head = HeadCollection[LifeTraker.Instance.HeadIndex];
        Rarm.ActiveParts();
        Larm.ActiveParts();
        Leg.ActiveParts();
        Head.ActiveParts();
    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A)) LArmattack();
        if(Input.GetKeyUp(KeyCode.D)) RArmattack();
        if(Input.GetKeyUp(KeyCode.S)) Legattack();
        if(Input.GetKeyUp(KeyCode.W)) Headattack();
    }

    public void LArmattack()
    {
        anim.Play(Larm.AttName);
    }
    public void RArmattack()
    {
        anim.Play(Rarm.AttName);
    }
    public void Legattack()
    {
        anim.Play(Leg.AttName);
    }
    public void Headattack()
    {
        anim.Play(Head.AttName);
    }
}
