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
    public float RundCounter = 1;
    public float Dificulty = 1;

    public int PlayerKO;
    public int EnemyKO;

    public bool IsEnemy;
    public bool ResetTimer;

    public RoboType PlayerRobo;
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
        pOverHealt = FightControler.Instance._Player.MaxLife;
        pHead = FightControler.Instance._Player.HeadLife;
        pRight = FightControler.Instance._Player.RightLife;
        pLeft = FightControler.Instance._Player.LeftLife;
        pLegs = FightControler.Instance._Player.LegsLife;
        eOverHealt = FightControler.Instance._Enemy.MaxLife;
        eHead = FightControler.Instance._Enemy.HeadLife;
        eRight = FightControler.Instance._Enemy.RightLife;
        eLeft = FightControler.Instance._Enemy.LeftLife;
        eLegs = FightControler.Instance._Enemy.LegsLife;
    }

    public void Reset()
    {
        pOverHealt = MaxHealt;
        pHead = MaxHealt;
        pRight = MaxHealt;
        pLeft = MaxHealt;
        pLegs = MaxHealt;
        eOverHealt = MaxHealt * Dificulty;
        eHead = MaxHealt * Dificulty;
        eRight = MaxHealt * Dificulty;
        eLeft = MaxHealt * Dificulty;
        eLegs = MaxHealt * Dificulty;
        RundCounter = 1;
        PlayerKO=0;
        EnemyKO=0;
    }
}

public enum RoboType
{
    Boxer, Drill
}
