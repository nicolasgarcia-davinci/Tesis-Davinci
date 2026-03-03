using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI start;
    public Color Transparency;
    public Color endcolor;
    public bool toTranparent; 
    public bool HasEnded; 
    public float BlinkInterval;
    public float transparancyRate;
    public Animator menu;
    public MenuNavigation men;
    void Start()
    {
        StartCoroutine(TextFlash());
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            HasEnded = true;
            menu.SetBool("HasIntro", true);
            StopAllCoroutines();
            start.color = endcolor;
        }
        if (toTranparent && !HasEnded)
        {
            Transparency.a -= transparancyRate;
            start.color = Transparency;
        }
        if (!toTranparent && !HasEnded)
        {
            Transparency.a += transparancyRate;
            start.color = Transparency;
        }
    }
    public IEnumerator TextFlash()
    {
        toTranparent = true;
        yield return new WaitForSeconds(BlinkInterval);
        toTranparent = false;
        yield return new WaitForSeconds(BlinkInterval);
        StartCoroutine(TextFlash());
    }
}
