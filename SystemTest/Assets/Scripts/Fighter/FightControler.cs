using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControler : MonoBehaviour
{
    public static FightControler Instance;
    public Figther _Player;
    public Figther _Enemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAttack(Figther attacker)
    {
        if(attacker.IsPlayer)
        {
            if (attacker.AimUp) _Enemy.takeHeadDamage();
            if (attacker.AimRight) _Enemy.takeRightDamage();
            if (attacker.AimLeft) _Enemy.takeLeftDamage();
            if (attacker.AimDown) _Enemy.takeLegsDamage();
        }

        if (!attacker.IsPlayer)
        {
            if (attacker.AimUp) _Player.takeHeadDamage();
            if (attacker.AimRight) _Player.takeRightDamage();
            if (attacker.AimLeft) _Player.takeLeftDamage();
            if (attacker.AimDown) _Player.takeLegsDamage();
        }
    }
}
