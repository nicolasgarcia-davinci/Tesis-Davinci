using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;

    public CompositeFighter _Player;
    public CompositeFighter _Enemy;

    public Reactions TheCrowd;

    public AIControler _Controler;
    public PlayerControler _Control;

    public RoundTimer _RT;
    public GameObject PauseMenu;
    public GameObject Timer;
    public GameObject Controlers;
    public bool IsPaused;

    public Animator UI_Enter;

    public AudioRequester _stageTheme;

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

    public void IADefender(CompositeFighter attacker)
    {
        if (attacker == _Player)
            _Controler.IAPrediction(_Player.IsAttackingUp, _Player.IsAttackingRight, _Player.IsAttackingLeft, _Player.IsAttackingDown);
    }
    public void SetDownFighter(CompositeFighter loser)
    {
        if (loser != _Enemy)
        {
            LifeTraker.Instance.IsEnemy = false;
            LifeTraker.Instance.PlayerKO++;
            LifeTraker.Instance.PartCount = loser.PartCount;
        }
        else
        {
            LifeTraker.Instance.IsEnemy = true;
            LifeTraker.Instance.EnemyKO++;
            LifeTraker.Instance.ePartCount = loser.PartCount;
        }

        LifeTraker.Instance.pOverHealt = _Player.OverAllHealth;
        LifeTraker.Instance.pHead      = _Player.Head.life;
        LifeTraker.Instance.pRight     = _Player.Rarm.life;
        LifeTraker.Instance.pLeft      = _Player.Larm.life;
        LifeTraker.Instance.pLegs      = _Player.Leg.life;


        LifeTraker.Instance.eOverHealt = _Enemy.OverAllHealth;
        LifeTraker.Instance.eHead      = _Enemy.Head.life;
        LifeTraker.Instance.eRight     = _Enemy.Rarm.life;
        LifeTraker.Instance.eLeft      = _Enemy.Larm.life;
        LifeTraker.Instance.eLegs      = _Enemy.Leg.life;

        StageCam.Instance.GoToKOCam();
    }

    public void CheckAttack(CompositeFighter attacker)
    {
        if(attacker = _Player)
        {
            _Enemy.CheckAttack(attacker);
        }

        if (attacker = _Enemy)
        {
            _Player.CheckAttack(attacker);
        }
    }
    public void Halt()
    {
        _RT.Stop();
    }

    public void CallCrowd(CompositeFighter victim)
    {
        if(TheCrowd==null)return;
        if (victim == _Enemy) TheCrowd.Celebrate();
        if (victim == _Player) TheCrowd.Hakle();
    }
    public void stopFrame()
    {
        _Player.FreezeFrameLow();
        _Enemy.FreezeFrameLow();
    }
    public void stopFrameHigh()
    {
        _Player.FreezeFrameHigh();
        _Enemy.FreezeFrameHigh();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                UnPause();
                return;
            }
            if (!IsPaused)
            {
                Pause();
                return;
            }
        }
        if (StageState.Instance.ResetFight)
        {
            SkipIntro();
        }
    }

    public void CallFighters()
    {
        _Player.EnterStage();
        _Enemy.EnterStage();
        UI_Enter.SetTrigger("Enter");
    }

    public void EnterStage()
    {
        if (StageState.Instance.RoundEnter)
        {
            StageState.Instance.RoundEnter = false;
            Timer.SetActive(true);
            ActivateControlers();
            _Player.Set();
            _Enemy.Set();
            _RT.LaunchTimer();
            _stageTheme.CallSong();
        }
    }

    public void SkipIntro()
    {
        StageState.Instance.ResetFight = false;
        UI_Enter.Play("Skip");
        Timer.SetActive(true);
        ActivateControlers();
        _Player.Set();
        _Enemy.Set();
        _RT.LaunchTimer();
        _Player.SkipIntro();
        _Enemy.SkipIntro();
        _stageTheme.CallSong();
    }

    public void ExitStage()
    {
        UI_Enter.Play("Exit");
        _Controler.TurnWarningOff();
        _Player.TurnDebbOff();
        _Enemy.TurnDebbOff();
        _Player.IsRepairing = true;
        _Enemy.IsRepairing = true;
        _Player.ExitStage();
        _Enemy.ExitStage();
    }
    public void ActivateControlers()
    {
        Controlers.SetActive(true);
    }
    public void DeActivateControlers()
    {
        Controlers.SetActive(false);
        UI_Enter.Play("Exit");
    }
    public void Pause()
    {
        _Control.Pause();
        _Controler.Pause();
        _RT.Pause();
        PauseMenu.SetActive(true);
        IsPaused = true;
    }
    public void UnPause()
    {
        _Control.UnPause();
        _Controler.UnPause();
        _RT.UnPause();
        PauseMenu.SetActive(false);
        IsPaused = false;
    }

}
