using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour
{
    public CompositeFighter Character;
    public float _timer;
    public float _AttackInterval;
    [Range(0, 100)] public int _DodgeChance;
    public bool IsPaused;

    void Start()
    {
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
            if (attackNum <= 25) Character.Headattack();
            if (attackNum <= 50 && attackNum > 25) Character.RArmattack();
            if (attackNum <= 75 && attackNum > 50) Character.LArmattack();
            if (attackNum <= 100 && attackNum > 75) Character.Legattack();
        }
    }

    public void IAPrediction(bool Up, bool Right, bool Left, bool Down)
    {
        float DodgeNum = Random.Range(0, 100);
        if(DodgeNum<_DodgeChance)
        {
            if (Up)
            {
                Character.DodgeUp();
                return;
            }

            if (Right) 
            {
                Character.DodgeRight();
                return;
            }
            if (Left) 
            {
                Character.DodgeLeft();
                return;
            }
            
            if (Down) 
            {
                Character.DodgeDown();
                return;
            }
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
