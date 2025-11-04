using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GloveAnim : MonoBehaviour
{
    public Animator anim;
    public Image Body;
    public Color On;
    public Color Off;

    public void Hit()
    {
        anim.SetTrigger("Slap");
    }

    //public void DeActivate()
    //{
    //    Body.color=Off;
    //}
    //public void Activate()
    //{
    //    Body.color = On;
    //}
}
