using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelector : MonoBehaviour
{
    public GameObject[] Selectors;

    public StatDisplay Display;

    public Animator animator;
    
    public int SIndex;
    public int HIndex;
    public int LAIndex;
    public int RAIndex;
    public int LIndex;

    public Head[] heads;
    public Arm[] lArms;
    public Arm[] rArms;
    public Leg[] legs;

    public bool HeadSelected;
    public bool LarmsSelected;
    public bool RarmsSelected;
    public bool LegsSelected;
    void Start()
    {
        foreach (var p in Selectors)
        {
            p.gameObject.SetActive(false);
        }
        Selectors[0].gameObject.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow)) SelectUp();
        if(Input.GetKeyUp(KeyCode.DownArrow)) SelectDown();
        if(Input.GetKeyUp(KeyCode.RightArrow)) SelectRight();
        if(Input.GetKeyUp(KeyCode.LeftArrow)) SelectLeft();
    }
    public void SelectUp()
    {
        SIndex++;
        if (SIndex == 0)
        {
            RarmsSelected = true;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = false;
        }
        if (SIndex == 1)
        {
            RarmsSelected = false;
            LarmsSelected = true;
            LegsSelected = false;
            HeadSelected = false;
        }
        if (SIndex == 2)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = true;
            HeadSelected = false;
        }
        if (SIndex == 3)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = true;
        }
        if (SIndex > Selectors.Length-1)
        {
            SIndex = Selectors.Length-1;
            return;
        }
        foreach (var p in Selectors)
        {
            p.gameObject.SetActive(false);
        }
        Selectors[SIndex].gameObject.SetActive(true);
        
    }
    public void SelectDown()
    {
        SIndex--;
        if (SIndex == 0)
        {
            RarmsSelected = true;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = false;
        }
        if (SIndex == 1)
        {
            RarmsSelected = false;
            LarmsSelected = true;
            LegsSelected = false;
            HeadSelected = false;
        }
        if (SIndex == 2)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = true;
            HeadSelected = false;
        }
        if (SIndex == 3)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = true;
        }
        if (SIndex < 0)
        {
            SIndex = 0;
            return; 
        }
        foreach (var p in Selectors)
        {
            p.gameObject.SetActive(false);
        }
        Selectors[SIndex].gameObject.SetActive(true);
    }
    public void SelectRight()
    {
        if(RarmsSelected)
        {
            RAIndex++;
            if (RAIndex > rArms.Length - 1)
            {
                RAIndex = rArms.Length - 1;
                return;
            }
            foreach (var p in rArms)
            {
                p.gameObject.SetActive(false);
            }
            rArms[RAIndex].gameObject.SetActive(true);
            Display.SetDisplay(rArms[RAIndex].life, rArms[RAIndex].Aspeed, rArms[RAIndex].PartName);
            animator.Play(rArms[RAIndex].AttName);
            return;
        }
        if (LarmsSelected)
        {
            LAIndex++;
            if (LAIndex > lArms.Length - 1)
            {
                LAIndex = lArms.Length - 1;
                return;
            }
            foreach (var p in lArms)
            {
                p.gameObject.SetActive(false);
            }
            lArms[LAIndex].gameObject.SetActive(true);
            Display.SetDisplay(lArms[LAIndex].life, lArms[LAIndex].Aspeed, lArms[LAIndex].PartName);
            return;
        }
        if (HeadSelected)
        {
            HIndex++;
            if (HIndex > heads.Length - 1)
            {
                HIndex = heads.Length - 1;
                return;
            }
            foreach (var p in heads)
            {
                p.gameObject.SetActive(false);
            }
            heads[HIndex].gameObject.SetActive(true);
            Display.SetDisplay(heads[HIndex].life, heads[HIndex].Aspeed, heads[HIndex].PartName);
            return;
        }
        if (LegsSelected)
        {
            LIndex++;
            if (LIndex > legs.Length - 1)
            {
                LIndex = legs.Length - 1;
                return;
            }
            foreach (var p in legs)
            {
                p.gameObject.SetActive(false);
            }
            legs[LIndex].gameObject.SetActive(true);
            Display.SetDisplay(legs[LIndex].life, legs[LIndex].Aspeed, legs[LIndex].PartName);
            return;
        }
    }
    public void SelectLeft()
    {
        if (RarmsSelected)
        {
            RAIndex--;
            if (RAIndex < 0)
            {
                RAIndex = 0;
                return;
            }
            foreach (var p in rArms)
            {
                p.gameObject.SetActive(false);
            }
            rArms[RAIndex].gameObject.SetActive(true);
            Display.SetDisplay(rArms[RAIndex].life, rArms[RAIndex].Aspeed, rArms[RAIndex].PartName);
            return;
        }
        if (LarmsSelected)
        {
            LAIndex--;
            if (LAIndex < 0)
            {
                LAIndex = 0;
                return;
            }
            foreach (var p in lArms)
            {
                p.gameObject.SetActive(false);
            }
            lArms[LAIndex].gameObject.SetActive(true);
            Display.SetDisplay(lArms[LAIndex].life, lArms[LAIndex].Aspeed, lArms[LAIndex].PartName);
            return;
        }
        if (HeadSelected)
        {
            HIndex--;
            if (HIndex < 0)
            {
                HIndex = 0;
                return;
            }
            foreach (var p in heads)
            {
                p.gameObject.SetActive(false);
            }
            heads[HIndex].gameObject.SetActive(true);
            Display.SetDisplay(heads[HIndex].life, heads[HIndex].Aspeed, heads[HIndex].PartName);
            return;
        }
        if (LegsSelected)
        {
            LIndex--;
            if (LIndex < 0)
            {
                LIndex = 0;
                return;
            }
            foreach (var p in legs)
            {
                p.gameObject.SetActive(false);
            }
            legs[LIndex].gameObject.SetActive(true);
            Display.SetDisplay(legs[LIndex].life, legs[LIndex].Aspeed, legs[LIndex].PartName);
            return;
        }
    }
}
