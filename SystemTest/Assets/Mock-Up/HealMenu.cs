using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HealMenu : MonoBehaviour
{
    public int HealUses;
    public int Index;
    public RepairButtom[] RepairSet;
    [SerializeField] TextMeshProUGUI _label;

    void Start()
    {
        _label.text = HealUses.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) SelectUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) SelectDown();
    }
    public void UseHeal()
    {
        HealUses--;
        _label.text = "Remaining heals: " + HealUses.ToString();
        ResetHeals();
    }

    public void ResetHeals()
    {
        foreach (var pair in RepairSet)
        {
            pair.DeSelect();
            pair.Set();
        }
        if (HealUses == 0)
        {
            RepairSet[4].Select();
            return;
        }
        RepairSet[0].Select();
    }

    public void SelectUp()
    {
        if (HealUses == 0) return;
        Index--;
        if (Index < 0) Index = RepairSet.Length - 1;
        foreach (RepairButtom button in RepairSet)
        {
            if (button == RepairSet[Index])
            {
                button.Select();
            }
            else button.DeSelect();
        }
    }
    public void SelectDown()
    {
        if(HealUses==0) return;
        Index++;
        if (Index > RepairSet.Length - 1) Index = 0;
        foreach (RepairButtom button in RepairSet)
        {
            if (button == RepairSet[Index])
            {
                button.Select();
            }
            else button.DeSelect();
        }
    }
}
