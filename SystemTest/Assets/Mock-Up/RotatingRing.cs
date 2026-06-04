using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RotatingRing : MonoBehaviour
{
    public Animator RRIng;
    public int Current;
    public GameObject[] Stages;
    public GameObject Lock;
    public TextMeshProUGUI lab;
    public Color Transparency;
    public bool toTranparent;
    public bool CanEnter;
    public float BlinkInterval;
    public float transparancyRate;
    void Start()
    {
        UpdateDisPlay();
        StartCoroutine(TextFlash());
        CanEnter = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) RotateUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) RotateDown();
        if (Input.GetKeyDown(KeyCode.Space) && CanEnter) LoadManager.Instance.ToLVL(Current + 1); ;
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
    public void RotateUp()
    {
        Current++;
        if (Current == Stages.Count())
        {
            Current--;
            return;
        }
        if (Current == 1)
        {
            RRIng.Play("RTLv2");
            UpdateDisPlay();
        }
        if (Current == 2)
        {
            RRIng.Play("RTLv3");
            UpdateDisPlay();
        }
        if (Current == 3)
        {
            RRIng.Play("RTLv4");
            UpdateDisPlay();
        }
    }
    public void RotateDown()
    {
        Current--;
        if (Current < 0)
        {
            Current++;
            return;
        }
        if(Current==0)
        {
            RRIng.Play("RTLv1");
            UpdateDisPlay();
        }
        if (Current == 1)
        {
            RRIng.Play("BLvl2");
            UpdateDisPlay();
        }
        if (Current == 2)
        {
            RRIng.Play("BLvl3");
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
        if (Current >= LifeTraker.Instance.Dificulty)
        {
            Lock.SetActive(true);
            CanEnter = false;
        }
        else
        {
            Lock.SetActive(false);
            CanEnter = true;
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
