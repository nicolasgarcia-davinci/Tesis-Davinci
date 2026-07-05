using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string PartName;
    public string AttName;
    public float life;
    public float Maxlife;
    public int Damage;
    public bool isBroken;
    public AudioClip AttackSound;

    public GameObject ParticleContainer;

    public GameObject[] components;

    public void FullColor(Color paint1,Color paint2)
    {
        foreach (var part in components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", paint1);
            coloring.material.SetColor("_Color_2", paint2);
        }
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

    public void Update()
    {
        if(life <= 0) isBroken = true;
        if(life >= 0) isBroken = false;
    }
}
