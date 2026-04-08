using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCam : MonoBehaviour
{
    public Transform FightPos;
    public Transform RepairPos;
    public Transform[] KOPos;
    public int Index;
    
    public static StageCam Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GoToFightCam()
    {
        this.transform.position=FightPos.position;
        this.transform.rotation=FightPos.rotation;
    }
    public void GoToRepairCam()
    {
        this.transform.position = RepairPos.position;
        this.transform.rotation = RepairPos.rotation;
    }
    public void GoToKOCam()
    {
        if(Index>=KOPos.Length)Index = 0;
        this.transform.position = KOPos[Index].position;
        this.transform.rotation = KOPos[Index].rotation;
        Index++;
    }
}
