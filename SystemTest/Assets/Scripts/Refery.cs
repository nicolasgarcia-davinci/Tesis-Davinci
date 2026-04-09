using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refery : MonoBehaviour
{
    public Winner BoxerW;
    public Winner DrilW;
    public Losser BoxerL;
    public Losser DrillL;
    void Start()
    {
        if(LifeTraker.Instance.Dificulty==2 && !LifeTraker.Instance.IsEnemy) DrilW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.PlayerRobo==RoboType.Drill && LifeTraker.Instance.IsEnemy) DrilW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.PlayerRobo==RoboType.Boxer && LifeTraker.Instance.IsEnemy) BoxerW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.Dificulty == 1 && !LifeTraker.Instance.IsEnemy) BoxerW.gameObject.SetActive(true);

        if (LifeTraker.Instance.Dificulty == 1 && LifeTraker.Instance.IsEnemy) BoxerL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.PlayerRobo == RoboType.Boxer && !LifeTraker.Instance.IsEnemy) BoxerL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.PlayerRobo == RoboType.Drill && !LifeTraker.Instance.IsEnemy) DrillL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.Dificulty == 2 && LifeTraker.Instance.IsEnemy) DrillL.gameObject.SetActive(true);
    }
}
