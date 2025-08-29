using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Figther Character;
    // Start is called before the first frame update
    void Start()
    {
        FightControler.Instance._Player = Character;
        Character.HeadLife = LifeTraker.Instance.pHead;
        Character.RightLife = LifeTraker.Instance.pRight;
        Character.LeftLife = LifeTraker.Instance.pLeft;
        Character.LegsLife = LifeTraker.Instance.pLegs;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Character.UpperAttack();
        if (Input.GetKeyDown(KeyCode.D)) Character.RightHook();
        if (Input.GetKeyDown(KeyCode.A)) Character.LeftHook();
        if (Input.GetKeyDown(KeyCode.S)) Character.DownerAttack();
    }
}
