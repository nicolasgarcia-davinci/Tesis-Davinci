using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DDManager : MonoBehaviour
{
    public FallingArrow[] DDPanels;

    public bool Set;

    public Fallen Fallen;
    public GetUp _clock;

    public float MaxHit;
    public float Hits;
    public float _defaultMaxHits;

    public AudioSource _AudioSource;
    public AudioClip Lose, Succes;

    public Image _bar;
    public Color _Invisible;
    void Start()
    {
        //SetGame();
    }

    public void SetGame()
    {
        _bar.fillAmount = 0;
        Hits = 0;
        if (LifeTraker.Instance.IsEnemy)
        {
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.EnemyKO*3);
            _bar.color = _Invisible;
        }
        else
        {
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.PlayerKO * 3);
        }
        _bar.fillAmount = Hits / MaxHit;
        SpawnArrow();
        Set = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Set)
        //{
        //    SetGame();
        //    return;
        //}
        if(Fallen._gameOver) return;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsRight)
                { 
                    panel.Correct();
                    UpdateHits();
                } 
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft) 
                {
                    panel.Correct();
                    UpdateHits();
                }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp) 
                {
                    panel.Correct();
                    UpdateHits();
                }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown) 
                {
                    panel.Correct();
                    UpdateHits();
                }
        }

    }

    public void UpdateHits()
    {
        Hits++;
        _bar.fillAmount = Hits/MaxHit;
        if(Hits >= MaxHit)
        {
            Fallen._gameOver = true;
            if (LifeTraker.Instance.IsEnemy)
                LifeTraker.Instance.eOverHealt = 70;
            else LifeTraker.Instance.pOverHealt = 70;

            _AudioSource.PlayOneShot(Succes);
            LoadManager.Instance.Round2();
            _clock.Stop();
            StageState.Instance.ResetFight = true;
            Fallen._fallen.SetTrigger("GetUp");
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
