using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTraker : MonoBehaviour
{
    public static LifeTraker Instance;

    public float MaxHealt;
    public float pHead;
    public float pRight;
    public float pLeft;
    public float pLegs;
    public float eHead;
    public float eRight;
    public float eLeft;
    public float eLegs;

    public bool IsEnemy;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void UpdateLife()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
