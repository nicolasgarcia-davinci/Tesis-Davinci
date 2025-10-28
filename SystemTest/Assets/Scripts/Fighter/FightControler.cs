using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;
    public Figther _Player;
    public Figther _Enemy;
    public AIControler _Controler;

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
    // Start is called before the first frame update
    void Start()
    {
        _Player.ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
        _Player.MaxLife = LifeTraker.Instance.pOverHealt;
        _Player.HeadLife = LifeTraker.Instance.pHead;
        _Player.RightLife = LifeTraker.Instance.pRight;
        _Player.LeftLife = LifeTraker.Instance.pLeft;
        _Player.LegsLife = LifeTraker.Instance.pLegs;
        _Enemy.MaxLife = LifeTraker.Instance.eOverHealt;
        _Enemy.HeadLife = LifeTraker.Instance.eHead;
        _Enemy.RightLife = LifeTraker.Instance.eRight;
        _Enemy.LeftLife = LifeTraker.Instance.eLeft;
        _Enemy.LegsLife = LifeTraker.Instance.eLegs;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        LoadManager.Instance.LoadKO();
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
}
