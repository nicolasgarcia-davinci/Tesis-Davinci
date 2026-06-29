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

        if (Input.GetKeyDown(KeyCode.UpArrow)) Character.Attack(Character.Head.AttName, Character.Head.ParticleContainer, ref Character.IsAttackingUp);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Character.Attack(Character.Rarm.AttName, Character.Rarm.ParticleContainer, ref Character.IsAttackingRight);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Character.Attack(Character.Larm.AttName, Character.Larm.ParticleContainer, ref Character.IsAttackingLeft);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Character.Attack(Character.Leg.AttName, Character.Leg.ParticleContainer, ref Character.IsAttackingDown);
        
        if (Input.GetKeyDown(KeyCode.W)) Character.Dodge("DoedgeUp", ref Character.IsDodgingUp);
        if (Input.GetKeyDown(KeyCode.D)) Character.Dodge("DoedgeRight", ref Character.IsDodgingRight);
        if (Input.GetKeyDown(KeyCode.A)) Character.Dodge("DoedgeLeft", ref Character.IsDodgingLeft);
        if (Input.GetKeyDown(KeyCode.S)) Character.Dodge("DoedgeDown", ref Character.IsDodgingDown);

        if (Input.GetKeyDown(KeyCode.Escape)) FightControler.Instance.Pause();

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
