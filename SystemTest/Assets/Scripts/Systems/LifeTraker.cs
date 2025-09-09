using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTraker : MonoBehaviour
{
    public static LifeTraker Instance;

    public float MaxHealt;
    public float pOverHealt;
    public float pHead;
    public float pRight;
    public float pLeft;
    public float pLegs;
    public float eOverHealt;
    public float eHead;
    public float eRight;
    public float eLeft;
    public float eLegs;

    public int BtlLvl;

    public bool IsEnemy;
    public bool ResetTimer;
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
        pOverHealt= FightControler.Instance._Player.MaxLife;
        pHead =FightControler.Instance._Player.HeadLife;
        pRight=FightControler.Instance._Player.RightLife;
        pLeft=FightControler.Instance._Player.LeftLife;
        pLegs=FightControler.Instance._Player.LegsLife;
        eOverHealt= FightControler.Instance._Enemy.MaxLife;
        eHead=FightControler.Instance._Enemy.HeadLife;
        eRight=FightControler.Instance._Enemy.RightLife;
        eLeft=FightControler.Instance._Enemy.LeftLife;
        eLegs=FightControler.Instance._Enemy.LegsLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
