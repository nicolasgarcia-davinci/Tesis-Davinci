using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelAnim : MonoBehaviour
{
    public Animator anim;
    public void Enter()
    {
        anim.SetTrigger("Enter");
    }
    public void Exit()
    {
        anim.SetTrigger("Exit");
    }
    public void Out()
    {
        anim.Play("Out");
    }
}
