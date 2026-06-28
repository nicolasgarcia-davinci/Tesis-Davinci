using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : CompEnemy
{
    [SerializeField] int NumOfChanges;
    public GameObject Sayian;

    public override void Set()
    {
        ResetBools();
        Stamina = MaxStamina;
        StamminaBar.UpdateLife(Stamina, MaxStamina);
        IsRepairing = false;

        OverAllHealth = LifeTraker.Instance.eOverHealt;
        Rarm.life = LifeTraker.Instance.eRight;
        Larm.life = LifeTraker.Instance.eLeft;
        Leg.life = LifeTraker.Instance.eLegs;
        Head.life = LifeTraker.Instance.eHead;

        if (Rarm.life <= 0 && NumOfChanges>0)
        {
            ChangeRarm();
            PartCount++;
            RarmBoom = false;
            Rarm.ActiveParts();
            DeActivateParticle(RarmSpark);
        }

        if (Larm.life <= 0 && NumOfChanges > 0)
        {
            ChangeLarm();
            PartCount++;
            LarmBoom = false;
            Larm.ActiveParts();
            DeActivateParticle(LarmSpark);
        }

        if (Leg.life <= 0 && NumOfChanges > 0)
        {
            ChangeLegs();
            PartCount++;
            LegsBoom = false;
            Leg.ActiveParts();
            DeActivateParticle(LegsSpark);
        }

        if (Head.life <= 0 && NumOfChanges > 0)
        {
            ChangeHeads();
            PartCount++;
            HeadBoom = false;
            Head.ActiveParts();
            DeActivateParticle(HeadSpark);
        }

        LifeTraker.Instance.eOverHealt = (Rarm.life + Larm.life + Leg.life + Head.life + Chest.life);
        OverAllHealth = LifeTraker.Instance.eOverHealt;
        EnterLife();
    }
    public void ChangeRarm()
    {
        NumOfChanges--;
        int ChangeTo = Random.Range(0, 3);
        Rarm = RarmCollection[ChangeTo];
        Rarm.life = Rarm.Maxlife;
        LifeTraker.Instance.eRight = Rarm.life;
    }
    public void ChangeLarm()
    {
        NumOfChanges--;
        int ChangeTo = Random.Range(0, 3);
        Larm = LarmCollection[ChangeTo];
        Larm.life = Larm.Maxlife;
        LifeTraker.Instance.eLeft = Larm.life;
    }
    public void ChangeLegs()
    {
        NumOfChanges--;
        int ChangeTo = Random.Range(0, 3);
        Leg = LegCollection[ChangeTo];
        Leg.life = Leg.Maxlife;
        LifeTraker.Instance.eLegs = Leg.life;
    }
    public void ChangeHeads()
    {
        NumOfChanges--;
        int ChangeTo = Random.Range(0, 3);
        Head = HeadCollection[ChangeTo];
        Head.life = Head.Maxlife;
        LifeTraker.Instance.eHead = Head.life;
    }
    public void GoBerserk()
    {
        Sayian.SetActive(true);
    }
    public void ChillPill()
    {
        Sayian.SetActive(false);
    }
}
