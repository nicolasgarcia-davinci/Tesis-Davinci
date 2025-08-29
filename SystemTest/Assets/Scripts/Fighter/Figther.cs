using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figther : MonoBehaviour
{
    public string _name;
    public float MaxLife;
    public float HeadLife;
    public float RightLife;
    public float LeftLife;
    public float LegsLife;
    public bool UpAttack;
    public bool AimUp;
    public bool RightAttack;
    public bool AimRight;
    public bool LeftAttack;
    public bool AimLeft;
    public bool DownAttack;
    public bool AimDown;
    public bool Dodgeing;
    public bool IsPlayer;
    public Animator _anim;
    void Start()
    {

    }

    public void UpperAttack()
    {
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name +" UP ATTACK");
            UpAttack = true;
            AimUp = true;
            _anim.SetBool("UpAttack", true);
        }
    }
    public void RightHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " RIGHT ATTACK");
            RightAttack = true;
            AimRight = true;
            _anim.SetBool("RightAttack", true);
        }
    }
    public void LeftHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " LEFT ATTACK");
            LeftAttack = true;
            AimLeft = true;
            _anim.SetBool("LeftAttack", true);
        }
    }
    public void DownerAttack()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " DOWN ATTACK");
            DownAttack = true;
            AimDown = true;
            _anim.SetBool("DownAttak", true);
        }
    }

    public void Dodge()
    {
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " IS DOEGING");
            Dodgeing = true;
            _anim.SetBool("Dodge", true);
        }
    }

    public void restAttack()
    {
        UpAttack = false;
        _anim.SetBool("UpAttack", false);
        RightAttack = false;
        _anim.SetBool("RightAttack", false);
        LeftAttack = false;
        _anim.SetBool("LeftAttack", false);
        DownAttack = false;
        _anim.SetBool("DownAttak", false);
    }
    public void EndReset()
    {
        AimUp = false;
        AimRight = false;
        AimLeft = false;
        AimDown = false;
        Dodgeing = false;
    }
    public void takeHeadDamage()
    {
        if (Dodgeing) return;
        restAttack();
        HeadLife -= 10;
        MaxLife -= 10;
        if (CheckDamage()) return;
        _anim.SetTrigger("Damaged");
    }
    public void takeRightDamage()
    {
        if (Dodgeing) return;
        restAttack();
        RightLife -= 10;
        MaxLife -= 10;
        if (CheckDamage()) return;
        _anim.SetTrigger("Damaged");
    }
    public void takeLeftDamage()
    {
        if (Dodgeing) return;
        restAttack();
        LeftLife -= 10;
        MaxLife -= 10;
        if (CheckDamage()) return;
        _anim.SetTrigger("Damaged");
    }
    public void takeLegsDamage()
    {
        if (Dodgeing) return;
        restAttack();
        LegsLife -= 10;
        MaxLife -= 10;
        if (CheckDamage()) return;
        _anim.SetTrigger("Damaged");
    }

    public bool CheckDamage()
    {
        if (MaxLife <= 0)
        {
            _anim.SetTrigger("Die");
            return true;
        }
        return false;
    }

    public void AttackEffect()
    {
        FightControler.Instance.CheckAttack(this);
    }
}
