using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDiplay : MonoBehaviour
{
    public EnemyIntro[] oponents;
    public int index;
    public float ToDie;
    void Start()
    {
        ToDie = LifeTraker.Instance.Dificulty;
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
