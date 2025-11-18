using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAnim : MonoBehaviour
{
    public Animator Anim;
    public SkinnedMeshRenderer body;
    public GameObject Head;
    public GameObject Right;
    public GameObject Left;
    public GameObject Legs;

    void Start()
    {
        body.material.SetColor("_Color1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color2", ColorCordination.Instance.color2);
        body.material.SetFloat("_Transparencia", 1);
        InputCheker.Instance.player=this;
    }

    public void SetRepairUp()
    {
        Anim.SetBool("RepairUp", true);
        Head.SetActive(true);
    }
    public void SetRepairRight()
    {
        Anim.SetBool("RepairRight", true);
        Right.SetActive(true);
    }
    public void SetRepairLeft()
    {
        Anim.SetBool("RepairLeft", true);
        Left.SetActive(true);
    }
    public void SetRepairDown()
    {
        Anim.SetBool("RepairDown", true);
        Legs.SetActive(true);
    }
    public void ResetRepair()
    {
        Anim.SetBool("RepairUp", false);
        Anim.SetBool("RepairRight", false);
        Anim.SetBool("RepairLeft", false);
        Anim.SetBool("RepairDown", false);
        Head.SetActive(false);
        Right.SetActive(false);
        Left.SetActive(false);
        Legs.SetActive(false);
    }
}
