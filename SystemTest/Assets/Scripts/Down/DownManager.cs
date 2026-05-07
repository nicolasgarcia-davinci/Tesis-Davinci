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

    public DDManager DDMachine;


    public GameObject enemyLight;
    public GameObject playerLight;

    public GameObject gameCanvas;
    public GameObject gameKoState;

    void Update()
    {
        if (_clock._timer<=10)
        {
            _stageTheme.CallSong();
        }
        if (StageState.Instance.ResetKO)
        {
            StageState.Instance.ResetKO = false;
            DDMachine.SetGame();
            if(LifeTraker.Instance.IsEnemy)
            {
                Enemy.gameObject.SetActive(true);
                Enemy.Set();
            }
            else
            {
                Player.gameObject.SetActive(true);
                Player.Set();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _clock.StopAllCoroutines();
            _stageTheme.EjectDisc();
            _AudioSource.PlayOneShot(Lose);
            Player._gameOver = true;
            gameCanvas.SetActive(true);
            gameKoState.SetActive(false);
            StageCam.Instance.GoToEndgameCam();
        }
        if(_clock._timer <= 0)
        {
            Debug.Log("UwU");
            _clock.StopAllCoroutines();
            _stageTheme.EjectDisc();
            _AudioSource.PlayOneShot(Lose);
            Player._gameOver = true;
            gameCanvas.SetActive(true);
            gameKoState.SetActive(false);
            StageCam.Instance.GoToEndgameCam();
        }

        //if (LifeTraker.Instance.IsEnemy && _clock._timer == 15 && LifeTraker.Instance.EnemyKO == 1)
        //{
        //    LifeTraker.Instance.eOverHealt = 50;
        //    StageState.Instance.ResetFight = true;
        //    _stageTheme.EjectDisc();
        //    _clock.Stop();
        //    Enemy.GetUp();
        //}
        //
        //if (LifeTraker.Instance.IsEnemy && _clock._timer == 7 && LifeTraker.Instance.EnemyKO == 2)
        //{
        //    LifeTraker.Instance.eOverHealt = 50;
        //    StageState.Instance.ResetFight = true;
        //    _stageTheme.EjectDisc();
        //    _clock.Stop();
        //    Enemy.GetUp();
        //}
    }
}
