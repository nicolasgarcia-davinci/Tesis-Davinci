using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refery : MonoBehaviour
{
    public Winner PlayerWiner;
    public Winner EnemyWinner;
    public Losser PlayerLosser;
    public Losser EnemyLosser;
    void Start()
    {
        if (LifeTraker.Instance.IsEnemy)
        { 
            PlayerWiner.gameObject.SetActive(true);
            EnemyLosser.gameObject.SetActive(true);
        } 
        else if(!LifeTraker.Instance.IsEnemy)
        {
            PlayerLosser.gameObject.SetActive(true);
            EnemyWinner.gameObject.SetActive(true);
        }
    }
}
