using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour
{
    public Figther Character;
    public float _timer;
    public float _AttackInterval;
    // Start is called before the first frame update
    void Start()
    {
        Character.HeadLife = LifeTraker.Instance.eHead;
        Character.RightLife = LifeTraker.Instance.eRight;
        Character.LeftLife = LifeTraker.Instance.eLeft;
        Character.LegsLife = LifeTraker.Instance.eLegs;
        FightControler.Instance._Enemy = Character;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>=_AttackInterval)
        {
            _timer = 0;
            float attackNum = Random.Range(0,4);
            if (attackNum <= 1) Character.UpperAttack();
            if (attackNum <= 2 && attackNum > 1) Character.RightHook();
            if (attackNum <= 3 && attackNum > 2) Character.LeftHook();
            if (attackNum <= 4 && attackNum > 3) Character.DownerAttack();
        }
        
    }
}
