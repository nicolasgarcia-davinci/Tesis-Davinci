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
    public bool RightAttack;
    public bool AimRight;
    public bool LeftAttack;
    public bool AimLeft;
    public bool DownAttack;
    public bool AimDown;
    public bool Dodgeing;
    public Animator _anim;

    [Header("Para el FightControler")]
    public bool IsPlayer;

    [Header("Mesh para el selector de Color")]
    public SkinnedMeshRenderer body;

    [Header("Damage Particles")]
    public GameObject _headSmoke;
    public GameObject _RightSmoke;
    public GameObject _LeftSmoke;
    public GameObject _LegsSmoke;

    [Header("Sparks Particles")]
    public GameObject _headSpark;
    public GameObject _RightSpark;
    public GameObject _LeftSpark;
    public GameObject _LegsSpark;


    public GameObject _Spark;

    void Start()
    {
        Stamina=MaxStamina;
        _anim = GetComponentInChildren<Animator>();
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
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            UpAttack = true;
            AimUp = true;
        }
    }
    public void RightHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            RightAttack = true;
            AimRight = true;
        }
    }
    public void LeftHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            LeftAttack = true;
            AimLeft = true;
        }
    }
    public void DownerAttack()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack)
        {
            DownAttack = true;
            AimDown = true;
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
    public void nextAnim()
    {
        if (UpAttack) _anim.SetBool("UpAttack", true);
        if (RightAttack) _anim.SetBool("RightAttack", true);
        if (LeftAttack) _anim.SetBool("LeftAttack", true);
        if (DownAttack) _anim.SetBool("DownAttak", true);
    }
    public void takeHeadDamage()
    {
        if (CheckDamage()) return;
        if (Dodgeing) return;
        restAttack();
        if (HeadLife <= 0) return;
        HeadLife -= 10;
        MaxLife -= 10;
        _anim.SetTrigger("Damaged");
        _Spark.SetActive(true);
    }
    public void takeRightDamage()
    {
        if (CheckDamage()) return;
        if (Dodgeing) return;
        restAttack();
        if (RightLife <= 0) return;
        RightLife -= 10;
        MaxLife -= 10;
        _anim.SetTrigger("Damaged");
        _Spark.SetActive(true);
    }
    public void takeLeftDamage()
    {
        if (CheckDamage()) return;
        if (Dodgeing) return;
        restAttack();
        if(LeftLife<=0) return;
        LeftLife -= 10;
        MaxLife -= 10;
        _anim.SetTrigger("Damaged");
        _Spark.SetActive(true);
    }
    public void takeLegsDamage()
    {
        if (CheckDamage()) return;
        if (Dodgeing) return;
        restAttack();
        if (LegsLife <= 0) return;
        LegsLife -= 10;
        MaxLife -= 10;
        _anim.SetTrigger("Damaged");
        _Spark.SetActive(true);
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
}
