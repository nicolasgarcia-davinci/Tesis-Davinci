using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PartPainter : MonoBehaviour
{
    public Arm RArmToPaint;
    public Arm LArmToPaint;
    public Leg LegToPaint;
    public Head HeadToPaint;
    public Chest ChestToPaint;
    public int Index;
    public bool IsInColum1;
    public bool IsInColum2;
    public PartSelector Asambler;
    public ConsoleControls controls;
    public GameObject Palet1;
    public GameObject Palet2;
    public PartColor[] Column1;
    public PartColor[] Column2;

    public void GetRArm(Arm selectedPart)
    {
        RArmToPaint = selectedPart;
        Palet1.SetActive(true);
        IsInColum1 = true;
        Column1[0].Select();
        foreach (var col in Column1)
        {
            col.RArmToPaint = selectedPart;
            col.IsRArm = true;
        }
    }
    public void GetLArm(Arm selectedPart)
    {
        LArmToPaint = selectedPart;
        Palet1.SetActive(true);
        IsInColum1 = true;
        Column1[0].Select();
        foreach (var col in Column1)
        {
            col.LArmToPaint = selectedPart;
            col.IsLArm = true;
        }
    }
    public void GetLeg(Leg selectedPart)
    {
        LegToPaint = selectedPart;
        Palet1.SetActive(true);
        IsInColum1 = true;
        Column1[0].Select();
        foreach (var col in Column1)
        {
            col.LegToPaint = selectedPart;
            col.IsLeg = true;
        }
    }
    public void GetHead(Head selectedPart)
    {
        HeadToPaint = selectedPart;
        Palet1.SetActive(true);
        IsInColum1 = true;
        Column1[0].Select();
        foreach (var col in Column1)
        {
            col.HeadToPaint = selectedPart;
            col.IsHead = true;
        }
    }
    public void GetChest(Chest selectedPart)
    {
        ChestToPaint = selectedPart;
        Palet1.SetActive(true);
        IsInColum1 = true;
        Column1[0].Select();
        foreach (var col in Column1)
        {
            col.ChestToPaint = selectedPart;
            col.IsChest = true;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) CycleUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) CycleDown();
    }
    public void nextColumn()
    {
        Palet2.gameObject.SetActive(true);

        foreach (var col in Column1)
        {
            if(col.IsRArm)
            {
                foreach (var col2 in Column2)
                {
                    col2.RArmToPaint = col.RArmToPaint;
                    col2.IsRArm = true;
                }
            }
            if (col.IsLArm)
            {
                foreach (var col2 in Column2)
                {
                    col2.LArmToPaint = col.LArmToPaint;
                    col2.IsLArm = true;
                }
            }
            if (col.IsLeg)
            {
                foreach (var col2 in Column2)
                {
                    col2.LegToPaint = col.LegToPaint;
                    col2.IsLeg = true;
                }
            }
            if (col.IsHead)
            {
                foreach (var col2 in Column2)
                {
                    col2.HeadToPaint = col.HeadToPaint;
                    col2.IsHead = true;
                }
            }
            if (col.IsChest)
            {
                foreach (var col2 in Column2)
                {
                    col2.ChestToPaint = col.ChestToPaint;
                    col2.IsChest = true;
                }
            }
            col.DeSelect();
            col.Clean();
        }
        Palet1.gameObject.SetActive(false);
        
        IsInColum1 = false;
        IsInColum2 = true;
        Index = 0;
        Column2[Index].Select();
    }
    public void backColumn()
    {
        if (IsInColum1)
        {
            IsInColum1 = false;
            Index = 0;
            foreach (var col in Column1)
            {
                col.DeSelect();
                col.Clean();
            }
            Palet1.gameObject.SetActive(false);
            Asambler.CallActivation();
            controls.IsColoring = false;
        }

        if (IsInColum2)
        {
            Palet1.gameObject.SetActive(true);

            foreach (var col in Column2)
            {
                if (col.IsRArm)
                {
                    foreach (var col2 in Column1)
                    {
                        col2.RArmToPaint = col.RArmToPaint;
                        col2.IsRArm = true;
                    }
                }
                if (col.IsLArm)
                {
                    foreach (var col2 in Column1)
                    {
                        col2.LArmToPaint = col.LArmToPaint;
                        col2.IsLArm = true;
                    }
                }
                if (col.IsLeg)
                {
                    foreach (var col2 in Column1)
                    {
                        col2.LegToPaint = col.LegToPaint;
                        col2.IsLeg = true;
                    }
                }
                if (col.IsHead)
                {
                    foreach (var col2 in Column1)
                    {
                        col2.HeadToPaint = col.HeadToPaint;
                        col2.IsHead = true;
                    }
                }
                if (col.IsChest)
                {
                    foreach (var col2 in Column1)
                    {
                        col2.ChestToPaint = col.ChestToPaint;
                        col2.IsChest = true;
                    }
                }
                col.DeSelect();
                col.Clean();
            }

            IsInColum1 = true;
            IsInColum2 = false;
            Index = 0;
            Column1[Index].Select();

            Palet2.gameObject.SetActive(false);
        }
    }

    public void End()
    {
        foreach (var col in Column2)
        {
            col.DeSelect();
            col.Clean();
        }
        Palet2.gameObject.SetActive(false);
        IsInColum2 = false;

        Asambler.CallActivation();
    }
    public void CycleUp()
    {
        if(IsInColum1)
        {
            Index--;
            if (Index < 0) Index = Column1.Length - 1;
            foreach (PartColor button in Column1)
            {
                if (button == Column1[Index])
                {
                    button.Select();
                }
                else button.DeSelect();
            }
        }
        if (IsInColum2)
        {
            Index--;
            if (Index < 0) Index = Column2.Length - 1;
            foreach (PartColor button in Column2)
            {
                if (button == Column2[Index])
                {
                    button.Select();
                }
                else button.DeSelect();
            }
        }
    }
    public void CycleDown()
    {
        if (IsInColum1)
        {
            Index++;
            if (Index > Column1.Length - 1) Index = 0;
            foreach (PartColor button in Column1)
            {
                if (button == Column1[Index])
                {
                    button.Select();
                }
                else button.DeSelect();
            }
        }
        if (IsInColum2)
        {
            Index++;
            if (Index > Column2.Length - 1) Index = 0;
            foreach (PartColor button in Column2)
            {
                if (button == Column2[Index])
                {
                    button.Select();
                }
                else button.DeSelect();
            }
        }
    }

}
