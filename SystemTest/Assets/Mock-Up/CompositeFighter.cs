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

    public bool IsEnemy;

    public bool IsDodgingRight;
    public bool IsDodgingLeft;
    public bool IsDodgingUp;
    public bool IsDodgingDown;

    public bool IsAttackingRight;
    public bool IsAttackingLeft;
    public bool IsAttackingUp;
    public bool IsAttackingDown;

    public AudioSource _Audio;
    public AudioClip _miss, _KO;

    public GameObject[] RarmsHitSpark;
    public GameObject[] LarmsHitSpark;
    public GameObject[] LegsHitSpark;
    public GameObject[] HeadHitSpark;

    public GameObject RarmCrash;
    public GameObject LarmCrash;
    public GameObject LegsCrash;
    public GameObject HeadCrash;

    public GameObject RarmSpark;
    public GameObject LarmSpark;
    public GameObject LegsSpark;
    public GameObject HeadSpark;

    public int OverAllHealth;
    public float RarmHealth;
    public float LarmHealth;
    public float LegsHealth;
    public float HeadHealth;

    Animator anim;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        if(!IsEnemy)
        {
           Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
           Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
           Leg = LegCollection[LifeTraker.Instance.LegsIndex];
           Head = HeadCollection[LifeTraker.Instance.HeadIndex];
           RarmHealth = Rarm.life;
           LarmHealth = Larm.life;
           LegsHealth = Leg.life;
           HeadHealth = Head.life;
           Rarm.ActiveParts();
           Larm.ActiveParts();
           Leg.ActiveParts();
           Head.ActiveParts();
           LifeTraker.Instance.pRight = RarmHealth;
           LifeTraker.Instance.pLeft = LarmHealth;
           LifeTraker.Instance.pLegs = LegsHealth;
           LifeTraker.Instance.pHead = HeadHealth;   
        }
        else
        {
            RarmHealth = Rarm.life;
            LarmHealth = Larm.life;
            LegsHealth = Leg.life;
            HeadHealth = Head.life;
            LifeTraker.Instance.eRight = RarmHealth;
            LifeTraker.Instance.eLeft = LarmHealth;
            LifeTraker.Instance.eLegs = LegsHealth;
            LifeTraker.Instance.eHead = HeadHealth;
        }
        Set();
    }

    public void Set()
    {
        if (!IsEnemy)
        { 
            RarmHealth = LifeTraker.Instance.pRight;
            LarmHealth = LifeTraker.Instance.pLeft;
            LegsHealth = LifeTraker.Instance.pLegs;
            HeadHealth = LifeTraker.Instance.pHead;
        }else
        {
            RarmHealth = LifeTraker.Instance.eRight;
            LarmHealth = LifeTraker.Instance.eLeft;
            LegsHealth = LifeTraker.Instance.eLegs;
            HeadHealth = LifeTraker.Instance.eHead;
        }
    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A)) LArmattack();
        if(Input.GetKeyUp(KeyCode.D)) RArmattack();
        if(Input.GetKeyUp(KeyCode.S)) Legattack();
        if(Input.GetKeyUp(KeyCode.W)) Headattack();
    }

    public void DodgeRight()
    {
        IsDodgingRight=true;
        //animeDodgeRight
    }
    public void DodgeLeft()
    {
        IsDodgingLeft = true;
        //animeDodgeRight
    }
    public void DodgeUp()
    {
        IsDodgingUp = true;
        //animeDodgeRight
    }
    public void DodgeDown()
    {
        IsDodgingDown = true;
        //animeDodgeRight
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

    public void CheckAttack(CompositeFighter attacker)
    {
        if (attacker.IsAttackingRight) RightDamage(attacker.Rarm.Damage, attacker.Rarm.AttackSound);
        if(attacker.IsAttackingLeft) LeftDamage(attacker.Larm.Damage, attacker.Larm.AttackSound);
        if (attacker.IsAttackingUp) HeadDamage(attacker.Head.Damage, attacker.Head.AttackSound);
        if (attacker.IsAttackingDown) LegsDamage(attacker.Leg.Damage, attacker.Leg.AttackSound);
    }

    public void RightDamage(int damege, AudioClip hit)
    {
        if (IsDodgingRight)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        _Audio.PlayOneShot(hit);
        RarmHealth -= damege;
        if (RarmHealth <= 0)
        {
            Rarm.DeActiveParts();
        }
        BattleHealth(damege);
    }
    public void LeftDamage(int damege, AudioClip hit)
    {

    }
    public void LegsDamage(int damege, AudioClip hit)
    {

    }
    public void HeadDamage(int damege, AudioClip hit)
    {

    }

    public void BattleHealth(int damage)
    {
        OverAllHealth-= damage;
        if(OverAllHealth<=0)
        {
            //anim.Ko
        }
    }

}
