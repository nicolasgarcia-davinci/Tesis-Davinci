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

    public PartsToPaint ListToPaint;
    
    public int SIndex;
    public int HIndex;
    public int LAIndex;
    public int RAIndex;
    public int ChIndex;
    public int LIndex;

    public Head[] heads;
    public Arm[] lArms;
    public Arm[] rArms;
    public Leg[] legs;
    public Chest[] chests;

    public bool HeadSelected;
    public bool LarmsSelected;
    public bool RarmsSelected;
    public bool LegsSelected;
    public bool ChestSelected;

    public bool NeedsToZero;
    void Start()
    {
        Zero();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) SelectUp();
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
            ChestSelected = false;
            rArms[RAIndex].gameObject.SetActive(true);
            rArms[RAIndex].SetColor();
        }

        if (SIndex == 1)
        {
            RarmsSelected = false;
            LarmsSelected = true;
            LegsSelected = false;
            HeadSelected = false;
            ChestSelected = false;
            lArms[LAIndex].gameObject.SetActive(true);
            lArms[LAIndex].SetColor();
        }

        if (SIndex == 2)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = true;
            HeadSelected = false;
            ChestSelected = false;
            legs[LIndex].gameObject.SetActive(true);
            legs[LIndex].SetColor();
        }

        if (SIndex == 3)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = true;
            ChestSelected = false;
            heads[HIndex].gameObject.SetActive(true);
            heads[HIndex].SetColor();
        }
        if (SIndex == 4)
        {
            RarmsSelected = false;
            LarmsSelected = false;
            LegsSelected = false;
            HeadSelected = false;
            ChestSelected = true;
            chests[ChIndex].gameObject.SetActive(true);
            chests[ChIndex].SetColor();
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
            ListToPaint.PtP = new List<Part>();

            LifeTraker.Instance.RarmIndex = RAIndex;
            ListToPaint.PtP.Add(rArms[RAIndex]);

            LifeTraker.Instance.LarmIndex = LAIndex;
            ListToPaint.PtP.Add(lArms[LAIndex]);

            LifeTraker.Instance.LegsIndex = LIndex;
            ListToPaint.PtP.Add(legs[LIndex]);

            LifeTraker.Instance.HeadIndex = HIndex;
            ListToPaint.PtP.Add(heads[HIndex]);

            LifeTraker.Instance.ChestIndex = ChIndex;
            ListToPaint.PtP.Add(chests[ChIndex]);

            Zero();
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

            if (RAIndex > LifeTraker.Instance.Dificulty-1)
            { 
                RAIndex=LifeTraker.Instance.Dificulty - 1;
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

            if (LAIndex > LifeTraker.Instance.Dificulty-1)
            {
                LAIndex = LifeTraker.Instance.Dificulty-1;
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

            if (HIndex > LifeTraker.Instance.Dificulty - 1)
            {
                HIndex = LifeTraker.Instance.Dificulty - 1;
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

            if (LIndex > LifeTraker.Instance.Dificulty - 1)
            {
                LIndex = LifeTraker.Instance.Dificulty - 1;
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
        if (ChestSelected)
        {
            ChIndex++;

            if (ChIndex > LifeTraker.Instance.Dificulty - 1)
            {
                ChIndex = LifeTraker.Instance.Dificulty - 1;
                return;
            }

            if (ChIndex > chests.Length - 1)
            {
                ChIndex = chests.Length - 1;
                return;
            }

            foreach (var p in chests)
            {
                p.gameObject.SetActive(false);
            }

            chests[ChIndex].gameObject.SetActive(true);
            Display.SetDisplay(chests[ChIndex].life, chests[ChIndex].Aspeed, chests[ChIndex].PartName);
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
        if (ChestSelected)
        {
            ChIndex--;

            if (ChIndex < 0)
            {
                ChIndex = 0;
                return;
            }

            foreach (var p in chests)
            {
                p.gameObject.SetActive(false);
            }

            chests[ChIndex].gameObject.SetActive(true);
            Display.SetDisplay(chests[ChIndex].life, chests[ChIndex].Aspeed, chests[ChIndex].PartName);
        }
    }
}
