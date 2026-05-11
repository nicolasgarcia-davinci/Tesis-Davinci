using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public CompositeFighter Character;
    public bool IsPaused;

    void Start()
    {
        FightControler.Instance._Player = Character;
        FightControler.Instance._Control = this;
    }


    void Update()
    {
        if (IsPaused) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) Character.IsAttackingUp = Character.Attack(Character.Head.AttName, Character.RarmsAttackTrail, Character.IsAttackingUp);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Character.IsAttackingRight = Character.Attack(Character.Rarm.AttName, Character.RarmsAttackTrail, Character.IsAttackingRight);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Character.IsAttackingLeft = Character.Attack(Character.Larm.AttName, Character.LarmsAttackTrail, Character.IsAttackingLeft);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Character.IsAttackingDown = Character.Attack(Character.Leg.AttName, Character.LegsAttackTrail, Character.IsAttackingDown);
        if (Input.GetKeyDown(KeyCode.W)) Character.DodgeUp();
        if (Input.GetKeyDown(KeyCode.D)) Character.DodgeRight();
        if (Input.GetKeyDown(KeyCode.A)) Character.DodgeLeft();
        if (Input.GetKeyDown(KeyCode.S)) Character.DodgeDown();
    }
    public void Pause()
    {
        IsPaused = true;
        Character.Pause();
    }
    public void UnPause()
    {
        IsPaused = false;
        Character.UnPause();   
    }
}
