using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSpawner : MonoBehaviour
{
    public RestAnim _Boxer;
    public RestAnim _Drill;
    public Transform SpawnPos;

    public void SpawnPlayer()
    {
        if (LifeTraker.Instance.PlayerRobo == RoboType.Boxer)
        {
            var player = Instantiate(_Boxer);
            player.transform.position = SpawnPos.position;
        }

        if (LifeTraker.Instance.PlayerRobo == RoboType.Drill)
        {
            var player = Instantiate(_Drill);
            player.transform.position = SpawnPos.position;
        }
    }
}
