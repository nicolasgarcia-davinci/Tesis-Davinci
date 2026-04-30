using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    //public CompositeFighter _fighter;
    //public Figther _boss;
    public Fallen _ko;
    void Start()
    {
        _ko=GetComponentInParent<Fallen>();
    }

    public void BackToTheFight()
    {
        if(LifeTraker.Instance.IsEnemy)
        {
        StageCam.Instance.EnemyBackToFight();
        }else StageCam.Instance.PlayerBackToFight();
    }

    public void CallForReset()
    {
        //_boss.restAttack();
    }
    public void endAnim()
    {
        //_boss.EndReset();
    }
    public void Flee()
    {
        //_boss.IAInputCheck();
    }

    public void CallAttack()
    {
        //_boss.AttackEffect();
    }
    public void goToAnim()
    {
        //_boss.nextAnim();
    }
    public void knokOut()
    {
        //_boss.FallDown();
    }
    public void PauseAnimation()
    {
        _ko.Stop();
    }

    public void Round2()
    {
        LoadManager.Instance.Round2();
    }
}
