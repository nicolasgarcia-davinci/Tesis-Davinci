using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;
    public Figther _Player;
    public Figther _Enemy;
    public AIControler _Controler;
    public PlayerControler _Control;
    public PlayerSpawner _Spawner;
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
        _Spawner.SpawnPlayer();
    }

    public void IADefender(Figther attacker)
    {
        if (attacker == _Player)
            _Controler.IAPrediction(_Player.AimUp, _Player.AimRight, _Player.AimLeft, _Player.AimDown);
    }
    public void SetDownFighter(Figther loser)
    {
        if (loser.IsPlayer)
        {
            LifeTraker.Instance.IsEnemy = false;
            LifeTraker.Instance.PlayerKO++;
        }
        else
        {
            LifeTraker.Instance.IsEnemy = true;
            LifeTraker.Instance.EnemyKO++;
        }
        if(LifeTraker.Instance.Dificulty==1) LoadManager.Instance.LoadKO();
        if(LifeTraker.Instance.Dificulty==2) LoadManager.Instance.LoadGymKo();

    }

    public void CheckAttack(Figther attacker)
    {
        if(attacker.IsPlayer)
        {
            if (attacker.AimUp) _Enemy.takeHeadDamage();
            if (attacker.AimRight) _Enemy.takeRightDamage();
            if (attacker.AimLeft) _Enemy.takeLeftDamage();
            if (attacker.AimDown) _Enemy.takeLegsDamage();
        }

        if (!attacker.IsPlayer)
        {
            if (attacker.AimUp && !_Player.UpDodge)
            {
                _Player.takeHeadDamage();
                if (_Player.HeadLife == 0) return;
            }
            if (attacker.AimRight && !_Player.RightDodge)
            {
                _Player.takeRightDamage();
                if (_Player.RightLife == 0) return;
            }
            if (attacker.AimLeft && !_Player.LeftDodge)
            {
                _Player.takeLeftDamage();
                if (_Player.LeftLife == 0) return;
            }
            if (attacker.AimDown && !_Player.DownDodge)
            {
                _Player.takeLegsDamage();
                if (_Player.LegsLife == 0) return;  
            }
        }
        attacker.Stamina -= 10;
    }
    public void camSpinUP(Figther smack)
    {
        if ( smack == _Player ) CamaraSpin.Instance.UpSpin();
    }
    public void camSpinDOWN(Figther smack)
    {
        if (smack == _Player) CamaraSpin.Instance.DownSpin();
    }
    public void camSpinRIGHT(Figther smack)
    {
        if (smack == _Player) CamaraSpin.Instance.RightSpin();
    }
    public void camSpinLEFT(Figther smack)
    {
        if (smack == _Player) CamaraSpin.Instance.LeftSpin();
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
            if(IsPaused) UnPause();
            if(!IsPaused) Pause();
        }
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
