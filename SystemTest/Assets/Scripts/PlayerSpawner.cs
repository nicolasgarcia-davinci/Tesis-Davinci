using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject _Boxer;
    public GameObject _Drill;
    public Transform SpawnPos;
    public Vector3 drillpos;

    public void SpawnPlayer()
    {
        if(LifeTraker.Instance.PlayerRobo== RoboType.Boxer)
        {
            var player = Instantiate(_Boxer);
            player.transform.position = SpawnPos.position;
        }

        if (LifeTraker.Instance.PlayerRobo == RoboType.Drill)
        {
            var player = Instantiate(_Drill);
            player.transform.position = drillpos;
        }
    }
}
