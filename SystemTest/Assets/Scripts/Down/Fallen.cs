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

    public DDManager _DanceMat;


    [Header("Mesh y materials")]
    public SkinnedMeshRenderer body;
    public Material PlayerMaterial;
    public Material EnemyMaterial;

    public AudioClip Succes;
    public AudioSource Sound;

    public GetUp _timer;

    public void Set()
    {
        _timer.Set();
        _DanceMat.SetGame();
        _isEnemy = LifeTraker.Instance.IsEnemy;
        if (_isEnemy)
        {
            VignetControler.Instance.ActivateEnemyColor();
            body.material = EnemyMaterial;
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
            VignetControler.Instance.ActivatePlayerColor();
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

            body.material=PlayerMaterial;
            ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
        }
    }

    public void ResumeFight()
    {
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
    public void Twith()
    {
        int Rnum = Random.Range(0, 100);
        if (Rnum <= 25) _fallen.SetTrigger("Twitch Right");
        if (Rnum <= 50 && Rnum > 25) _fallen.SetTrigger("Twitch Left");
        if (Rnum <= 75 && Rnum > 50) _fallen.SetTrigger("Twitch Up");
        if (Rnum <= 100 && Rnum > 75) _fallen.SetTrigger("Twitch Down");
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
    public void ColorChange(Color color1, Color color2)
    {
        body.material.SetColor("_Color_1", color1);
        body.material.SetColor("_Color_2", color2);
        body.material.SetFloat("_Transparencia", 1);
    }
    public void GetUp()
    {
        _fallen.SetTrigger("GetUp");
    }
}
