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
        
    }
    public void Despawn()
    {
        _Boxer.SetActive(false);
        _Drill.SetActive(false);
    }
}
