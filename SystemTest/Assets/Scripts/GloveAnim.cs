using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GloveAnim : MonoBehaviour
{
    public Animator anim;
    public Image Body;

    public void Hit()
    {
        anim.SetTrigger("Slap");
    }
}
