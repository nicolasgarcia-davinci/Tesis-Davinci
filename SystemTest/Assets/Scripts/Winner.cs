using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public SkinnedMeshRenderer body;
    public Material Player;
    public Material Enemy;
    public GameObject Win;
    public GameObject Lose;
    void Start()
    {
        if (LifeTraker.Instance.IsEnemy)
        {
            body.material = Player;
            body.material.SetColor("_Color_1", ColorCordination.Instance.color1);
            body.material.SetColor("_Color_2", ColorCordination.Instance.color2);
            body.material.SetFloat("_Transparencia", 1);
            Win.SetActive(true);
        }
        if (!LifeTraker.Instance.IsEnemy)
        {
            body.material = Enemy;
            Lose.SetActive(true);
        }
    }
}
