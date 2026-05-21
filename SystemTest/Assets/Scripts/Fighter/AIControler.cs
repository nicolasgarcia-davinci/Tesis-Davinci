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
            if (attackNum <= 25 && Character.Head.life > 0) Character.Attack(Character.Head.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingUp);
            if (attackNum <= 50 && attackNum > 25 && Character.Rarm.life > 0) Character.Attack(Character.Rarm.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingRight);
            if (attackNum <= 75 && attackNum > 50 && Character.Larm.life > 0) Character.Attack(Character.Larm.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingLeft);
            if (attackNum <= 100 && attackNum > 75 && Character.Leg.life > 0) Character.Attack(Character.Leg.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingDown);
        }
    }

    public void IAPrediction(bool Up, bool Right, bool Left, bool Down)
    {
        float DodgeNum = Random.Range(0, 100);
        if(DodgeNum<_DodgeChance)
        {
            if (Up)
            {
                Character.Dodge("DoedgeUp", ref Character.IsDodgingUp);
                return;
            }

            if (Right) 
            {
                Character.Dodge("DoedgeRight", ref Character.IsDodgingRight);
                return;
            }
            if (Left) 
            {
                Character.Dodge("DoedgeLeft", ref Character.IsDodgingLeft);
                return;
            }
            
            if (Down) 
            {
                Character.Dodge("DoedgeDown", ref Character.IsDodgingDown);
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
