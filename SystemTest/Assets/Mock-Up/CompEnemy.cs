using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompEnemy : CompositeFighter
{
    [Header("Enemy?")]
    public float DificultyMultyplyer;

    [Header("Attack Warning")]
    public GameObject warning;
    public float WarningTime;

    public override void Start()
    {
        Stamina = MaxStamina;
        StamminaBar.UpdateLife(Stamina, MaxStamina);
        anim = GetComponent<Animator>();
        impactColor = Color.red;

        Rarm.ActiveParts();
        Larm.ActiveParts();
        Leg.ActiveParts();
        Head.ActiveParts();
        Chest.ActiveParts();

        LifeTraker.Instance.eRight = Rarm.life;
        LifeTraker.Instance.eLeft = Larm.life;
        LifeTraker.Instance.eLegs = Leg.life;
        LifeTraker.Instance.eHead = Head.life;
        LifeTraker.Instance.eOverHealt = (Rarm.life + Larm.life + Leg.life + Head.life + Chest.life);
        LifeTraker.Instance.eMaxHealt = LifeTraker.Instance.eOverHealt;
        OverAllHealth = LifeTraker.Instance.eOverHealt;

        CHead = Head.life;
        CRight = Rarm.life;
        CLeft = Larm.life;
        CLegs = Leg.life;
        CChest = OverAllHealth;
    }
    public override void Set()
    {
        OverAllHealth = LifeTraker.Instance.eOverHealt;
        Rarm.life = LifeTraker.Instance.eRight;
        Larm.life = LifeTraker.Instance.eLeft;
        Leg.life = LifeTraker.Instance.eLegs;
        Head.life = LifeTraker.Instance.eHead;
        IsRepairing = false;
        PartCount = 1;

        if (Rarm.life > 0)
        {
            PartCount++;
        }

        if (Larm.life > 0)
        {
            PartCount++;
        }

        if (Leg.life > 0)
        {
            PartCount++;
        }

        if (Head.life > 0)
        {
            PartCount++;
        }
        EnterLife();
    }
    public override void FireCutscene()
    {
        return;
    }
    public override void FightStart()
    {
        return;
    }
    public override void PartDamage(float damage, float currentLife, AudioClip hit, ref Part partHit, bool hitPart,
        ref bool partDestroyed, string animHit, GameObject HitWave, GameObject[] Sparks, GameObject[] Crash
        , bool isbroken, bool BuffState)
    {
        Debug.Log("Jaja llame a la funcion de Necro " + this.name);

        if (hitPart)
        {
            _Audio.PlayOneShot(_miss);
            Stamina += 10;
            return;
        }

        anim.Play(animHit);
        ResetBools();
        _Audio.PlayOneShot(hit);
        if (partHit.life > 0)
            partHit.life -= damage;

        StartCoroutine(WaveVFX(HitWave, 0.5f));

        LifeTraker.Instance.UpdateLife();

        FightControler.Instance.stopFrame();

        if (partHit.life <= 0 && !partDestroyed)
        {
            partDestroyed = true;
            ActivateParticle(Crash);
            ActivateParticle(Sparks);
            FightControler.Instance.stopFrameHigh();
            FightControler.Instance.FlashOrigin(this);
            partHit.DeActiveParts();
            PartCount--;
            if (BuffState) damage = damage * 2;
            if (isbroken) DamageToTake = (damage / 2 + partHit.Maxlife);
            DamageToTake = (damage + partHit.Maxlife);
            Debug.Log(DamageToTake);
            FightControler.Instance.CallCrowd(this);
            return;
        }
        else if (isbroken)
        {
            if (BuffState) damage = damage * 2;
            DamageToTake = damage / 2;
        }
        else DamageToTake = damage;
    }
    public override void BattleHealth()
    {
        OverAllHealth -= DamageToTake;

        LifeBar.UpdateLife(OverAllHealth, CChest);
        RedBar.ProgresiveUpdate(OverAllHealth, CChest);

        if (OverAllHealth <= 0)
        {
            LifeTraker.Instance.ePartCount = PartCount;
            FightControler.Instance.Halt();
            IsDying = true;
            ExitFight();
            IsDyingEvent();
            anim.SetTrigger("KO");
        }
    }
    public override void FlashWarning()
    {
        StartCoroutine(Warning());
    }


    IEnumerator Warning()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(WarningTime);
        warning.SetActive(false);
    }
}
