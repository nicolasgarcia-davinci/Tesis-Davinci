using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;

    public CompositeFighter _Player;
    public CompositeFighter _Enemy;

    public AIControler _Controler;
    public PlayerControler _Control;

    public RoundTimer _RT;
    public GameObject PauseMenu;
    public bool IsPaused;

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

    }

    public void IADefender(CompositeFighter attacker)
    {
        if (attacker == _Player)
            _Controler.IAPrediction(_Player.IsAttackingUp, _Player.IsAttackingRight, _Player.IsAttackingLeft, _Player.IsAttackingDown);
    }
    public void SetDownFighter(CompositeFighter loser)
    {
        if (!loser.IsEnemy)
        {
            LifeTraker.Instance.IsEnemy = false;
            LifeTraker.Instance.PlayerKO++;
        }
        else
        {
            LifeTraker.Instance.IsEnemy = true;
            LifeTraker.Instance.EnemyKO++;
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

        //_Enemy.hasBeenSet = false;
        //_Player.hasBeenSet = false;

        StageCam.Instance.GoToKOCam();
        _RT.Stop();
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
        attacker.Stamina -= 10;
    }
    public void stopFrame()
    {
        _Player.FreezeFrame();
        _Enemy.FreezeFrame();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(IsPaused)
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
        if(StageState.Instance.ResetFight)
        {
            StageState.Instance.ResetFight = false;
            _RT.LaunchTimer();
            _Player.Set();
            _Enemy.Set();
        }
    }

    public void ExitStage()
    {
        _Player.IsRepairing = true;
        _Enemy.IsRepairing = true;
        _Player.anim.SetTrigger("Exit Stage");
        _Enemy.anim.SetTrigger("Exit Stage");
    }
    public void Pause()
    {
        _Control.Pause();
        _Controler.Pause();
        _RT.Pause();
        PauseMenu.SetActive(true);
        IsPaused = true;
        Pixelation.Instance.Pixelate();
    }
    public void UnPause()
    {
        _Control.UnPause();
        _Controler.UnPause();
        _RT.UnPause();
        PauseMenu.SetActive(false);
        IsPaused = false;
        Pixelation.Instance.HighDefinition();
    }

}
