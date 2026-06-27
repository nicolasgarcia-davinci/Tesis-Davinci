using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageMenu : MonoBehaviour
{
    public GameObject Skip;
    public GameObject Unlock;
    void Start()
    {
        if (LifeTraker.Instance.UnlockDrill|| LifeTraker.Instance.UnlockClaw)
        {
            Unlock.SetActive(true);
            if(LifeTraker.Instance.UnlockDrill) LifeTraker.Instance.HasUnlockDrill=true;
            if(LifeTraker.Instance.UnlockClaw) LifeTraker.Instance.HasUnlockClaw=true;
        }else Skip.SetActive(true);
    }
}
