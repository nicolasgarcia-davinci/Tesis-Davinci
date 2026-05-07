using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DDManager : MonoBehaviour
{
    public FallingArrow[] DDPanels;

    public float TimetoTwithch;
    public float Timer;

    public GameObject mesage;

    public Fallen Player;
    public Fallen Enemy;
    public GetUp _clock;

    public float MaxHit;
    public float Hits;
    public float _defaultMaxHits;

    public AudioSource _AudioSource;
    public AudioClip Lose, Succes, HitSound;

    public Image _bar;
    public Image _RightHitZone;
    public Image _LeftHitZone;
    public Image _DownHitZone;
    public Image _UpHitZone;
    public Color _default;
    public Color _Correct;


    public Color _Normal;

    public void SetGame()
    {
        _bar.fillAmount = 0;
        _default = _RightHitZone.color;
        Hits = 0;
        mesage.SetActive(false);
        foreach (var panel in DDPanels)
        {
            panel.Animator.speed=1;
        }
        if (LifeTraker.Instance.IsEnemy)
        {
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.EnemyKO * 3);
            Enemy._gameOver = false;
            StartCoroutine(EnemyStep());
        }
        else
        {
            _bar.color = _Normal;
            MaxHit = _defaultMaxHits + (LifeTraker.Instance.PlayerKO * 3);
            Player._gameOver = false;
        }
        _bar.fillAmount = Hits / MaxHit;
        SpawnArrow();
    }

    void Update()
    {
        if(Player._gameOver) return;
        if (Input.GetKeyDown(KeyCode.RightArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsRight)
                { 
                    panel.Correct();
                    StartCoroutine(RightHit());
                    UpdateHits();
                    _AudioSource.PlayOneShot(HitSound);
                    Player._fallen.SetTrigger("Twitch Right");
                } 
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft) 
                {
                    panel.Correct();
                    StartCoroutine(LeftHit());
                    UpdateHits();
                    _AudioSource.PlayOneShot(HitSound);
                    Player._fallen.SetTrigger("Twitch Left");
                }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp) 
                {
                    panel.Correct();
                    StartCoroutine(UpHit());
                    UpdateHits();
                    _AudioSource.PlayOneShot(HitSound);
                    Player._fallen.SetTrigger("Twitch Up");
                }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown) 
                {
                    panel.Correct();
                    StartCoroutine(DownHit());
                    UpdateHits();
                    _AudioSource.PlayOneShot(HitSound);
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

    public IEnumerator UpHit()
    {
        _UpHitZone.color = _Correct;
        yield return new WaitForSeconds (0.5f);
        _UpHitZone.color = _default;
    }
    public IEnumerator DownHit()
    {
        _DownHitZone.color = _Correct;
        yield return new WaitForSeconds(0.5f);
        _DownHitZone.color = _default;
    }
    public IEnumerator RightHit()
    {
        _RightHitZone.color = _Correct;
        yield return new WaitForSeconds(0.5f);
        _RightHitZone.color = _default;
    }
    public IEnumerator LeftHit()
    {
        _LeftHitZone.color = _Correct;
        yield return new WaitForSeconds(0.5f);
        _LeftHitZone.color = _default;
    }

    public void UpdateHits()
    {
        Hits++;
        _bar.fillAmount = Hits/MaxHit;
        if(Hits >= MaxHit)
        {
            if(!LifeTraker.Instance.IsEnemy)
            {
                Player._gameOver = true;
                LifeTraker.Instance.pOverHealt = 50;
                Player.GetUp();

            }
            if (LifeTraker.Instance.IsEnemy)
            {
                Enemy._gameOver = true;
                LifeTraker.Instance.eOverHealt = 50;
                Enemy.GetUp();

            }

            StopGame();
            _AudioSource.PlayOneShot(Succes);
            _clock.Stop();
            StageState.Instance.ResetFight = true;
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

    public IEnumerator EnemyStep()
    {
        yield return new WaitForSeconds(3f);
        UpdateHits();
        StartCoroutine(EnemyStep());
    }

    public void StopGame()
    {
        foreach (var panel in DDPanels)
        {
            panel.StopAnim();
        }
        StopCoroutine(EnemyStep());
        mesage.SetActive(true);
    }
}
