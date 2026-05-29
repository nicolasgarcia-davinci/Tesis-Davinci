using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string PartName;
    public string AttName;
    public float life;
    public int Damage;
    public float Aspeed;
    public AudioClip AttackSound;

    public GameObject ParticleContainer;

    public GameObject[] components;

    public void ActiveParts()
    {
        foreach (var part in components)
        {
            part.gameObject.SetActive(true);
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", ColorCordination.Instance.color1);
            coloring.material.SetColor("_Color_2", ColorCordination.Instance.color2);
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
