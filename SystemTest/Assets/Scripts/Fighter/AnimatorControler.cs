using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{

    public Figther _boss;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
