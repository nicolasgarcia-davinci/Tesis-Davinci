using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelector : MonoBehaviour
{
    public GameObject[] Selectors;

    public StatDisplay Display;

    public MenuNavigation _asMenu;

    public GameObject TheSlector;

    public GameObject CompFighter;
    
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

    public bool NeedsToZero;
    void Start()
    {
        Zero();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace)) SelectUp();
        if(Input.GetKeyDown(KeyCode.RightArrow)) SelectRight();
        if(Input.GetKeyDown(KeyCode.LeftArrow)) SelectLeft();
        if(NeedsToZero) Zero();
    }

    public void Zero()
    {
        foreach (var p in Selectors)
        {
            p.gameObject.SetActive(false);
        }
        SIndex = 0;

        Selectors[SIndex].gameObject.SetActive(true);


        Highlight();
        NeedsToZero = false;
    }

    public void Highlight()
    {
        Selectors[SIndex].gameObject.SetActive(true);

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
    }
    public void SelectUp()
    {
        SIndex++;
        
        foreach (var p in Selectors)
        {
            p.gameObject.SetActive(false);
        }

        if (SIndex > Selectors.Length-1)
        {
            LifeTraker.Instance.RarmIndex = RAIndex;
            LifeTraker.Instance.LarmIndex = LAIndex;
            LifeTraker.Instance.LegsIndex = LIndex;
            LifeTraker.Instance.HeadIndex = HIndex;

            //_asMenu.gameObject.SetActive(true);
            //_asMenu.Zero();
            //NeedsToZero = true;
            TheSlector.SetActive(false);
            CompFighter.SetActive(true);
            return;
        }


        Highlight();
    }
    public void SelectRight()
    {
        if(RarmsSelected)
        {
            RAIndex++;

            if (RAIndex > LifeTraker.Instance.Dificulty)
            { 
                RAIndex=LifeTraker.Instance.Dificulty;
                return;
            }
            
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
            return;
        }
        if (LarmsSelected)
        {
            LAIndex++;

            if (LAIndex > LifeTraker.Instance.Dificulty)
            {
                LAIndex = LifeTraker.Instance.Dificulty;
                return;
            }

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

            if (HIndex > LifeTraker.Instance.Dificulty)
            {
                HIndex = LifeTraker.Instance.Dificulty;
                return;
            }

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

            if (LIndex > LifeTraker.Instance.Dificulty)
            {
                LIndex = LifeTraker.Instance.Dificulty;
                return;
            }

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
