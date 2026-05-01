using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DDManager : MonoBehaviour
{
    public FallingArrow[] DDPanels;

    public bool Set;

    public float TimetoTwithch;
    public float Timer;

    public Fallen Player;
    public Fallen Enemy;
    public GetUp _clock;

    public float MaxHit;
    public float Hits;
    public float _defaultMaxHits;

    public AudioSource _AudioSource;
    public AudioClip Lose, Succes;

    public Image _bar;
    public Color _Invisible;

    public void SetGame()
    {
        if(Set) return;
        _bar.fillAmount = 0;
        Hits = 0;
        if (LifeTraker.Instance.IsEnemy)
        {
            _bar.color = _Invisible;
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.EnemyKO * 3);
        }
        else
        {
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.PlayerKO * 3);
        }
        _bar.fillAmount = Hits / MaxHit;
        SpawnArrow();
        Set = true;
    }

    void Update()
    {
        if(Player._gameOver) return;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsRight)
                { 
                    panel.Correct();
                    UpdateHits();
                    Player._fallen.SetTrigger("Twitch Right");
                } 
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft) 
                {
                    panel.Correct();
                    UpdateHits();
                    Player._fallen.SetTrigger("Twitch Left");
                }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp) 
                {
                    panel.Correct();
                    UpdateHits();
                    Player._fallen.SetTrigger("Twitch Up");
                }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown) 
                {
                    panel.Correct();
                    UpdateHits();
                    Player._fallen.SetTrigger("Twitch Down");
                }
        }
        if(LifeTraker.Instance.IsEnemy)
        {
            Timer += Time.deltaTime;
            if(Timer>=TimetoTwithch)
            {
                Timer=0;
                Enemy.Twith();
            }
        }
    }

    public void UpdateHits()
    {
        Hits++;
        _bar.fillAmount = Hits/MaxHit;
        if(Hits >= MaxHit)
        {
            LifeTraker.Instance.pOverHealt = 50;

            _AudioSource.PlayOneShot(Succes);
            LoadManager.Instance.Round2();
            _clock.Stop();
            StageState.Instance.ResetFight = true;
            Player.GetUp();
        }
    }

    public void SpawnArrow()
    {
        float Rnum = Random.Range(0, 100);
        if (Rnum <= 25) DDPanels[0].Fall();
        if (Rnum <= 50 && Rnum > 25) DDPanels[1].Fall();
        if (Rnum <= 75 && Rnum > 50) DDPanels[2].Fall();
        if (Rnum <= 100 && Rnum > 75) DDPanels[3].Fall();
    }
}
