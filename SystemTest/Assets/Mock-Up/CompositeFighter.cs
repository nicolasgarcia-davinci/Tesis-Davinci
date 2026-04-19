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

    [Header("Has To Set?")]
    public bool hasBeenSet=false;

    [Header("Eneregy System")]
    public float Stamina;
    public float MaxStamina;
    public float StaminaRefresh;

    [Header("Enemy?")]
    public bool IsEnemy;

    [Header("Dodge")]
    public bool IsDodgingRight;
    public bool IsDodgingLeft;
    public bool IsDodgingUp;
    public bool IsDodgingDown;
    public bool IsDodging;

    [Header("Atacks")]
    public bool IsAttackingRight;
    public bool IsAttackingLeft;
    public bool IsAttackingUp;
    public bool IsAttackingDown;
    public bool IsAttacking;

    [Header("Audio")]
    public AudioSource _Audio;
    public AudioClip _miss, _KO;
    
    [Header("Animator")]
    public Animator anim;

    [Header("Damage Particles")]
    public GameObject RarmsHitSpark;
    public GameObject LarmsHitSpark;
    public GameObject LegsHitSpark;
    public GameObject HeadHitSpark;

    [Header("Crash Collection")]
    public GameObject[] RarmCrash;
    public GameObject[] LarmCrash;
    public GameObject[] LegsCrash;
    public GameObject[] HeadCrash;

    [Header("Spark Particles")]
    public GameObject[] RarmSpark;
    public GameObject[] LarmSpark;
    public GameObject[] LegsSpark;
    public GameObject[] HeadSpark;

    [Header("Bool Particles")]
    public bool HeadBoom;
    public bool RarmBoom;
    public bool LarmBoom;
    public bool LegsBoom;

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
        Stamina = MaxStamina;
        anim = GetComponent<Animator>();
        if(!IsEnemy)
        {
           Body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
           Body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
           Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
           Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
           Leg = LegCollection[LifeTraker.Instance.LegsIndex];
           Head = HeadCollection[LifeTraker.Instance.HeadIndex];
           OverAllHealth = LifeTraker.Instance.pOverHealt;
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
           LifeTraker.Instance.maxHeadHealth = HeadHealth;
           LifeTraker.Instance.maxRarmHealth = RarmHealth;
           LifeTraker.Instance.maxLarmHealth = LarmHealth;
           LifeTraker.Instance.maxLegsHealth = LegsHealth;
        }
        else
        {
            OverAllHealth = LifeTraker.Instance.eOverHealt*(LifeTraker.Instance.Dificulty);
            RarmHealth = Rarm.life;
            LarmHealth = Larm.life;
            LegsHealth = Leg.life;
            HeadHealth = Head.life;
            Rarm.ActiveParts();
            Larm.ActiveParts();
            Leg.ActiveParts();
            Head.ActiveParts();
        }
        //Set();
    }

    public void Set()
    {
        hasBeenSet = true;
        Stamina = MaxStamina;
        if (!IsEnemy)
        { 
            OverAllHealth = LifeTraker.Instance.pOverHealt;

            RarmHealth = LifeTraker.Instance.pRight;
            LarmHealth = LifeTraker.Instance.pLeft;
            LegsHealth = LifeTraker.Instance.pLegs;
            HeadHealth = LifeTraker.Instance.pHead;

            if (RarmHealth > 0)
            {
                RarmBoom = false;
                Rarm.ActiveParts();
            }

            if (LarmHealth > 0)
            {
                LarmBoom = false;
                Larm.ActiveParts();
            }

            if (LegsHealth > 0)
            {
                LegsBoom = false;
                Leg.ActiveParts();
            }

            if (HeadHealth > 0)
            {
                HeadBoom = false;
                Head.ActiveParts();
            }
        }
        else
        {
            OverAllHealth = LifeTraker.Instance.eOverHealt;
        }
    }

    public void ResetBools()
    {
        IsDodgingLeft=false; IsDodgingRight=false; IsDodgingDown=false; IsDodgingUp=false; IsDodging=false;
        IsAttackingLeft=false; IsAttackingRight=false; IsAttackingDown=false; IsAttackingUp=false; IsAttacking=false;
    }
    public void FallDown()
    {
        FightControler.Instance.SetDownFighter(this);
    }

    public void AttackEffect()
    {
        FightControler.Instance.CheckAttack(this);
    }
    public void IAInputCheck()
    {
        FightControler.Instance.IADefender(this);
    }


    void Update()
    {
        if (Stamina < MaxStamina)
        {
            Stamina += StaminaRefresh * Time.deltaTime;
        }
        if (!hasBeenSet) Set();
    }

    public void DodgeRight()
    {
        if (!IsAttacking && !IsDodging)
        { 
            IsDodgingRight=true;
            IsDodging=true;
            anim.SetTrigger("DoedgeRight");
        }
    }
    public void DodgeLeft()
    {
        if (!IsAttacking && !IsDodging)
        {
            IsDodgingLeft = true;
            anim.SetTrigger("DoedgeLeft");
            IsDodging = true;
        }
    }
    public void DodgeUp()
    {
        if (!IsAttacking && !IsDodging)
        {
            IsDodgingUp = true;
            IsDodging = true;
            anim.SetTrigger("DoedgeUp");
        }
    }
    public void DodgeDown()
    {
        if (!IsAttacking && !IsDodging)
        {
            IsDodgingDown = true;
            IsDodging = true;
            anim.SetTrigger("DoedgeRight");
        }  
    }

    public void LArmattack()
    {
        if(!IsAttacking && !IsDodging)
        {
            anim.speed = Stamina / MaxStamina;
            anim.Play(Larm.AttName);
            IsAttackingLeft=true;
            IsAttacking = true;
        }    
    }
    public void RArmattack()
    {
        if (!IsAttacking && !IsDodging)
        {
            anim.speed = Stamina / MaxStamina;
            anim.Play(Rarm.AttName);
            IsAttackingRight = true;
            IsAttacking = true;
        }
    }
    public void Legattack()
    {
        if (!IsAttacking && !IsDodging)
        {
            anim.speed = Stamina / MaxStamina;
            anim.Play(Leg.AttName);
            IsAttackingDown = true;
            IsAttacking = true;
        }
    }
    public void Headattack()
    {
        if (!IsAttacking && !IsDodging)
        {
            anim.speed = Stamina / MaxStamina;
            anim.Play(Head.AttName);
            IsAttackingUp = true;
            IsAttacking = true;
        }
    }

    public void CheckAttack(CompositeFighter attacker)
    {
        if (attacker.IsAttackingRight)
        {
            LeftDamage(attacker.Rarm.Damage, attacker.Rarm.AttackSound);
            return;
        }
        if (attacker.IsAttackingLeft)
        {
            RightDamage(attacker.Larm.Damage, attacker.Larm.AttackSound);
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
        ResetBools();
        _Audio.PlayOneShot(hit);
        if(RarmHealth>0)
            RarmHealth -= damege;
        RarmsHitSpark.gameObject.SetActive(true);

        FightControler.Instance.stopFrame();

        if (RarmHealth <= 0 && !RarmBoom)
        {
            RarmBoom=true;
            ActivateParticle(RarmCrash);
            ActivateParticle(RarmSpark);
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
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (LarmHealth > 0)
            LarmHealth -= damege;
        LarmsHitSpark.gameObject.SetActive(true);

        FightControler.Instance.stopFrame();

        if (LarmHealth <= 0)
        {
            LarmBoom = true;
            ActivateParticle(LarmCrash);
            ActivateParticle(LarmSpark);
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
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (LegsHealth > 0)
            LegsHealth -= damege;
        LegsHitSpark.gameObject.SetActive(true);

        FightControler.Instance.stopFrame();

        if (LegsHealth <= 0)
        {
            LegsBoom = true;
            ActivateParticle(LegsCrash);
            ActivateParticle(LegsSpark);
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
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (HeadHealth > 0)
            HeadHealth -= damege;
        HeadHitSpark.gameObject.SetActive(true);

        FightControler.Instance.stopFrame();

        if (HeadHealth <= 0)
        {
            HeadBoom = true;
            ActivateParticle(HeadCrash);
            ActivateParticle(HeadSpark);
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
    public IEnumerator BreakStop()
    {
        anim.speed = 0;
        yield return new WaitForSeconds(0.5f);
        anim.speed = 1;
    }
    public void FreezeFrame()
    {
        StartCoroutine(BreakStop());
    }
    public void ActivateParticle(GameObject[] set)
    {
        foreach (GameObject item in set)
        {
            item.SetActive(true);
        }
    }
    public void DeActivateParticle(GameObject[] set)
    {
        foreach (GameObject item in set)
        {
            item.SetActive(false);
        }
    }

    public void CallCam()
    {
        if (!IsEnemy)
        {
            LifeTraker.Instance.RundCounter++;
            LifeTraker.Instance.ResetTimer = true;
            LoadManager.Instance.LoadIntermision();
            StageState.Instance.ResetRepair = true;
            StageCam.Instance.GoToRepairCam();
        }
    }

    public void Pause()
    {
        anim.speed = 0;
    }
    public void UnPause()
    {
        anim.speed = 1;
    }

}
