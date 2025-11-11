using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject _Boxer;
    public GameObject _Drill;

    public void SpawnPlayer()
    {
        if (LifeTraker.Instance.PlayerRobo == RoboType.Boxer)
        {
            _Boxer.SetActive(true);
        }

        if (LifeTraker.Instance.PlayerRobo == RoboType.Drill)
        {
            _Drill.SetActive(true);
        }
    }
}
