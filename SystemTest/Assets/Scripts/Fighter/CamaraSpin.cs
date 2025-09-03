using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSpin : MonoBehaviour
{
    public float SpinnSpeed;

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, SpinnSpeed*Time.deltaTime, 0));
    }
}
