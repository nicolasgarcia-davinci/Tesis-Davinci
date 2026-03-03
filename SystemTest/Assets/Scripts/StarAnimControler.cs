using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimControler : MonoBehaviour
{
    public GameObject screen;
    public Animator animator;
    public int timeToIntro;
    public void stopanim()
    {
        animator.speed = 0;
    }
    public void Fanfare()
    {
        StartCoroutine(FinalStop());
    }
    public void Check1()
    {
        if(LifeTraker.Instance.Dificulty == 1)
        {
            stopanim();
            StartCoroutine(ScreenDisplay());
        }
    }
    public void Check2()
    {
        if (LifeTraker.Instance.Dificulty == 2)
        {
            stopanim();
            StartCoroutine(ScreenDisplay());
        }
    }
    public IEnumerator ScreenDisplay()
    {
        yield return new WaitForSeconds(timeToIntro);
        screen.SetActive(true);
    }
    public IEnumerator FinalStop()
    {
        stopanim();
        yield return new WaitForSeconds(timeToIntro);
        LoadManager.Instance.ENDGAME();
    }
}
