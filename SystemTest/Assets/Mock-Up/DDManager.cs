using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
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
    public Color _Wrong;


    public Color _Normal;

    public ParticleSystem[] ParticulasPlayer;
    public ParticleSystem[] ParticulasEnemy;

    public GameObject UpParticles;
    public GameObject DownParticles;
    public GameObject RightParticles;
    public GameObject LeftParticles;

    public GameObject EUpParticles;
    public GameObject EDownParticles;
    public GameObject ERightParticles;
    public GameObject ELeftParticles;
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
            foreach (var panel in DDPanels)
                {
                panel.EnemySpeed();
                }
        }
        else
        {
            foreach (var panel in DDPanels)
            {
                panel.PlayerSpeed();
            }
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
                    panel.CanBeHit = false;
                    StartCoroutine(RightHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsRight)
                {
                    panel.Wrong();
                    panel.CanBeHit = false;
                    StartCoroutine(RightMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft) 
                {
                    panel.Correct();
                    panel.CanBeHit = false;
                    StartCoroutine(LeftHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsLeft)
                {
                    panel.Wrong();
                    panel.CanBeHit = false;
                    StartCoroutine(LeftMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp) 
                {
                    panel.Correct();
                    panel.CanBeHit = false;
                    StartCoroutine(UpHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsUp)
                {
                    panel.Wrong();
                    panel.CanBeHit = false;
                    StartCoroutine(UpMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !LifeTraker.Instance.IsEnemy)
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown) 
                {
                    panel.Correct();
                    panel.CanBeHit = false;
                    StartCoroutine(DownHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsDown)
                {
                    panel.Wrong();
                    panel.CanBeHit = false;
                    StartCoroutine(DownMiss());
                    _AudioSource.PlayOneShot(Lose);
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
    public IEnumerator UpMiss()
    {
        _UpHitZone.color = _Wrong;
        UpParticles.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _UpHitZone.color = _default;
    }
    public IEnumerator DownMiss()
    {
        _DownHitZone.color = _Wrong;
        DownParticles.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _DownHitZone.color = _default;
    }
    public IEnumerator RightMiss()
    {
        _RightHitZone.color = _Wrong;
        RightParticles.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _RightHitZone.color = _default;
    }
    public IEnumerator LeftMiss()
    {
        _LeftHitZone.color = _Wrong;
        LeftParticles.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _LeftHitZone.color = _default;
    }

    public void EnemyMess()
    {
        if(!LifeTraker.Instance.IsEnemy) return;
        float Rnum = Random.Range(0, 100);
        if (Rnum <= 25)
        {
            ERightParticles.SetActive(true);
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsRight)
                {
                    panel.Correct();
                    StartCoroutine(RightHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsRight)
                {
                    panel.Wrong();
                    StartCoroutine(RightMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }
        }

        if (Rnum <= 50 && Rnum > 25)
        {
            ELeftParticles.SetActive(true);
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft)
                {
                    panel.Correct();
                    StartCoroutine(LeftHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsLeft)
                {
                    panel.Wrong();
                    StartCoroutine(LeftMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }
        }

        if (Rnum <= 75 && Rnum > 50)
        {
            EUpParticles.SetActive(true);
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp)
                {
                    panel.Correct();
                    StartCoroutine(UpHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsUp)
                {
                    panel.Wrong();
                    StartCoroutine(UpMiss());
                    _AudioSource.PlayOneShot(Lose);
                    return;
                }
        }

        if (Rnum <= 100 && Rnum > 75)
        {
            EDownParticles.SetActive(true);
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown)
                {
                    panel.Correct();
                    StartCoroutine(DownHit());
                    UpdateHits();
                    return;
                }
            foreach (var panel in DDPanels)
                if (panel.IsFalling && !panel.IsDown)
                {
                    panel.Wrong();
                    StartCoroutine(DownMiss());
                    _AudioSource.PlayOneShot(Lose);
                }
        }
    }

    public void UpdateHits()
    {
        Hits++;
        _bar.fillAmount = Hits/MaxHit;
        _AudioSource.PlayOneShot(HitSound);
        if (Hits >= MaxHit)
        {
            if(!LifeTraker.Instance.IsEnemy)
            {
                Player._gameOver = true;
                LifeTraker.Instance.pOverHealt = (LifeTraker.Instance.MaxHealt * (LifeTraker.Instance.PartCount / 5));
                Player.GetUp();
            }
            if (LifeTraker.Instance.IsEnemy)
            {
                Enemy._gameOver = true;
                LifeTraker.Instance.eOverHealt = (LifeTraker.Instance.eMaxHealt * (LifeTraker.Instance.ePartCount / 5));
                Enemy.GetUp();
            }
            StopGame();
            _AudioSource.PlayOneShot(Succes);
            _clock.Stop();
            StageState.Instance.ResetFight = true;
            return;
        }
        float Rnum = Random.Range(0, 100);
        if (Rnum <= 25)
        {
            if (LifeTraker.Instance.IsEnemy) Enemy._fallen.SetTrigger("Twitch Down");
            else Player._fallen.SetTrigger("Twitch Down");
        }
        if (Rnum <= 50 && Rnum > 25)
        {
            if (LifeTraker.Instance.IsEnemy) Enemy._fallen.SetTrigger("Twitch Up");
            else Player._fallen.SetTrigger("Twitch Up");
        }
        if (Rnum <= 75 && Rnum > 50)
        {
            if (LifeTraker.Instance.IsEnemy) Enemy._fallen.SetTrigger("Twitch Right");
            else Player._fallen.SetTrigger("Twitch Right");
        }
        if (Rnum <= 100 && Rnum > 75)
        {
            if (LifeTraker.Instance.IsEnemy) Enemy._fallen.SetTrigger("Twitch Left");
            else Player._fallen.SetTrigger("Twitch Left");
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
        yield return new WaitForSeconds(1.25f);
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
