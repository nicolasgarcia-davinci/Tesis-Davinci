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

        Signals[4].SetActive(false);
        Signals[5].SetActive(false);

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
        ResetBreak();
    }
    public override void Set()
    {
        ResetBreak();

        Rarm.life = LifeTraker.Instance.eRight;
        Larm.life = LifeTraker.Instance.eLeft;
        Leg.life = LifeTraker.Instance.eLegs;
        Head.life = LifeTraker.Instance.eHead;

        LifeTraker.Instance.eOverHealt = (Rarm.life + Larm.life + Leg.life + Head.life + Chest.life);
        OverAllHealth = LifeTraker.Instance.eOverHealt;

        IsRepairing = false;

        if (Rarm.life > 0) Signals[0].SetActive(false);

        if (Larm.life > 0) Signals[1].SetActive(false);

        if (Leg.life > 0) Signals[2].SetActive(false);

        if (Head.life > 0) Signals[3].SetActive(false);

        if (Rarm.life <= 0) BREAKBAR(Rarm);
        if (Larm.life <= 0) BREAKBAR(Larm);
        if (Leg.life <= 0) BREAKBAR(Leg);
        if (Head.life <= 0) BREAKBAR(Head);

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

        if (hitPart)
        {
            _Audio.PlayOneShot(_miss);
            Stamina += 10;
            IsBuffed = true;
            Debug.Log("Enemigo Esquivo");
            return;
        }
        Debug.Log("Enemigo Atacado");

        IsBuffed = false;
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
            ActivateIMPACT();
            ActivateParticle(Crash);
            ActivateParticle(Sparks);
            PartBlincker(partHit);
            FightControler.Instance.stopFrameHigh();
            FightControler.Instance.FlashOrigin(this);
            partHit.DeActiveParts();
            //LOCKBar.UpdateLife((5 - PartCount), 5f);
            if (BuffState)
            {
                Debug.Log("Buff In effect");
                DamageToTake = (damage * 2 + partHit.Maxlife);
                if (isbroken) DamageToTake = (damage + partHit.Maxlife);
                _Audio.PlayOneShot(_buffedHit);
                Debug.Log("Parte atacada " + partHit.name);
                Debug.Log(DamageToTake);
                LifeTraker.Instance.UpdateLife();
                return;
            }
            Debug.Log("Buff Not In effect");
            DamageToTake = (damage + partHit.Maxlife);
            if (isbroken) DamageToTake = (damage / 2 + partHit.Maxlife);
            FightControler.Instance.CallCrowd(this);
            Debug.Log("Parte atacada " + partHit.name);
            Debug.Log(DamageToTake);
            LifeTraker.Instance.UpdateLife();
            return;
        }
        else if (isbroken)
        {
            if (BuffState)
            {
                Debug.Log("Buff In effect");
                damage = damage * 2;
                _Audio.PlayOneShot(_buffedHit);
            }
            if (!BuffState) Debug.Log("Buff Not In effect");
            DamageToTake = damage / 2;
            Debug.Log("Parte atacada " + partHit.name);
            Debug.Log(DamageToTake);
            LifeTraker.Instance.UpdateLife();
            return;
        }
        else
        {
            if (BuffState) 
            {
                Debug.Log("Buff In effect");
                DamageToTake = damage*2;
                _Audio.PlayOneShot(_buffedHit);
            }
            if (!BuffState) 
            {
                Debug.Log("Buff Not In effect");
                DamageToTake = damage;
            }
            Debug.Log("Parte atacada " + partHit.name);
            Debug.Log(DamageToTake);
            LifeTraker.Instance.UpdateLife();
        }
    }
    public override void BattleHealth()
    {
        OverAllHealth -= DamageToTake;

        LifeBar.UpdateLife(OverAllHealth, CChest);
        RedBar.ProgresiveUpdate(OverAllHealth, CChest);

        if (OverAllHealth <= 0)
        {
            anim.StopPlayback();
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
    public override void BREAKBAR(Part oops)
    {
        if (oops.life > 0)
        {
            NegativeBar -= oops.Maxlife;
            if (NegativeBar < 0) NegativeBar = 0;
            LOCKBar.UpdateLife(NegativeBar, LifeTraker.Instance.eMaxHealt);
            return;
        }
        NegativeBar += oops.Maxlife;
        LOCKBar.UpdateLife(NegativeBar, LifeTraker.Instance.eMaxHealt);
    }

    public override void ResetBreak()
    {
        NegativeBar = 0;
        LOCKBar.UpdateLife(0f, LifeTraker.Instance.eMaxHealt);
    }
}
