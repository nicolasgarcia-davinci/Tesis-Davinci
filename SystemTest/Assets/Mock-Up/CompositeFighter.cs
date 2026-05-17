using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

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

    [Header("Current Health")]
    public float CHead;
    public float CRight;
    public float CLeft;
    public float CLegs;
    public float CChest;

    [Header("Has To Set?")]
    public bool hasBeenSet=false;

    [Header("Eneregy System")]
    public float Stamina;
    public float MaxStamina;
    public float StaminaRefresh;

    [Header("Anim Bools")]
    public bool IsRepairing;
    public bool IsDying;

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
    public GameObject RarmsHitWave;
    public GameObject LarmsHitWave;
    public GameObject LegsHitWave;
    public GameObject HeadHitWave;

    [Header("Attack Trails")]
    public GameObject RarmsAttackTrail;
    public GameObject LarmsAttackTrail;
    public GameObject LegsAttackTrail;

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

    [Header("Body Paint")]
    public SkinnedMeshRenderer Body;

    [Header("OverAllHealth")]
    public float OverAllHealth;

    [Header("Freeze Frame")]
    [SerializeField] float lightBlow;
    [SerializeField] float heavyBlow;

    [Header("OverAllHealth")]
    public PartDisplay HeadDisplay;
    public PartDisplay RightArmDisplay;
    public PartDisplay LeftArmDisplay;
    public PartDisplay LegsDisplay;
    public LifeBar LifeBar;
    public LifeBar StamminaBar;

    [Header("Dying")]
    public Action IsDyingEvent = delegate { };
    public Action CharacterUpEvent = delegate { };

    public int DamageToTake;

    void Start()
    {
        Stamina = MaxStamina;
        StamminaBar.UpdateLife(Stamina, MaxStamina);
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

           Rarm.ActiveParts();
           Larm.ActiveParts();
           Leg.ActiveParts();
           Head.ActiveParts();
           LifeTraker.Instance.pRight = Rarm.life;
           LifeTraker.Instance.pLeft = Larm.life;
           LifeTraker.Instance.pLegs = Leg.life;
           LifeTraker.Instance.pHead = Head.life;
           LifeTraker.Instance.maxHeadHealth = Head.life;
           LifeTraker.Instance.maxRarmHealth = Rarm.life;
           LifeTraker.Instance.maxLarmHealth = Larm.life;
           LifeTraker.Instance.maxLegsHealth = Leg.life;

            CHead  = Head.life;
            CRight = Rarm.life;
            CLeft  = Larm.life;
            CLegs  = Leg.life;
            CChest =  OverAllHealth;
        }
        else
        {
            OverAllHealth = LifeTraker.Instance.eOverHealt*(LifeTraker.Instance.Dificulty);
            Rarm.ActiveParts();
            Larm.ActiveParts();
            Leg.ActiveParts();
            Head.ActiveParts();

            CHead = Head.life;
            CRight = Rarm.life;
            CLeft = Larm.life;
            CLegs = Leg.life;
            CChest = OverAllHealth;
        }
        LifeBar.UpdateLife(OverAllHealth, CChest);
    }

    public void Set()
    {
        hasBeenSet = true;
        ResetBools();
        Stamina = MaxStamina;
        StamminaBar.UpdateLife(Stamina, MaxStamina);
        IsRepairing = false;

        if (!IsEnemy)
        { 
            OverAllHealth = LifeTraker.Instance.pOverHealt;
            Rarm.life = LifeTraker.Instance.pRight;
            Larm.life = LifeTraker.Instance.pLeft;
            Leg.life  = LifeTraker.Instance.pLegs;
            Head.life = LifeTraker.Instance.pHead;
        }
        else
        {
            OverAllHealth = LifeTraker.Instance.eOverHealt;
            Rarm.life = LifeTraker.Instance.eRight;
            Larm.life = LifeTraker.Instance.eLeft;
            Leg.life = LifeTraker.Instance.eLegs;
            Head.life = LifeTraker.Instance.eHead;
        }
        if (Rarm.life > 0)
        {
            RarmBoom = false;
            Rarm.ActiveParts();
            DeActivateParticle(RarmSpark);
        }

        if (Larm.life > 0)
        {
            LarmBoom = false;
            Larm.ActiveParts();
            DeActivateParticle(LarmSpark);
        }

        if (Leg.life > 0)
        {
            LegsBoom = false;
            Leg.ActiveParts();
            DeActivateParticle(LegsSpark);
        }

        if (Head.life > 0)
        {
            HeadBoom = false;
            Head.ActiveParts();
            DeActivateParticle(HeadSpark);
        }

        HeadDisplay.UpdateDisplay(Head.life, CHead);
        RightArmDisplay.UpdateDisplay(Rarm.life, CRight);
        LeftArmDisplay.UpdateDisplay(Larm.life, CLeft);
        LegsDisplay.UpdateDisplay(Leg.life, CLegs);
        LifeBar.UpdateLife(OverAllHealth, CChest);
    }

    public void ResetBools()
    {
        IsDodgingLeft=false; IsDodgingRight=false; IsDodgingDown=false; IsDodgingUp=false; IsDodging=false; IsDying=false;
        IsAttackingLeft=false; IsAttackingRight=false; IsAttackingDown=false; IsAttackingUp=false; IsAttacking=false;
        anim.ResetTrigger("DoedgeUp");
        anim.ResetTrigger("DoedgeRight");
        anim.ResetTrigger("DoedgeLeft");
        anim.ResetTrigger("DoedgeDown");
        anim.speed = 1;
    }
    public void FireCutscene()
    {
        if(!IsEnemy)
        StageCam.Instance.ResumeCam();
    }

    public void EnterStage()
    {
        anim.SetTrigger("Enter Stage");
    }
    public void FightStart()
    {
        if(!IsEnemy) FightControler.Instance.EnterStage();
    }
    public void ExitFight()
    {
        FightControler.Instance.DeActivateControlers();
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
    public void SkipIntro()
    {
        anim.Play("Idle");
    }


    void Update()
    {
        if (Stamina < MaxStamina)
        {
            Stamina += StaminaRefresh * Time.deltaTime;
            StamminaBar.UpdateLife(Stamina,MaxStamina);
        }
    }

    public bool Dodge(string animation, bool dodge)
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            IsDodgingRight = true;
            dodge = true;
            anim.SetTrigger(animation);
            return dodge;
        }
        return false;
    }

    #region Dodge Viejo
    public void DodgeRight()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        { 
            IsDodgingRight=true;
            IsDodging=true;
            anim.SetTrigger("DoedgeRight");
        }
    }
    public void DodgeLeft()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            IsDodgingLeft = true;
            anim.SetTrigger("DoedgeLeft");
            IsDodging = true;
        }
    }
    public void DodgeUp()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            IsDodgingUp = true;
            IsDodging = true;
            anim.SetTrigger("DoedgeUp");
        }
    }
    public void DodgeDown()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            IsDodgingDown = true;
            IsDodging = true;
            anim.SetTrigger("DoedgeRight");
        }  
    }
    #endregion

    public bool Attack(string animation, GameObject trail, bool partAttack)
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying && Stamina>10)
        {
            Stamina -= 10;
            StamminaBar.UpdateLife(Stamina, MaxStamina);
            StartCoroutine(ManageVFX(trail, 0.75f));
            anim.speed = Stamina / MaxStamina;
            anim.Play(animation);
            IsAttacking = true;
            return partAttack = true;
        }

        return false;
    }

    #region Ataque Viejo
    /*public void LArmattack()
    {
        if(!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            if (!IsEnemy) StartCoroutine(ManageVFX(LarmsAttackTrail, 0.75f));
            anim.speed = Stamina / MaxStamina;
            anim.Play(Larm.AttName);
            IsAttackingLeft=true;
            IsAttacking = true;
        }    
    }
    public void RArmattack()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            if (!IsEnemy) StartCoroutine(ManageVFX(RarmsAttackTrail, 0.75f));
            anim.speed = Stamina / MaxStamina;
            anim.Play(Rarm.AttName);
            IsAttackingRight = true;
            IsAttacking = true;
        }
    }
    public void Legattack()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            if (!IsEnemy) StartCoroutine(ManageVFX(LegsAttackTrail, 0.75f));
            anim.speed = Stamina / MaxStamina;
            anim.Play(Leg.AttName);
            IsAttackingDown = true;
            IsAttacking = true;
        }
    }
    public void Headattack()
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            if(!IsEnemy) StartCoroutine(ManageVFX(RarmsAttackTrail, 0.75f));
            anim.speed = Stamina / MaxStamina;
            anim.Play(Head.AttName);
            IsAttackingUp = true;
            IsAttacking = true;
        }
    }*/
    #endregion

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

    public void RightDamage(int damage, AudioClip hit)
    {
        if (IsDodgingLeft)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.Play("Get Hit Right");
        ResetBools();
        _Audio.PlayOneShot(hit);
        if(Rarm.life>0)
            Rarm.life -= damage;
        //RarmsHitSpark.gameObject.SetActive(true);
        StartCoroutine(WaveVFX(RarmsHitWave, 0.5f));

        LifeTraker.Instance.UpdateLife();

        RightArmDisplay.UpdateDisplay(Rarm.life, CRight);

        FightControler.Instance.stopFrame();

        if (Rarm.life <= 0 && !RarmBoom)
        {
            RarmBoom=true;
            ActivateParticle(RarmCrash);
            ActivateParticle(RarmSpark);
            FightControler.Instance.stopFrameHigh();
            Rarm.DeActiveParts();
        }
        if(!IsEnemy)
        {
            Debug.Log("BrazoChotoDerecho");
            LifeTraker.Instance.UpdateLife();
        }
        DamageToTake=damage;
    }
    public void LeftDamage(int damage, AudioClip hit)
    {
        if (IsDodgingRight)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.Play("Get Hit Left");
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (Larm.life > 0)
            Larm.life -= damage;
        //LarmsHitSpark.gameObject.SetActive(true);
        StartCoroutine(WaveVFX(LarmsHitWave, 0.5f));

        LifeTraker.Instance.UpdateLife();

        LeftArmDisplay.UpdateDisplay(Larm.life, CLeft);

        FightControler.Instance.stopFrame();

        if (Larm.life <= 0)
        {
            LarmBoom = true;
            ActivateParticle(LarmCrash);
            ActivateParticle(LarmSpark);
            FightControler.Instance.stopFrameHigh();
            Larm.DeActiveParts();
        }
        if (!IsEnemy)
        {
            Debug.Log("BrazoChotoIzquierdo");
            LifeTraker.Instance.UpdateLife();
        }
        DamageToTake = damage;
    }
    public void LegsDamage(int damage, AudioClip hit)
    {
        if (IsDodgingDown)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.Play("Get Hit Down");
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (Leg.life > 0)
            Leg.life -= damage;
        //LegsHitSpark.gameObject.SetActive(true);
        StartCoroutine(WaveVFX(LegsHitWave, 0.5f));

        LegsDisplay.UpdateDisplay(Leg.life, CLegs);

        LifeTraker.Instance.UpdateLife();

        FightControler.Instance.stopFrame();

        if (Leg.life <= 0)
        {
            LegsBoom = true;
            ActivateParticle(LegsCrash);
            ActivateParticle(LegsSpark);
            FightControler.Instance.stopFrameHigh();
            Leg.DeActiveParts();
        }
        DamageToTake = damage;
    }
    public void HeadDamage(int damage, AudioClip hit)
    {
        if (IsDodgingUp)
        {
            _Audio.PlayOneShot(_miss);
            return;
        }

        anim.Play("Get Hit Up");
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (Head.life > 0)
            Head.life -= damage;
        //HeadHitSpark.gameObject.SetActive(true);
        StartCoroutine(WaveVFX(HeadHitWave, 0.5f));

        LifeTraker.Instance.UpdateLife();

        HeadDisplay.UpdateDisplay(Head.life, CHead);

        FightControler.Instance.stopFrame();

        if (Head.life <= 0)
        {
            HeadBoom = true;
            ActivateParticle(HeadCrash);
            ActivateParticle(HeadSpark);
            FightControler.Instance.stopFrameHigh();
            Head.DeActiveParts();
        }
        DamageToTake = damage;
    }

    public void BattleHealth()
    {
        OverAllHealth -= DamageToTake;

        LifeBar.UpdateLife(OverAllHealth, CChest);

        if (OverAllHealth<=0)
        {
            IsDying = true;
            ExitFight();
            IsDyingEvent();
            anim.SetTrigger("KO");
        }
    }
    public IEnumerator BreakStop(float duration)
    {
        anim.speed = 0;
        yield return new WaitForSeconds(duration);
        anim.speed = 1;
    }
    public void FreezeFrameLow()
    {
        StartCoroutine(BreakStop(lightBlow));
    }
    public void FreezeFrameHigh()
    {
        StartCoroutine(BreakStop(heavyBlow));
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

    IEnumerator ManageVFX(GameObject vfx, float i)
    {
        vfx.SetActive(true);
        yield return new WaitForSeconds(i);
        vfx.SetActive(false);
    }
    IEnumerator WaveVFX(GameObject vfx, float i)
    {
        vfx.SetActive(true);
        yield return new WaitForSeconds(i);
        vfx.SetActive(false);
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
