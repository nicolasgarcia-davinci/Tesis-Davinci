using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTraker : MonoBehaviour
{
    public static LifeTraker Instance;

    public Material flash;

    [Header("Player Body Health")]
    public float MaxHealt;
    public float pOverHealt;
    public float pHead;
    public float pRight;
    public float pLeft;
    public float pLegs;
    public float PartCount;

    [Header("Player Max Health")]
    public float maxRarmHealth;
    public float maxLarmHealth;
    public float maxLegsHealth;
    public float maxHeadHealth;


    [Header("Enemy Body Health")]
    public float eMaxHealt;
    public float eOverHealt;
    public float eHead;
    public float eRight;
    public float eLeft;
    public float eLegs;
    public float ePartCount;

    [Header("Level Data")]
    public float RundCounter = 1;
    public int Dificulty;

    [Header("Player Parts")]
    public int RarmIndex;
    public int LarmIndex;
    public int LegsIndex;
    public int HeadIndex;
    public int ChestIndex;

    [Header("Number of Downs")]
    public int PlayerKO;
    public int EnemyKO;

    [Header("Who is Downed")]
    public bool IsEnemy;

    [Header("Reset Round Timer?")]
    public bool ResetTimer;

    [Header("Unlocks")]
    public bool UnlockDrill;
    public bool UnlockClaw;
    public bool HasUnlockClaw;
    public bool HasUnlockDrill;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
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
    public void Start()
    {
        Vector2 attackDir = new Vector2(0, 0);
        flash.SetVector("_Direction", attackDir);
        flash.SetFloat("_Edge_Softness", 0);
        flash.SetFloat("_Progres", 0);
    }
    public void UpdateLife()
    {
        //player
        pOverHealt = FightControler.Instance._Player.OverAllHealth;
        pHead = FightControler.Instance._Player.Head.life;
        pRight = FightControler.Instance._Player.Rarm.life;
        pLeft = FightControler.Instance._Player.Larm.life;
        pLegs = FightControler.Instance._Player.Leg.life;

        //enemy
        eOverHealt = FightControler.Instance._Enemy.OverAllHealth;
        eHead = FightControler.Instance._Enemy.Head.life;
        eRight = FightControler.Instance._Enemy.Rarm.life;
        eLeft = FightControler.Instance._Enemy.Larm.life;
        eLegs = FightControler.Instance._Enemy.Leg.life;
    }

    public void Reset()
    {
        RundCounter = 1;
        PlayerKO=0;
        EnemyKO=0;
    }
}
