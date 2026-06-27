using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelector : MonoBehaviour
{
    public Animator[] Parts;

    public StatDisplay Display;

    public MenuNavigation _asMenu;

    public GameObject TheSlector;

    public PartPainter ColorPalet;

    public GameObject CompFighter;

    public PartsToPaint ListToPaint;

    public MiniDisplay[] miniDisplays;
    
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

    public bool IsOn;

    void Start()
    {
        Zero();
        Display.SetRarmDisplay(rArms[RAIndex].life, rArms[RAIndex].Damage);
        miniDisplays[0].DisplayMini(RAIndex);
        Display.SetLarmDisplay(lArms[LAIndex].life, lArms[LAIndex].Damage);
        miniDisplays[0].DisplayMini(LAIndex);
        Display.SetLegDisplay(legs[LIndex].life, legs[LIndex].Damage);
        miniDisplays[0].DisplayMini(LIndex);
        Display.SetHeadDisplay(heads[HIndex].life, heads[HIndex].Damage);
        miniDisplays[0].DisplayMini(HIndex);
        Display.SetChestDisplay(chests[ChIndex].life, chests[ChIndex].Damage);
        miniDisplays[0].DisplayMini(ChIndex);
    }
    void Update()
    {
        if(!IsOn) return;
        if(Input.GetKeyDown(KeyCode.DownArrow)) SelectUp();
        if(Input.GetKeyDown(KeyCode.UpArrow)) SelectDown();
        if (Input.GetKeyDown(KeyCode.E)) OpenColors();
        if (Input.GetKeyDown(KeyCode.RightArrow)) SelectRight();
        if(Input.GetKeyDown(KeyCode.LeftArrow)) SelectLeft();
        if(Input.GetKeyDown(KeyCode.Space)) Finish();
    }

    public void OpenColors()
    {
        ColorPalet.gameObject.SetActive(true);
        if (RarmsSelected) ColorPalet.GetRArm(rArms[RAIndex]);
        if (LarmsSelected) ColorPalet.GetLArm(lArms[LAIndex]);
        if (LegsSelected) ColorPalet.GetLeg(legs[LIndex]);
        if (HeadSelected) ColorPalet.GetHead(heads[HIndex]);
        if (ChestSelected) ColorPalet.GetChest(chests[ChIndex]);
        IsOn = false;
    }

    public void Finish()
    {
        ListToPaint.Clean();

        LifeTraker.Instance.RarmIndex = RAIndex;
        ListToPaint.Rarms.Add(rArms[RAIndex]);

        LifeTraker.Instance.LarmIndex = LAIndex;
        ListToPaint.Larms.Add(lArms[LAIndex]);

        LifeTraker.Instance.LegsIndex = LIndex;
        ListToPaint.Legs.Add(legs[LIndex]);

        LifeTraker.Instance.HeadIndex = HIndex;
        ListToPaint.Heads.Add(heads[HIndex]);

        LifeTraker.Instance.ChestIndex = ChIndex;
        ListToPaint.Chests.Add(chests[ChIndex]);

        Zero();

        CompFighter.SetActive(true);
        TheSlector.SetActive(false);

        return;
    }
    public void Enter()
    {
        IsOn = true;
    }

    public void Zero()
    {
        foreach (var p in Parts)
        {
            p.SetBool("Selected", false);
        }
        SIndex = 0;

        Highlight();
    }

    public void Highlight()
    {
        Parts[SIndex].SetBool("Selected", true);

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
        if (SIndex > Parts.Length - 1) SIndex--; 
        
        foreach (var p in Parts)
        {
            p.SetBool("Selected", false);
        }

        Highlight();
    }
    public void SelectDown()
    {
        SIndex--;
        if (SIndex < 0) SIndex = 0;

        foreach (var p in Parts)
        {
            p.SetBool("Selected", false);
        }

        Highlight();
    }
    public void SelectRight()
    {
        if(RarmsSelected)
        {
            RAIndex++;

            if (RAIndex > LifeTraker.Instance.Dificulty - 1)
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
            Display.SetRarmDisplay(rArms[RAIndex].life, rArms[RAIndex].Damage);
            miniDisplays[0].DisplayMini(RAIndex);
            return;
        }
        if (LarmsSelected)
        {
            LAIndex++;

            if (LAIndex > LifeTraker.Instance.Dificulty-1)
            {
                LAIndex = LifeTraker.Instance.Dificulty-1;
            }

            if (LAIndex > lArms.Length - 1)
            {
                LAIndex = lArms.Length - 1;
            }

            foreach (var p in lArms)
            {
                p.gameObject.SetActive(false);
            }

            lArms[LAIndex].gameObject.SetActive(true);
            Display.SetLarmDisplay(lArms[LAIndex].life, lArms[LAIndex].Damage);
            miniDisplays[1].DisplayMini(LAIndex);
            return;
        }
        if (HeadSelected)
        {
            HIndex++;

            if (HIndex > LifeTraker.Instance.Dificulty - 1)
            {
                HIndex = LifeTraker.Instance.Dificulty - 1;
            }

            if (HIndex > heads.Length - 1)
            {
                HIndex = heads.Length - 1;
            }
            
            foreach (var p in heads)
            {
                p.gameObject.SetActive(false);
            }

            heads[HIndex].gameObject.SetActive(true);
            Display.SetHeadDisplay(heads[HIndex].life, heads[HIndex].Damage);
            miniDisplays[3].DisplayMini(HIndex);
            return;
        }
        if (LegsSelected)
        {
            LIndex++;

            if (LIndex > LifeTraker.Instance.Dificulty - 1)
            {
                LIndex = LifeTraker.Instance.Dificulty - 1;
            }

            if (LIndex > legs.Length - 1)
            {
                LIndex = legs.Length - 1;
            }
            
            foreach (var p in legs)
            {
                p.gameObject.SetActive(false);
            }

            legs[LIndex].gameObject.SetActive(true);
            Display.SetLegDisplay(legs[LIndex].life, legs[LIndex].Damage);
            miniDisplays[2].DisplayMini(LIndex);
            return;
        }
        if (ChestSelected)
        {
            ChIndex++;

            if (ChIndex > LifeTraker.Instance.Dificulty - 1)
            {
                ChIndex = LifeTraker.Instance.Dificulty - 1;
            }

            if (ChIndex > chests.Length - 1)
            {
                ChIndex = chests.Length - 1;
            }

            foreach (var p in chests)
            {
                p.gameObject.SetActive(false);
            }

            chests[ChIndex].gameObject.SetActive(true);
            Display.SetChestDisplay(chests[ChIndex].life, chests[ChIndex].Damage);
            miniDisplays[4].DisplayMini(ChIndex);
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
            Display.SetRarmDisplay(rArms[RAIndex].life, rArms[RAIndex].Damage);
            miniDisplays[0].DisplayMini(RAIndex);
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
            Display.SetLarmDisplay(lArms[LAIndex].life, lArms[LAIndex].Damage);
            miniDisplays[1].DisplayMini(LAIndex);
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
            Display.SetHeadDisplay(heads[HIndex].life, heads[HIndex].Damage);
            miniDisplays[3].DisplayMini(HIndex);
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
            Display.SetLegDisplay(legs[LIndex].life, legs[LIndex].Damage);
            miniDisplays[2].DisplayMini(LIndex);
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
            Display.SetChestDisplay(chests[ChIndex].life, chests[ChIndex].Damage);
            miniDisplays[4].DisplayMini(ChIndex);
        }
    }
}
