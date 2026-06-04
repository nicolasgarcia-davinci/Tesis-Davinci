using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageMenu : MonoBehaviour
{
    public GameObject Dif1;
    public GameObject Unlocks;
    void Start()
    {
        if(LifeTraker.Instance.Dificulty==1)
        {
            Dif1.SetActive(true);
        }
        if (LifeTraker.Instance.Dificulty > 1)
        {
            Unlocks.SetActive(true);
        }
    }
}
