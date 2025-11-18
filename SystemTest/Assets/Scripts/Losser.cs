using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losser : MonoBehaviour
{
    public SkinnedMeshRenderer body;
    public Material Player;
    public Material Enemy;
    public GameObject Lose;
    void Start()
    {
        if(LifeTraker.Instance.IsEnemy)
        {
            body.material = Enemy;
        }
        if (!LifeTraker.Instance.IsEnemy)
        {
            body.material = Player;
            body.material.SetColor("_Color1", ColorCordination.Instance.color1);
            body.material.SetColor("_Color2", ColorCordination.Instance.color2);
            Lose.SetActive(true);
        }
    }
}
