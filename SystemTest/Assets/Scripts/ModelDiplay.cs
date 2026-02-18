using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDiplay : MonoBehaviour
{
    public GameObject Boxer;
    public GameObject Drill;
    public EnemyIntro[] oponents;
    public int index;
    public float ToDie;
    void Start()
    {
        ToDie = LifeTraker.Instance.Dificulty;
        if(LifeTraker.Instance.PlayerRobo==RoboType.Boxer)
        {
            Boxer.SetActive(true);
        }
        if (LifeTraker.Instance.PlayerRobo == RoboType.Drill)
        {
            Drill.SetActive(true);
        }
        StartCoroutine(EnemyState());
    }

    public IEnumerator EnemyState()
    {
        if(index<ToDie-1)
        {
            oponents[index].Dead();
        }
        yield return new WaitForEndOfFrame();
        index++;
        if (index  <= oponents.Length)
        {
            StartCoroutine(EnemyState());
        }
    }
}
