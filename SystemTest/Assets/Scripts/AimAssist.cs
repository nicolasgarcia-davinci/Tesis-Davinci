using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssist : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        if (LifeTraker.Instance.Dificulty == 1)
            animator.SetBool("ToGarage", true);
        if (LifeTraker.Instance.Dificulty == 2)
            animator.SetBool("ToGym", true);
        if (LifeTraker.Instance.Dificulty == 3)
            animator.SetBool("ToVictory", true);
    }
}
