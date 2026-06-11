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
    public int PartCount;

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
    public float DificultyMultyplyer;

    [Header("Dodge")]
    public bool IsDodgingRight;
    public bool IsDodgingLeft;
    public bool IsDodgingUp;
    public bool IsDodgingDown;
    public bool IsDodging;

    [Header("DodgeTrail")]
    [SerializeField] string matAlphaName;
    [SerializeField] GameObject spawnTransform;
    [SerializeField, Range(0, 1)] float _dodgeTime;
    [SerializeField] float _refreshRate;
    [SerializeField] float _delayDestroy;
    [SerializeField] PlayerTrailFactory trailFactory;
    [SerializeField] MeshTrail trailMesh;

    [Header("Atacks")]
    public bool IsAttackingRight;
    public bool IsAttackingLeft;
    public bool IsAttackingUp;
    public bool IsAttackingDown;
    public bool IsAttacking;
    public bool IsDebuffed;
    public float DebuffTime;

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

    //[Header("Attack Trails")]
    //public GameObject RarmsAttackTrail;
    //public GameObject LarmsAttackTrail;
    //public GameObject LegsAttackTrail;

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
    public LifeBar RedBar;
    public LifeBar StamminaBar;

    [Header("Dying")]
    public Action IsDyingEvent = delegate { };
    public Action CharacterUpEvent = delegate { };

    public float DamageToTake;

    void Start()
    {
        Stamina = MaxStamina;
        StamminaBar.UpdateLife(Stamina, MaxStamina);
        anim = GetComponent<Animator>();
        if (!IsEnemy)
        {
            trailMesh = new MeshTrail(this, trailFactory.Pool, trailFactory.playerSkRenderer, trailFactory.trailMat, matAlphaName, _dodgeTime)
                .setTime(_refreshRate, _delayDestroy).setPos(this.transform);
            Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
            Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
            Leg = LegCollection[LifeTraker.Instance.LegsIndex];
            Head = HeadCollection[LifeTraker.Instance.HeadIndex];
            Chest = ChestCollection[LifeTraker.Instance.ChestIndex];
            LifeTraker.Instance.pOverHealt = (Rarm.life + Larm.life + Leg.life  +Head.life + Chest.life);
            LifeTraker.Instance.MaxHealt = LifeTraker.Instance.pOverHealt;
            OverAllHealth = LifeTraker.Instance.pOverHealt;

            Rarm.ActiveParts();
            Rarm.FullColor(ColorCordination.Instance.Fullcolor1[0], ColorCordination.Instance.Fullcolor2[0]);
            Larm.ActiveParts();
            Larm.FullColor(ColorCordination.Instance.Fullcolor1[1], ColorCordination.Instance.Fullcolor2[1]);
            Leg.ActiveParts();
            Leg.FullColor(ColorCordination.Instance.Fullcolor1[2], ColorCordination.Instance.Fullcolor2[2]);
            Head.ActiveParts();
            Head.FullColor(ColorCordination.Instance.Fullcolor1[3], ColorCordination.Instance.Fullcolor2[3]);
            Chest.ActiveParts();
            Chest.FullColor(ColorCordination.Instance.Fullcolor1[4], ColorCordination.Instance.Fullcolor2[4]);

            LifeTraker.Instance.pRight = Rarm.life;
            LifeTraker.Instance.pLeft = Larm.life;
            LifeTraker.Instance.pLegs = Leg.life;
            LifeTraker.Instance.pHead = Head.life;
            LifeTraker.Instance.maxHeadHealth = Head.life;
            LifeTraker.Instance.maxRarmHealth = Rarm.life;
            LifeTraker.Instance.maxLarmHealth = Larm.life;
            LifeTraker.Instance.maxLegsHealth = Leg.life;

            CHead = Head.life;
            CRight = Rarm.life;
            CLeft = Larm.life;
            CLegs = Leg.life;
            CChest = OverAllHealth;
        }
        else
        {
            DificultyMultyplyer = LifeTraker.Instance.Dificulty;
            Rarm.ActiveParts();
            Larm.ActiveParts();
            Leg.ActiveParts();
            Head.ActiveParts();
            Chest.ActiveParts();

            LifeTraker.Instance.eRight = Rarm.life;
            LifeTraker.Instance.eLeft = Larm.life;
            LifeTraker.Instance.eLegs = Leg.life;
            LifeTraker.Instance.eHead = Head.life;
            LifeTraker.Instance.eOverHealt = (Rarm.life + Larm.life + Leg.life + Head.life + Chest.life) * DificultyMultyplyer;
            LifeTraker.Instance.eMaxHealt = LifeTraker.Instance.eOverHealt;
            OverAllHealth = LifeTraker.Instance.eOverHealt;

            CHead = Head.life;
            CRight = Rarm.life;
            CLeft = Larm.life;
            CLegs = Leg.life;
            CChest = OverAllHealth;
        }
        //LifeBar.ProgresiveEnter(OverAllHealth, CChest);
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

        PartCount = 0;

        if (Rarm.life > 0)
        {
            PartCount++; 
            RarmBoom = false;
            Rarm.ActiveParts();
            DeActivateParticle(RarmSpark);
        }

        if (Larm.life > 0)
        {
            PartCount++;
            LarmBoom = false;
            Larm.ActiveParts();
            DeActivateParticle(LarmSpark);
        }

        if (Leg.life > 0)
        {
            PartCount++;
            LegsBoom = false;
            Leg.ActiveParts();
            DeActivateParticle(LegsSpark);
        }

        if (Head.life > 0)
        {
            PartCount++;
            HeadBoom = false;
            Head.ActiveParts();
            DeActivateParticle(HeadSpark);
        }

        HeadDisplay.UpdateDisplay(Head.life, CHead);
        RightArmDisplay.UpdateDisplay(Rarm.life, CRight);
        LeftArmDisplay.UpdateDisplay(Larm.life, CLeft);
        LegsDisplay.UpdateDisplay(Leg.life, CLegs);
        EnterLife();
    }

    public void ExitStage()
    {
        anim.Play("DescansoEntry V2");
    }

    public void EnterLife()
    {
        LifeBar.ProgresiveEnter(OverAllHealth, CChest);
        RedBar.UpdateLife(OverAllHealth, CChest);
    }

    public void ResetBools()
    {
        IsDodgingLeft=false; IsDodgingRight=false; IsDodgingDown=false; IsDodgingUp=false; IsDodging=false; IsDying=false;
        IsAttackingLeft=false; IsAttackingRight=false; IsAttackingDown=false; IsAttackingUp=false; IsAttacking=false;
        anim.ResetTrigger("DoedgeUp");
        anim.ResetTrigger("DoedgeRight");
        anim.ResetTrigger("DoedgeLeft");
        anim.ResetTrigger("DoedgeDown");
    }
    public void FireCutscene()
    {
        if(!IsEnemy)
        StageCam.Instance.ResumeCam();
    }

    public void EnterStage()
    {
        LifeBar.lifeBar.fillAmount = 0;
        RedBar.lifeBar.fillAmount = 0;
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
        EnterLife();
    }


    void Update()
    {
        if (Stamina < MaxStamina && !IsDebuffed)
        {
            Stamina += StaminaRefresh * Time.deltaTime;
            StamminaBar.UpdateLife(Stamina,MaxStamina);
        }
    }

    public void Dodge(string animation, ref bool dodge)
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying)
        {
            dodge = true;
            //if(!IsEnemy) trailMesh?.CallTrail();
            anim.SetTrigger(animation);
        }
    }

    #region Dodge Viejo
    /*public void DodgeRight()
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
    }*/
    #endregion

    public void Attack(string animation, GameObject trail, ref bool partAttack)
    {
        if (!IsAttacking && !IsDodging && !IsRepairing && !IsDying && Stamina>1)
        {
            Stamina -= 10;
            if(Stamina<0) Stamina = 0;
            StamminaBar.UpdateLife(Stamina, MaxStamina);
            if (!IsDebuffed && Stamina <= 0) StartCoroutine(Exausted());
            StartCoroutine(ManageVFX(trail, 0.75f));
            //anim.speed = Stamina / MaxStamina;
            anim.Play(animation);
            IsAttacking = true;
            partAttack = true;
        }
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
            PartDamage(attacker.Larm.Damage, CLeft, attacker.Larm.AttackSound, ref Larm, IsDodgingRight, ref LarmBoom,
                "Get Hit Left", LarmsHitWave, LarmSpark, LarmCrash);
            //LeftDamage(attacker.Rarm.Damage, attacker.Rarm.AttackSound);
            return;
        }
        if (attacker.IsAttackingLeft)
        {
            PartDamage(attacker.Rarm.Damage, CRight, attacker.Rarm.AttackSound, ref Rarm, IsDodgingLeft, ref RarmBoom,
                "Get Hit Right", RarmsHitWave, RarmSpark, RarmCrash);
            //RightDamage(attacker.Larm.Damage, attacker.Larm.AttackSound);
            return;
        }
        if (attacker.IsAttackingUp)
        {
            PartDamage(attacker.Head.Damage, CHead, attacker.Head.AttackSound, ref Head, IsDodgingUp, ref HeadBoom,
                "Get Hit Up", HeadHitWave, HeadSpark, HeadCrash);
            //HeadDamage(attacker.Head.Damage, attacker.Head.AttackSound);
            return;
        }
        if (attacker.IsAttackingDown)
        {
            PartDamage(attacker.Leg.Damage, CRight, attacker.Leg.AttackSound, ref Leg, IsDodgingDown, ref LegsBoom,
                "Get Hit Down", LegsHitWave, LegsSpark, LegsCrash);
            //LegsDamage(attacker.Leg.Damage, attacker.Leg.AttackSound);
            return;
        }
    }

    public void PartDamage(float damage, float currentLife, AudioClip hit, ref Part partHit, bool hitPart,
        ref bool partDestroyed, string animHit, GameObject HitWave, GameObject[] Sparks, GameObject[] Crash)
    {
        Debug.Log("Jaja llame a la funcion de Necro " + this.name);

        if (hitPart)
        {
            _Audio.PlayOneShot(_miss);
            if(!IsEnemy) trailMesh?.CallTrail();
            Stamina += 10;
            return;
        }

        anim.Play(animHit);
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (partHit.life > 0)
            partHit.life -= damage;

        //RarmsHitSpark.gameObject.SetActive(true);
        StartCoroutine(WaveVFX(HitWave, 0.5f));

        LifeTraker.Instance.UpdateLife();

        RightArmDisplay.UpdateDisplay(partHit.life, currentLife);

        FightControler.Instance.stopFrame();

        if (partHit.life <= 0 && !partDestroyed)
        {
            partDestroyed = true;
            ActivateParticle(Crash);
            ActivateParticle(Sparks);
            FightControler.Instance.stopFrameHigh();
            partHit.DeActiveParts();
            PartCount--;
            DamageToTake = (damage + partHit.life);
            return;
        }
        if (!IsEnemy)
        {
            Debug.Log("BrazoChotoDerecho");
            LifeTraker.Instance.UpdateLife();
        }
        DamageToTake = damage;
    }

    #region Viejo Daño
    /*public void RightDamage(int damage, AudioClip hit)
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
    }*/
    #endregion

    public void BattleHealth()
    {
        OverAllHealth -= DamageToTake;

        LifeBar.UpdateLife(OverAllHealth, CChest);
        RedBar.ProgresiveUpdate(OverAllHealth, CChest);

        if (OverAllHealth<=0)
        {
            FightControler.Instance.Halt();
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
    IEnumerator Exausted()
    {
        IsDebuffed = true;
        yield return new WaitForSeconds(DebuffTime);
        Stamina = MaxStamina / 2;
        IsDebuffed = false;
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
