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

    public GetUpPlayer _player;
    public AIGetUp _ai;

    //public DDInputCheck _Cheker;
    public DDManager _DanceMat;


    [Header("Mesh y materials")]
    public SkinnedMeshRenderer body;
    public Material PlayerMaterial;
    public Material EnemyMaterial;

    public AudioClip Succes;
    public AudioSource Sound;

    public GetUp _timer;

    public CompositeFighter composite;

    public static Fallen Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        //Set();
    }
    public void Update()
    {
        if (StageState.Instance.ResetKO)
        {
            StageState.Instance.ResetKO = false;
            Set();
            _timer.Set();
        }
    }
    public void Set()
    {
        //_Cheker.Restart();
        _DanceMat.SetGame();
        _isEnemy = LifeTraker.Instance.IsEnemy;
        if (_isEnemy)
        {
            VignetControler.Instance.ActivateEnemyColor();
            _ai.gameObject.SetActive(true);
            body.material = EnemyMaterial;
            Rarm = ERarm;
            Larm = ELarm;
            Leg = ELeg;
            Head = EHead;
            if (LifeTraker.Instance.eRight > 0)
            {
                Rarm.ActiveParts();
            }
            if (LifeTraker.Instance.eLeft > 0)
            {
                Larm.ActiveParts();
            }
            if (LifeTraker.Instance.eLegs > 0)
            {
                Leg.ActiveParts();
            }
            if (LifeTraker.Instance.eHead > 0)
            {
                Head.ActiveParts();
            }
        }

        if (!_isEnemy)
        {
            VignetControler.Instance.ActivatePlayerColor();
            _player.gameObject.SetActive(true);
            Rarm = RarmCollection[LifeTraker.Instance.RarmIndex];
            Larm = LarmCollection[LifeTraker.Instance.LarmIndex];
            Leg = LegCollection[LifeTraker.Instance.LegsIndex];
            Head = HeadCollection[LifeTraker.Instance.HeadIndex];
            if (LifeTraker.Instance.pRight > 0)
            {
                Rarm.ActiveParts();
            }
            if (LifeTraker.Instance.pLeft > 0)
            {
                Larm.ActiveParts();
            }
            if (LifeTraker.Instance.pLegs > 0)
            {
                Leg.ActiveParts();
            }
            if (LifeTraker.Instance.pHead > 0)
            {
                Head.ActiveParts();
            }
            body.material=PlayerMaterial;
            ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
        }
    }

    public void ResumeFight()
    {
        if (!_isEnemy)
        {
        StageCam.Instance.EnemyBackToFight();
        } else StageCam.Instance.PlayerBackToFight();

        composite.CharacterUpEvent();
    }
    public void Twith()
    {
        int Rnum = Random.Range(0, 100);
        if (Rnum <= 25) _fallen.SetTrigger("Twitch Right");
        if (Rnum <= 50 && Rnum > 25) _fallen.SetTrigger("Twitch Left");
        if (Rnum <= 75 && Rnum > 50) _fallen.SetTrigger("Twitch Up");
        if (Rnum <= 100 && Rnum > 75) _fallen.SetTrigger("Twitch Down");
    }

    //public void CheckLeft()
    //{
    //    if (_gameOver) return;
    //    _Cheker.CheckLeft();        
    //
    //    if (_Cheker._actualBar >= _Cheker._maxBar)
    //    {
    //        if (LifeTraker.Instance.IsEnemy)
    //            LifeTraker.Instance.eOverHealt = 70;
    //        else LifeTraker.Instance.pOverHealt = 70;
    //
    //        Sound.PlayOneShot(Succes);
    //        LoadManager.Instance.Round2();
    //        _timer.Stop();
    //        StageState.Instance.ResetFight=true;
    //        _fallen.SetTrigger("GetUp");
    //        StageCam.Instance.GoToFightCamFromKO();
    //    }
    //    
    //}
    //public void CheckRight()
    //{
    //    if (_gameOver) return;
    //    _Cheker.CheckRight();
    //
    //    if (_Cheker._actualBar >= _Cheker._maxBar)
    //    {
    //        if (LifeTraker.Instance.IsEnemy)
    //            LifeTraker.Instance.eOverHealt = 70;
    //        else LifeTraker.Instance.pOverHealt = 70;
    //
    //        Sound.PlayOneShot(Succes);
    //        LoadManager.Instance.Round2();
    //        _timer.Stop();
    //        StageState.Instance.ResetFight = true;
    //        _fallen.SetTrigger("GetUp");
    //        //StageCam.Instance.GoToFightCamFromKO();
    //    }
    //}
    //public void CheckUp()
    //{
    //    if (_gameOver) return;
    //    _Cheker.CheckUp();
    //
    //    if (_Cheker._actualBar >= _Cheker._maxBar)
    //    {
    //        if (LifeTraker.Instance.IsEnemy)
    //            LifeTraker.Instance.eOverHealt = 70;
    //        else LifeTraker.Instance.pOverHealt = 70;
    //
    //        Sound.PlayOneShot(Succes);
    //        LoadManager.Instance.Round2();
    //        _timer.Stop();
    //        StageState.Instance.ResetFight = true;
    //        _fallen.SetTrigger("GetUp");
    //        //StageCam.Instance.GoToFightCamFromKO();
    //    }
    //}
    //public void CheckDown()
    //{
    //    if (_gameOver) return;
    //    _Cheker.CheckDown();
    //
    //    if (_Cheker._actualBar >= _Cheker._maxBar)
    //    {
    //        if (LifeTraker.Instance.IsEnemy)
    //            LifeTraker.Instance.eOverHealt = 70;
    //        else LifeTraker.Instance.pOverHealt = 70;
    //
    //        Sound.PlayOneShot(Succes);
    //        _timer.Stop();
    //        LoadManager.Instance.Round2();
    //        StageState.Instance.ResetFight = true;
    //        _fallen.SetTrigger("GetUp");
    //        //StageCam.Instance.GoToFightCamFromKO();
    //    }
    //}

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
        body.material.SetColor("_Color1", color1);
        body.material.SetColor("_Color2", color2);
        body.material.SetFloat("_Transparencia", 1);
    }
}
