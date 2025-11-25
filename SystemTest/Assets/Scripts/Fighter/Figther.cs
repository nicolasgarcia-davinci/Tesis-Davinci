using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public GameObject[] _HeadCrash;
    public GameObject[] _RightCrash;
    public GameObject[] _LeftCrash;
    public GameObject[] _LegsCrash;
    public bool HeadCrashbool;
    public bool RightCrashbool;
    public bool LeftCrashbool;
    public bool LegsCrashbool;

    [Header("Sparks Particles")]
    public GameObject[] _HeadSpark;
    public GameObject[] _RightSpark;
    public GameObject[] _LeftSpark;
    public GameObject[] _LegsSpark;


    void Start()
    {
        ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
        Stamina = MaxStamina;
        SetLife();
        _anim = GetComponentInChildren<Animator>();
        if (RightLife > 0)
        {
            RightCrashbool = false;
            RightCrashbool = true;
            DeActivateSet(_RightSpark);
        }
        if (HeadLife > 0)
        {
            HeadCrashbool = false;
            HeadCrashbool = true;
            DeActivateSet(_HeadSpark);
        }
        if (LeftLife > 0)
        {
            LeftCrashbool = false;
            LeftCrashbool = true;
            DeActivateSet(_LeftSpark);
        }
        if (LegsLife > 0)
        {
            LegsCrashbool = false;
            LeftCrashbool = true;
            DeActivateSet(_LegsSpark);
        }
    }
    private void Update()
    {
        if(Stamina < MaxStamina)
        {
            Stamina += StaminaRefresh * Time.deltaTime;
        }
    }

    public void SetLife() 
    {
        if (IsPlayer)
        {
            MaxLife = LifeTraker.Instance.pOverHealt;
            HeadLife = LifeTraker.Instance.pHead;
            RightLife = LifeTraker.Instance.pRight;
            LeftLife = LifeTraker.Instance.pLeft;
            LegsLife = LifeTraker.Instance.pLegs;
        }
        if (!IsPlayer)
        {
            MaxLife = LifeTraker.Instance.eOverHealt;
            HeadLife = LifeTraker.Instance.eHead;
            RightLife = LifeTraker.Instance.eRight;
            LeftLife = LifeTraker.Instance.eLeft;
            LegsLife = LifeTraker.Instance.eLegs;
        }
    }

    public void UpperAttack()
    {
        if(!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && HeadLife>0)
        {
            UpAttack = true;
            AimUp = true;
            _anim.speed = Stamina / MaxStamina;
            FightControler.Instance.IADefender(this);
        }
    }
    public void RightHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && LeftLife > 0)
        {
            RightAttack = true;
            AimRight = true;
            _anim.speed = Stamina / MaxStamina;
            FightControler.Instance.IADefender(this);
        }
    }
    public void LeftHook()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && RightLife > 0)
        {
            LeftAttack = true;
            AimLeft = true;
            _anim.speed = Stamina / MaxStamina;
            FightControler.Instance.IADefender(this);
        }
    }
    public void DownerAttack()
    {
        if (!Dodgeing && !UpAttack && !RightAttack && !LeftAttack && !DownAttack && LegsLife > 0)
        {
            DownAttack = true;
            AimDown = true;
            _anim.speed = Stamina / MaxStamina;
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
        _anim.speed = 1;
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
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
        if (HeadLife <= 0 && HeadCrashbool)
        {
            FightControler.Instance.camSpinDOWN(this);
            return;
        }
        if (HeadLife <= 0 && ! HeadCrashbool)
        {
            FightControler.Instance.stopFrame();
            HeadCrashbool = true;
            ActivateSet(_HeadCrash);
            ActivateSet(_HeadSpark);
            return;
        }
        FightControler.Instance.camSpinDOWN(this);
    }
    public void takeRightDamage()
    {
        //if (RightDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (RightLife > 0) RightLife -= 10;
        restAttack();
        _LeftGlich.gameObject.SetActive(true);
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
        if (RightLife <= 0 && RightCrashbool)
        {
            FightControler.Instance.camSpinLEFT(this);
            return;
        }
        if (RightLife <= 0 && !RightCrashbool)
        {
            FightControler.Instance.stopFrame();
            RightCrashbool = true;
            ActivateSet(_LeftCrash);
            ActivateSet(_RightSpark);
            return;
        }
        FightControler.Instance.camSpinLEFT(this);
    }
    public void takeLeftDamage()
    {
        //if (LeftDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (LeftLife > 0) LeftLife -= 10;
        restAttack();
        _RightGlich.gameObject.SetActive(true);
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
        if (LeftLife <= 0 && LeftCrashbool)
        {
            FightControler.Instance.camSpinRIGHT(this);
            return;
        }
        if (LeftLife <= 0 && !LeftCrashbool)
        {
            FightControler.Instance.stopFrame();
            LeftCrashbool = true;
            ActivateSet(_RightCrash);
            ActivateSet(_LeftSpark);
            return;
        }
        FightControler.Instance.camSpinRIGHT(this);
    }
    public void takeLegsDamage()
    {
        //if (DownDodge) return;
        MaxLife -= 10;
        if (CheckDamage()) return;
        if (LegsLife > 0) LegsLife -= 10;
        restAttack();
        _LegsGlich.gameObject.SetActive(true);
        _anim.ResetTrigger("UpDodge");
        _anim.ResetTrigger("RightDodge");
        _anim.ResetTrigger("LeftDodge");
        _anim.ResetTrigger("DownDodge");
        _anim.SetTrigger("Damaged");
        if (LegsLife <= 0 && LegsCrashbool)
        {
            FightControler.Instance.camSpinUP(this);
            return;
        } 
        if (LegsLife <= 0 && !LegsCrashbool)
        {
            FightControler.Instance.stopFrame();
            LegsCrashbool = true;
            ActivateSet(_LegsCrash);
            ActivateSet(_LegsSpark);
            return;
        }
        FightControler.Instance.camSpinUP(this);
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
        body.material.SetFloat("_Transparencia", 0.85f);
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

    public void ActivateSet(GameObject[] set)
    {
        foreach (GameObject item in set)
        {
            item.SetActive(true);
        }
    }
    public void DeActivateSet(GameObject[] set)
    {
        foreach (GameObject item in set)
        {
            item.SetActive(false);
        }
    }

    public IEnumerator BreakStop()
    {
        _anim.speed = 0;
        yield return new WaitForSeconds (0.5f);
        _anim.speed = 1;
    }
    public void FreezeFrame()
    {
        StartCoroutine(BreakStop());
    }

    public void Pause()
    {
        _anim.speed = 0;
    }
    public void UnPause()
    {
        _anim.speed = 1;
    }
}
