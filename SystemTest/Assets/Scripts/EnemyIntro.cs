using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    public Animator animator;
    public void Dead()
    {
        animator.SetTrigger("Dead");
    }
}
