using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public StartGameBot[] Bots;
    void Start()
    {
        StartCoroutine(TextFlash());
    }

    void Update()
    {
        if (Input.anyKeyDown && !HasEnded)
        {
            HasEnded = true;
            foreach (StartGameBot Dummy in Bots) Dummy.Ring();
            menu.SetBool("HasIntro", true);
            StopAllCoroutines();
            start.color = endcolor;

            enabled = false;
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
