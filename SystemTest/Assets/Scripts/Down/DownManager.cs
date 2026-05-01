using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownManager : MonoBehaviour
{
    public Fallen Player;
    public Fallen Enemy;
    public GetUp _clock;
    public AudioSource _AudioSource;
    public AudioRequester _stageTheme;
    public AudioClip Lose;


    public GameObject enemyLight;
    public GameObject playerLight;

    public GameObject gameCanvas;
    public GameObject gameKoState;

    void Update()
    {
        if (StageState.Instance.ResetKO)
        {
            StageState.Instance.ResetKO = false;
            if(LifeTraker.Instance.IsEnemy)
            {
                Enemy.gameObject.SetActive(true);
                Enemy.Set();
                _stageTheme.CallSong();
            }
            else
            {
                Player.gameObject.SetActive(true);
                Player.Set();
                _stageTheme.CallSong();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _clock.StopAllCoroutines();
            _AudioSource.PlayOneShot(Lose);
            Player._gameOver = true;
            gameCanvas.SetActive(true);
            gameKoState.SetActive(false);
            StageCam.Instance.GoToEndgameCam();
            LoadManager.Instance.GameOver();
        }
        if(_clock._timer <= 0)
        {
            Debug.Log("UwU");
            _clock.StopAllCoroutines();
            _AudioSource.PlayOneShot(Lose);
            Player._gameOver = true;
            gameCanvas.SetActive(true);
            gameKoState.SetActive(false);
            StageCam.Instance.GoToEndgameCam();
            LoadManager.Instance.GameOver();
        }

        if (LifeTraker.Instance.IsEnemy && _clock._timer == 15 && LifeTraker.Instance.EnemyKO == 1)
        {
            Enemy.GetUp();
            _clock.Stop();
            LifeTraker.Instance.eOverHealt = 50;
        }

        if (LifeTraker.Instance.IsEnemy && _clock._timer == 7 && LifeTraker.Instance.EnemyKO == 2)
        {
            Enemy.GetUp();
            _clock.Stop();
            LifeTraker.Instance.eOverHealt = 50;
        }
    }
}
