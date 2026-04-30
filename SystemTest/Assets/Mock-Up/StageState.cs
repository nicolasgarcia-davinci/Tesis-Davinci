using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageState : MonoBehaviour
{
    public static StageState Instance;

    public bool ResetFight;
    public bool ResetKO;
    public bool ResetRepair;
    public bool RoundEnter;

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


}
