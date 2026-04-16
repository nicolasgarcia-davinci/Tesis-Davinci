using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string PartName;
    public string AttName;
    public int life;
    public int Damage;
    public float Aspeed;
    public AudioClip AttackSound;

    public GameObject[] components;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveParts()
    {
        foreach (var part in components)
        {
            part.gameObject.SetActive(true);
        }
    }
    public void DeActiveParts()
    {
        foreach (var part in components)
        {
            part.gameObject.SetActive(false);
        }
    }
}
