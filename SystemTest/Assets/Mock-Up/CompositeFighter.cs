using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeFighter : MonoBehaviour
{
    [Header ("Part Collection")]
    public Arm[] RarmCollection;
    public Arm[] LarmCollection;
    public Leg[] LegCollection;
    public Head[] HeadCollection;

    [Header("Active Parts")]
    public Arm Rarm;
    public Arm Larm;
    public Leg Leg;
    public Head Head;

    [Header("Enemy?")]
    public bool IsEnemy;

    [Header("Dodge")]
    public bool IsDodgingRight;
    public bool IsDodgingLeft;
    public bool IsDodgingUp;
    public bool IsDodgingDown;

    [Header("Atacks")]
    public bool IsAttackingRight;
    public bool IsAttackingLeft;
    public bool IsAttackingUp;
    public bool IsAttackingDown;

    [Header("Audio")]
    public AudioSource _Audio;
    public AudioClip _miss, _KO;
    
    [Header("Animator")]
    public Animator anim;

    [Header("Sparks Particles")]
    public GameObject[] RarmsHitSpark;
    public GameObject[] LarmsHitSpark;
    public GameObject[] LegsHitSpark;
    public GameObject[] HeadHitSpark;

    [Header("Crash Collection")]
    public GameObject RarmCrash;
    public GameObject LarmCrash;
    public GameObject LegsCrash;
    public GameObject HeadCrash;

    [Header("Bolt Particles")]
    public GameObject RarmSpark;
    public GameObject LarmSpark;
    public GameObject LegsSpark;
    public GameObject HeadSpark;

    [Header("Fighter Health")]
    public float OverAllHealth;
    public float RarmHealth;
    public float LarmHealth;
    public float LegsHealth;
    public float HeadHealth;

    [Header("Body Paint")]
    public SkinnedMeshRenderer Body;

    void Start()
    {
        Body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
        Body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
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
            OverAllHealth = LifeTraker.Instance.pOverHealt;
            RarmHealth = LifeTraker.Instance.pRight;
            LarmHealth = LifeTraker.Instance.pLeft;
            LegsHealth = LifeTraker.Instance.pLegs;
            HeadHealth = LifeTraker.Instance.pHead;
            if(RarmHealth > 0) Rarm.ActiveParts();
            if (LarmHealth > 0) Larm.ActiveParts();
            if (LegsHealth > 0) Leg.ActiveParts();
            if (HeadHealth > 0) Head.ActiveParts();
        }
        else
        {
            OverAllHealth = LifeTraker.Instance.eOverHealt;
            RarmHealth = LifeTraker.Instance.eRight;
            LarmHealth = LifeTraker.Instance.eLeft;
            LegsHealth = LifeTraker.Instance.eLegs;
            HeadHealth = LifeTraker.Instance.eHead;
        }
    }

    public void AnimBools()
    {
        IsDodgingLeft=false; IsDodgingRight=false; IsDodgingDown=false; IsDodgingUp=false;
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
        anim.SetTrigger("DoedgeRight");
    }
    public void DodgeLeft()
    {
        IsDodgingLeft = true;
        anim.SetTrigger("DoedgeLeft");
    }
    public void DodgeUp()
    {
        IsDodgingUp = true;
        anim.SetTrigger("DoedgeUp");
    }
    public void DodgeDown()
    {
        IsDodgingDown = true;
        anim.SetTrigger("DoedgeRight");
    }

    public void LArmattack()
    {
        if(!IsAttackingDown||!IsAttackingLeft||!IsAttackingRight||!IsAttackingUp)
        {
            anim.Play(Larm.AttName);
            IsAttackingLeft=true;
        }    
    }
    public void RArmattack()
    {
        if (!IsAttackingDown || !IsAttackingLeft || !IsAttackingRight || !IsAttackingUp)
        {
            anim.Play(Rarm.AttName);
            IsAttackingRight = true;
        }
    }
    public void Legattack()
    {
        if (!IsAttackingDown || !IsAttackingLeft || !IsAttackingRight || !IsAttackingUp)
        { 
            anim.Play(Leg.AttName);
            IsAttackingDown = true;
        }
    }
    public void Headattack()
    {
        if (!IsAttackingDown || !IsAttackingLeft || !IsAttackingRight || !IsAttackingUp)
        {
            anim.Play(Head.AttName);
            IsAttackingUp = true;
        }
    }

    public void CheckAttack(CompositeFighter attacker)
    {
        if (attacker.IsAttackingRight)
        {
            RightDamage(attacker.Rarm.Damage, attacker.Rarm.AttackSound);
            return;
        }
        if (attacker.IsAttackingLeft)
        {
            LeftDamage(attacker.Larm.Damage, attacker.Larm.AttackSound);
            return;
        }
        if (attacker.IsAttackingUp)
        {
            HeadDamage(attacker.Head.Damage, attacker.Head.AttackSound);
            return;
        }
        if (attacker.IsAttackingDown)
        { 
            LegsDamage(attacker.Leg.Damage, attacker.Leg.AttackSound);
            return;
        }
    }

    public void RightDamage(int damege, AudioClip hit)
    {
        if (IsDodgingLeft)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.SetTrigger("TakeDamage");
        _Audio.PlayOneShot(hit);
        if(RarmHealth>0)
        RarmHealth -= damege;

        if (RarmHealth <= 0)
        {
            Rarm.DeActiveParts();
        }
        BattleHealth(damege);
    }
    public void LeftDamage(int damege, AudioClip hit)
    {
        if (IsDodgingRight)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.SetTrigger("TakeDamage");
        _Audio.PlayOneShot(hit);
        if (LarmHealth > 0)
            LarmHealth -= damege;

        if (LarmHealth <= 0)
        {
            Larm.DeActiveParts();
        }
        BattleHealth(damege);
    }
    public void LegsDamage(int damege, AudioClip hit)
    {
        if (IsDodgingDown)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.SetTrigger("TakeDamage");
        _Audio.PlayOneShot(hit);
        if (LegsHealth > 0)
            LegsHealth -= damege;

        if (LegsHealth <= 0)
        {
            Leg.DeActiveParts();
        }
        BattleHealth(damege);
    }
    public void HeadDamage(int damege, AudioClip hit)
    {
        if (IsDodgingUp)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.SetTrigger("TakeDamage");
        _Audio.PlayOneShot(hit);
        if (HeadHealth > 0)
            HeadHealth -= damege;

        if (HeadHealth <= 0)
        {
            Head.DeActiveParts();
        }
        BattleHealth(damege);
    }

    public void BattleHealth(int damage)
    {
        OverAllHealth-= damage;
        if(OverAllHealth<=0)
        {
            anim.SetTrigger("KO");
        }
    }

}
