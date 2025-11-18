using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour
{
    public Figther Character;
    public float _timer;
    public float _AttackInterval;
    public bool IsPaused;

    void Start()
    {
        Character.HeadLife = LifeTraker.Instance.eHead;
        Character.RightLife = LifeTraker.Instance.eRight;
        Character.LeftLife = LifeTraker.Instance.eLeft;
        Character.LegsLife = LifeTraker.Instance.eLegs;
        FightControler.Instance._Enemy = Character;
        FightControler.Instance._Controler = this;
    }


    void Update()
    {
        if (IsPaused) return;
        _timer += Time.deltaTime;
        if(_timer>=_AttackInterval)
        {
            _timer = 0;
            float attackNum = Random.Range(0,100);
            if (attackNum <= 25) Character.UpperAttack();
            if (attackNum <= 50 && attackNum > 25) Character.RightHook();
            if (attackNum <= 75 && attackNum > 50) Character.LeftHook();
            if (attackNum <= 100 && attackNum > 75) Character.DownerAttack();
        }
    }

    public void IAPrediction(bool Up, bool Right, bool Left, bool Down)
    {
        float DodgeNum = Random.Range(0, 100);
        if(DodgeNum>70)
        {
            if (Up) Character.DodgeUp();
            if (Right) Character.DodgeRight();
            if (Left) Character.DodgeLeft();
            if (Down) Character.DodgeDown();
        }
    }
    public void Pause()
    {
        IsPaused = true;
        Character.Pause(); 
    }
    public void UnPause()
    {
        IsPaused = false;
        Character.UnPause();
    }
}
