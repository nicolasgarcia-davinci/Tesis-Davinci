using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public CompositeFighter Character;
    public bool IsPaused;
    public bool noController;

    public CompositeFighter composite;

    void Start()
    {
        FightControler.Instance._Player = Character;
        FightControler.Instance._Control = this;

        if(composite != null)
        {
            composite.IsDyingEvent += DyingEnemy;
            composite.CharacterUpEvent += EnemyUp;
        }
    }


    void Update()
    {
        if (IsPaused) return;
        if (noController) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) Character.Headattack();
        if (Input.GetKeyDown(KeyCode.RightArrow)) Character.RArmattack();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Character.LArmattack();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Character.Legattack();
        if (Input.GetKeyDown(KeyCode.W)) Character.DodgeUp();
        if (Input.GetKeyDown(KeyCode.D)) Character.DodgeRight();
        if (Input.GetKeyDown(KeyCode.A)) Character.DodgeLeft();
        if (Input.GetKeyDown(KeyCode.S)) Character.DodgeDown();
    }

    void DyingEnemy()
    {
        noController = true;
    }

    void EnemyUp()
    {
        noController = false;
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
