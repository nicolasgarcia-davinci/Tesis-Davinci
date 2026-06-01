using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class Fallen : MonoBehaviour
{
    public Animator _fallen;

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

    [Header("Enemie Parts")]
    public Arm ERarm;
    public Arm ELarm;
    public Leg ELeg;
    public Head EHead;

    public bool _gameOver;
    public bool _isEnemy;

    public AudioClip Succes;
    public AudioSource Sound;

    public GetUp _timer;

    public void Set()
    {
        _timer.Set();
        _isEnemy = LifeTraker.Instance.IsEnemy;
        if (_isEnemy)
        {
            Rarm = ERarm;
            Larm = ELarm;
            Leg = ELeg;
            Head = EHead;
            if (LifeTraker.Instance.eRight > 0)
            {
                Rarm.ActiveParts();
            }else Rarm.DeActiveParts();
            if (LifeTraker.Instance.eLeft > 0)
            {
                Larm.ActiveParts();
            }else Larm.DeActiveParts();
            if (LifeTraker.Instance.eLegs > 0)
            {
                Leg.ActiveParts();
            }else Leg.DeActiveParts();
            if (LifeTraker.Instance.eHead > 0)
            {
                Head.ActiveParts();
            }else Head.DeActiveParts();
        }

        if (!_isEnemy)
        {
            Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
            Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
            Leg = LegCollection[LifeTraker.Instance.LegsIndex];
            Head = HeadCollection[LifeTraker.Instance.HeadIndex];

            if (LifeTraker.Instance.pRight > 0)
            {
                Rarm.ActiveParts();
            }else Rarm.DeActiveParts();

            if (LifeTraker.Instance.pLeft > 0)
            {
                Larm.ActiveParts();
            }else Larm.DeActiveParts();

            if (LifeTraker.Instance.pLegs > 0)
            {
                Leg.ActiveParts();
            }else Leg.DeActiveParts();

            if (LifeTraker.Instance.pHead > 0)
            {
                Head.ActiveParts();
            }else Head.DeActiveParts();
            ColorChange();
        }
    }

    public void ResumeFight()
    {
        StageSound.instance.Mute();
        if (!_isEnemy)
        {
            StageCam.Instance.PlayerBackToFight();
            this.gameObject.SetActive(false);
        }
        else
        {
            StageCam.Instance.EnemyBackToFight();
            this.gameObject.SetActive(false);
        }
    }

    public void Leave()
    {
        this.gameObject.SetActive(false);
    }

    public void Play()
    {
        _fallen.speed = 1;
    }
    public void Stop()
    {
        _fallen.speed = 0;
    }
    public void ColorChange()
    {
        Rarm.SetColor();
        Larm.SetColor();
        Leg.SetColor();
        Head.SetColor();
    }
    public void GetUp()
    {
        _fallen.SetTrigger("GetUp");
    }
}
