using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RotatingRing : MonoBehaviour
{
    public Animator RRIng;
    public int Current;
    public TextMeshProUGUI lab;
    public Color Transparency;
    public bool toTranparent;
    public bool CanEnter;
    public bool Entering;
    public float BlinkInterval;
    public float transparancyRate;

    public LabelAnim[] label;
    void Start()
    {
        if (LifeTraker.Instance.Dificulty == 4)
        {
            RRIng.Play("RTLv4");
            Current = 3;
        }
        if (LifeTraker.Instance.Dificulty == 3)
        {
            RRIng.Play("RTLv3");
            Current = 2;
        }
        if (LifeTraker.Instance.Dificulty == 2)
        {
            RRIng.Play("RTLv2");
            Current = 1;
        }
        if (LifeTraker.Instance.Dificulty == 1)
        {
            EnterLabel(1);
        }
        StartCoroutine(TextFlash());
        CanEnter = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadManager.Instance.Garage();
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
        if (Current == label.Count())
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
        if (Current >= LifeTraker.Instance.Dificulty)
        {
            CanEnter = false;
        }
        else
        {
            CanEnter = true;
        } 
    }

    public void EnterLabel(int index)
    {
        Entering = false;
        label[index-1].Enter();
    }

    public void ExitLabel(int index)
    {
        if (Entering) return;
        label[index - 1].Exit();
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
