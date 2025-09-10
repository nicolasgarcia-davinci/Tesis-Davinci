using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;
    public Figther _Player;
    public Figther _Enemy;

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
    public void SetDownFighter(Figther loser)
    {
        if (loser.IsPlayer) LifeTraker.Instance.IsEnemy = false;
        else LifeTraker.Instance.IsEnemy = true;
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
            if (attacker.AimUp)
            {
                _Player.takeHeadDamage();
                CamaraSpin.Instance.DownSpin();
            }
            if (attacker.AimRight)
            {
                _Player.takeRightDamage();
                CamaraSpin.Instance.LeftSpin();
            }
            if (attacker.AimLeft)
            {
                _Player.takeLeftDamage();
                CamaraSpin.Instance.RightSpin();
            }
            if (attacker.AimDown)
            {
                _Player.takeLegsDamage();
                CamaraSpin.Instance.UpSpin();
            }
        }
        attacker.Stamina -= 10;
    }
}
