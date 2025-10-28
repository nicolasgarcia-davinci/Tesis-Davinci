using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAnim : MonoBehaviour
{
    public Animator Anim;
    public SkinnedMeshRenderer body;

    void Start()
    {
        body.material.SetColor("_Color1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color2", ColorCordination.Instance.color2);
        body.material.SetFloat("_Transparencia", 1);
    }

    public void SetRepairUp()
    {
        Anim.SetBool("RepairUp", true);
    }
    public void SetRepairRight()
    {
        Anim.SetBool("RepairRight", true);
    }
    public void SetRepairLeft()
    {
        Anim.SetBool("RepairLeft", true);
    }
    public void SetRepairDown()
    {
        Anim.SetBool("RepairDown", true);
    }
    public void ResetRepair()
    {
        Anim.SetBool("RepairUp", false);
        Anim.SetBool("RepairRight", false);
        Anim.SetBool("RepairLeft", false);
        Anim.SetBool("RepairDown", false);
    }
}
