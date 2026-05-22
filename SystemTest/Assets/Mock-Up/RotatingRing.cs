using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotatingRing : MonoBehaviour
{
    public Animator RRIng;
    public int Current;
    public GameObject[] Stages;
    public TextMeshProUGUI lab;
    public Color Transparency;
    public bool toTranparent;
    public float BlinkInterval;
    public float transparancyRate;
    void Start()
    {
        UpdateDisPlay();
        StartCoroutine(TextFlash());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) RotateLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) RotateRigth();
        if (Input.GetKeyDown(KeyCode.Space)) LoadManager.Instance.LoadRing();
        if (toTranparent)
        {
            Transparency.a -= transparancyRate;
            lab.color = Transparency;
        }
        if (!toTranparent)
        {
            Transparency.a += transparancyRate;
            lab.color = Transparency;
        }
    }
    public void RotateRigth()
    {
        Current++;
        if (Current == LifeTraker.Instance.Dificulty)
        {
            Current--;
            return;
        }
        else
        {
            RRIng.SetTrigger("NextLvl");
            UpdateDisPlay();
        }
    }
    public void RotateLeft()
    {
        Current--;
        if (Current < 0)
        {
            Current++;
            return;
        }
        else
        {
            RRIng.SetTrigger("PrevLvl");
            UpdateDisPlay();
        }
    }

    public void UpdateDisPlay()
    {
        foreach (var item in Stages)
        {
            item.SetActive(false);
        }
        Stages[Current].SetActive(true);
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
