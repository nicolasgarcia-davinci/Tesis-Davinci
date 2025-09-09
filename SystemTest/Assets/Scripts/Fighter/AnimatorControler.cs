using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{

    public Figther _boss;
    public Fallen _ko;
    // Start is called before the first frame update
    void Start()
    {
        _boss=GetComponentInParent<Figther>();
        _ko=GetComponentInParent<Fallen>();
    }

    public void CallForReset()
    {
        _boss.restAttack();
    }
    public void endAnim()
    {
        _boss.EndReset();
    }
    
    public void CallAttack()
    {
        _boss.AttackEffect();
    }
    public void goToAnim()
    {
        _boss.nextAnim();
    }
    public void knokOut()
    {
        _boss.FallDown();
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
