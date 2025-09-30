using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figther : MonoBehaviour
{
    [Header("Parts Life")]
    public string _name;
    public float MaxLife;
    public float HeadLife;
    public float RightLife;
    public float LeftLife;
    public float LegsLife;

    [Header("Stamina")]
    public float Stamina;
    public float MaxStamina;
    public float StaminaRefresh;

    [Header("Animations")]
    public bool UpAttack;
    public bool AimUp;
    public bool UpDodge;
    public bool RightAttack;
    public bool AimRight;
    public bool RightDodge;
    public bool LeftAttack;
    public bool AimLeft;
    public bool LeftDodge;
    public bool DownAttack;
    public bool AimDown;
    public bool DownDodge;
    public bool Dodgeing;
    public Animator _anim;

    [Header("Para el FightControler")]
    public bool IsPlayer;

    [Header("Mesh para el selector de Color")]
    public SkinnedMeshRenderer body;

    [Header("Damage Particles")]
    public GameObject _HeadGlich;
    public GameObject _RightGlich;
    public GameObject _LeftGlich;
    public GameObject _LegsGlich;

    [Header("Crash Particles")]
    public GameObject _HeadCrash;
    public GameObject _RightCrash;
    public GameObject _LeftCrash;
    public GameObject _LegsCrash;
    public bool HeadCrashbool;
    public bool RightCrashbool;
    public bool LeftCrashbool;
    public bool LegsCrashbool;

    [Header("Sparks Particles")]
    public GameObject _HeadSpark;
    public GameObject _RightSpark;
    public GameObject _LeftSpark;
    public GameObject _LegsSpark;


    void Start()
    {
        Stamina=MaxStamina;
        _anim = GetComponentInChildren<Animator>();
        if (RightLife > 0)
        {
            RightCrashbool = false;
            _RightSpark.gameObject.SetActive(false);
        }
        if (HeadLife > 0)
        {
            HeadCrashbool = false;
            _HeadSpark.gameObject.SetActive(false);
        }
        if (LeftLife > 0)
        {
            LeftCrashbool = false;
            _LeftSpark.gameObject.SetActive(false);
        }
        if (LegsLife > 0)
        {
            LegsCrashbool = false;
            _LegsSpark.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        _anim.speed = Stamina / MaxStamina;
        if(Stamina <= MaxStamina)
        {
            Stamina += StaminaRefresh * Time.deltaTime;
        }
    }

    public void UpperAttack()
    {
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && HeadLife>0)
        {
            UpAttack = true;
            AimUp = true;
            FightControler.Instance.IADefender(this);
        }
    }
    public void RightHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && LeftLife > 0)
        {
            RightAttack = true;
            AimRight = true;
            FightControler.Instance.IADefender(this);
        }
    }
    public void LeftHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && RightLife > 0)
        {
            LeftAttack = true;
            AimLeft = true;
            FightControler.Instance.IADefender(this);
        }
    }
    public void DownerAttack()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && LegsLife > 0)
        {
            DownAttack = true;
            AimDown = true;
            FightControler.Instance.IADefender(this);
        }
    }

    public void DodgeUp()
    {
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " DodgingUp");
            Dodgeing = true;
            UpDodge = true;
            _anim.SetTrigger("UpDodge");
        }
    }
    public void DodgeRight()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " DodgingRight");
            Dodgeing = true;
            RightDodge = true;
            _anim.SetTrigger("RightDodge"); ;
        }
    }
    public void DodgeLeft()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " DodgingLeft");
            Dodgeing = true;
            LeftDodge = true;
            _anim.SetTrigger("LeftDodge");
        }
    }
    public void DodgeDown()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            Debug.Log(_name + " DodgingDown");
            Dodgeing = true;
            DownDodge = true;
            _anim.SetTrigger("DownDodge");
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
        UpDodge = false;
        RightDodge = false;
        LeftDodge = false;
        DownDodge = false;
    }
    public void nextAnim()
    {
        if (UpAttack) _anim.SetBool("UpAttack", true);
        if (RightAttack) _anim.SetBool("RightAttack", true);
        if (LeftAttack) _anim.SetBool("LeftAttack", true);
        if (DownAttack) _anim.SetBool("DownAttak", true);
    }
    public void takeHeadDamage()
    {
        //if (UpDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if(HeadLife>0) HeadLife -= 10;
        restAttack();
        _HeadGlich.gameObject.SetActive(true);
        if (HeadLife <= 0 && HeadCrashbool) return;
        if (HeadLife <= 0 && ! HeadCrashbool)
        {
            HeadCrashbool = true;
            _HeadCrash.gameObject.SetActive(true);
            _HeadSpark.gameObject.SetActive(true);
        }
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
    }
    public void takeRightDamage()
    {
        //if (RightDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (RightLife > 0) RightLife -= 10;
        restAttack();
        _LeftGlich.gameObject.SetActive(true);
        if (RightLife <= 0 && RightCrashbool) return;
        if (RightLife <= 0 && !RightCrashbool)
        {
            RightCrashbool = true;
            _LeftCrash.gameObject.SetActive(true);
            _RightSpark.gameObject.SetActive(true);
        }
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
    }
    public void takeLeftDamage()
    {
        //if (LeftDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (LeftLife > 0) LeftLife -= 10;
        restAttack();
        _RightGlich.gameObject.SetActive(true);
        if (LeftLife <= 0 && LeftCrashbool) return;
        if (LeftLife <= 0 && !LeftCrashbool)
        {
            LeftCrashbool = true;
            _RightCrash.gameObject.SetActive(true);
            _LeftSpark.gameObject.SetActive(true);
        }
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
    }
    public void takeLegsDamage()
    {
        //if (DownDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (LegsLife > 0) LegsLife -= 10;
        restAttack();
        _LegsGlich.gameObject.SetActive(true);
        if (LegsLife <= 0 && LegsCrashbool) return;
        if (LegsLife <= 0 && !LegsCrashbool)
        {
            LegsCrashbool = true;
            _LegsCrash.gameObject.SetActive(true);
            _LegsSpark.gameObject.SetActive(true);
        }
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
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

    public void ColorChange(Color color1,Color color2)
    {
        body.material.SetColor("_Color1", color1);
        body.material.SetColor("_Color2", color2);
    }

    public void FallDown()
    {
        FightControler.Instance.SetDownFighter(this);
    }

    public void AttackEffect()
    {
        FightControler.Instance.CheckAttack(this);
    }
    public void IAInputCheck()
    {
        FightControler.Instance.IADefender(this);
    }
}
