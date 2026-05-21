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
        if (Input.GetKeyDown(KeyCode.UpArrow) && Character.Head.life>0) Character.Attack(Character.Head.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingUp);
        if (Input.GetKeyDown(KeyCode.RightArrow) && Character.Rarm.life > 0) Character.Attack(Character.Rarm.AttName, Character.RarmsAttackTrail, ref Character.IsAttackingRight);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Character.Larm.life > 0) Character.Attack(Character.Larm.AttName, Character.LarmsAttackTrail, ref Character.IsAttackingLeft);
        if (Input.GetKeyDown(KeyCode.DownArrow) && Character.Leg.life > 0) Character.Attack(Character.Leg.AttName, Character.LegsAttackTrail, ref Character.IsAttackingDown);
        if (Input.GetKeyDown(KeyCode.W)) Character.Dodge("DoedgeUp", ref Character.IsDodgingUp);
        if (Input.GetKeyDown(KeyCode.D)) Character.Dodge("DoedgeRight", ref Character.IsDodgingRight);
        if (Input.GetKeyDown(KeyCode.A)) Character.Dodge("DoedgeLeft", ref Character.IsDodgingLeft);
        if (Input.GetKeyDown(KeyCode.S)) Character.Dodge("DoedgeDown", ref Character.IsDodgingDown);
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
