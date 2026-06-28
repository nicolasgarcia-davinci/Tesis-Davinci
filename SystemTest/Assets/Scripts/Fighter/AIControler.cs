using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour
{
    public CompEnemy Character;
    public Boss TheBoss;
    public float _timer;
    public float _flashDuration;
    public float _AttackInterval;
    public float _DefAttackInterval;
    [Range(0, 100)] public int _DodgeChance;
    public bool IsPaused;
    public bool isBoss;
    public bool RageMode;
    public int NumOfRage;
    public Material AttackMat;
    public Vector2 attackDir;

    void Start()
    {
        FightControler.Instance._Enemy = Character;
        FightControler.Instance._Controler = this;
        _AttackInterval=_DefAttackInterval;
    }


    void Update()
    {
        if (IsPaused) return;
        if(isBoss && TheBoss.OverAllHealth <= TheBoss.CChest/2 && !RageMode && NumOfRage==0) EnterRageMode();
        if(isBoss && TheBoss.OverAllHealth <= TheBoss.CChest/3 && !RageMode && NumOfRage==1) EnterRageMode();
        if(isBoss && TheBoss.Stamina<=0) ExitRageMode();
        _timer += Time.deltaTime;
        if (_timer>=_AttackInterval)
        {
            _timer = 0;
            float attackNum = Random.Range(0,100);
            if(isBoss)
            {
                if (attackNum <= 25)
                {
                    TheBoss.Attack(TheBoss.Head.AttName, TheBoss.Head.ParticleContainer, ref TheBoss.IsAttackingUp);
                    attackDir = new Vector2(0, 1);
                    AttackMat.SetVector("_Direction", attackDir);
                    StartCoroutine(InvertFlash());
                    return;
                }
                if (attackNum <= 50 && attackNum > 25)
                {
                    TheBoss.Attack(TheBoss.Rarm.AttName, TheBoss.Rarm.ParticleContainer, ref TheBoss.IsAttackingRight);
                    attackDir = new Vector2(1, 0);
                    AttackMat.SetVector("_Direction", attackDir);
                    StartCoroutine(Flash());
                    StartCoroutine(InvertFlash());
                    return;
                }
                if (attackNum <= 75 && attackNum > 50)
                {
                    TheBoss.Attack(TheBoss.Larm.AttName, TheBoss.Larm.ParticleContainer, ref TheBoss.IsAttackingLeft);
                    attackDir = new Vector2(1, 0);
                    AttackMat.SetVector("_Direction", attackDir);
                    StartCoroutine(Flash());
                    return;
                }
                if (attackNum <= 100 && attackNum > 75)
                {
                    TheBoss.Attack(TheBoss.Leg.AttName, TheBoss.Leg.ParticleContainer, ref TheBoss.IsAttackingDown);
                    attackDir = new Vector2(0, 1);
                    AttackMat.SetVector("_Direction", attackDir);
                    StartCoroutine(Flash());
                    return;
                }
            }
            if (attackNum <= 25)
            {
                Character.Attack(Character.Head.AttName, Character.Head.ParticleContainer, ref Character.IsAttackingUp);
                attackDir = new Vector2(0, 1);
                AttackMat.SetVector("_Direction", attackDir);
                StartCoroutine(InvertFlash());
                return;
            }
            if (attackNum <= 50 && attackNum > 25)
            {
                Character.Attack(Character.Rarm.AttName, Character.Rarm.ParticleContainer, ref Character.IsAttackingRight);
                attackDir = new Vector2(1, 0);
                AttackMat.SetVector("_Direction", attackDir);
                StartCoroutine(Flash());
                StartCoroutine(InvertFlash());
                return;
            }
            if (attackNum <= 75 && attackNum > 50)
            {
                Character.Attack(Character.Larm.AttName, Character.Larm.ParticleContainer, ref Character.IsAttackingLeft);
                attackDir = new Vector2(1, 0);
                AttackMat.SetVector("_Direction", attackDir);
                StartCoroutine(Flash());
                return;
            }
            if (attackNum <= 100 && attackNum > 75)
            {
                Character.Attack(Character.Leg.AttName, Character.Leg.ParticleContainer, ref Character.IsAttackingDown);
                attackDir = new Vector2(0, 1);
                AttackMat.SetVector("_Direction", attackDir);
                StartCoroutine(Flash());
                return;
            }
        }
    }

    public void IAPrediction(bool Up, bool Right, bool Left, bool Down)
    {
        float DodgeNum = Random.Range(0, 100);
        if(isBoss)
        {
            if (DodgeNum < _DodgeChance)
            {
                if (Up)
                {
                    TheBoss.Dodge("DoedgeUp", ref TheBoss.IsDodgingUp);
                    return;
                }

                if (Right)
                {
                    TheBoss.Dodge("DoedgeRight", ref TheBoss.IsDodgingRight);
                    return;
                }
                if (Left)
                {
                    TheBoss.Dodge("DoedgeLeft", ref TheBoss.IsDodgingLeft);
                    return;
                }

                if (Down)
                {
                    TheBoss.Dodge("DoedgeDown", ref TheBoss.IsDodgingDown);
                    return;
                }
            }
        }
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

    public void EnterRageMode()
    {
        RageMode = true;
        NumOfRage ++;
        _AttackInterval = 0;
        TheBoss.GoBerserk();
    }
    public void ExitRageMode()
    {
        RageMode = false;
        _AttackInterval = _DefAttackInterval;
        TheBoss.ChillPill();
    }

    public IEnumerator Flash()
    {
        AttackMat.SetFloat("_Edge_Softness", 13f);
        AttackMat.SetFloat("_Progres", 0.5f);
        yield return new WaitForSeconds (_flashDuration);
        attackDir = new Vector2(0, 0);
        AttackMat.SetVector("_Direction", attackDir);
        AttackMat.SetFloat("_Edge_Softness", 0);
        AttackMat.SetFloat("_Progres", 0);
    }
    public IEnumerator InvertFlash()
    {
        AttackMat.SetFloat("_Edge_Softness", -13f);
        AttackMat.SetFloat("_Progres", 0.5f);
        yield return new WaitForSeconds(_flashDuration);
        attackDir = new Vector2(0, 0);
        AttackMat.SetVector("_Direction", attackDir); 
        AttackMat.SetFloat("_Edge_Softness", 0);
        AttackMat.SetFloat("_Progres", 0);
    }

    public void TurnWarningOff()
    {
        _timer = 0;
        IsPaused = true;
        attackDir = new Vector2(0, 0);
        StopAllCoroutines();
        AttackMat.SetVector("_Direction", attackDir);
        AttackMat.SetFloat("_Edge_Softness", 0);
        AttackMat.SetFloat("_Progres", 0);
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
