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
    public GameObject Gym;
    public GameObject Garage;
    public ParticleSystem[] FireWorks;
    public Color[] colors;
    private int Index = 0;
    void Start()
    {
        if(LifeTraker.Instance.Dificulty==1) Garage.SetActive(true);
        else if(LifeTraker.Instance.Dificulty==2) Gym.SetActive(true);
        if(LifeTraker.Instance.Dificulty==2 && !LifeTraker.Instance.IsEnemy) DrilW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.PlayerRobo==RoboType.Drill && LifeTraker.Instance.IsEnemy) DrilW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.PlayerRobo==RoboType.Boxer && LifeTraker.Instance.IsEnemy) BoxerW.gameObject.SetActive(true);
        else if(LifeTraker.Instance.Dificulty == 1 && !LifeTraker.Instance.IsEnemy) BoxerW.gameObject.SetActive(true);

        if (LifeTraker.Instance.Dificulty == 1 && LifeTraker.Instance.IsEnemy) BoxerL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.PlayerRobo == RoboType.Boxer && !LifeTraker.Instance.IsEnemy) BoxerL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.PlayerRobo == RoboType.Drill && !LifeTraker.Instance.IsEnemy) DrillL.gameObject.SetActive(true);
        else if (LifeTraker.Instance.Dificulty == 2 && LifeTraker.Instance.IsEnemy) DrillL.gameObject.SetActive(true);
        //StartCoroutine(Festibal());
        foreach(ParticleSystem spark in FireWorks)
        {
            int thiscolor;
            thiscolor = UnityEngine.Random.Range(0, colors.Length);
            spark.gameObject.SetActive(true);
            spark.startColor = colors[thiscolor];
        }
    }

    public IEnumerator Festibal()
    {
        if (Index > FireWorks.Length) Index = 0;
        FireWorks[Index].gameObject.SetActive(true);
        int thiscolor;
        thiscolor= UnityEngine.Random.Range(0,colors.Length);
        FireWorks[Index].startColor = colors[thiscolor];
        yield return new WaitForSeconds (0.1f);
        Index++;
        StartCoroutine (Festibal());
    }


}
