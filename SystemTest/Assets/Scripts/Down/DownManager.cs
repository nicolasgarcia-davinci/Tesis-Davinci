using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownManager : MonoBehaviour
{
    public Fallen Fallen;
    public GetUp _clock;
    public AudioSource _AudioSource;
    public AudioClip Lose;

    public GameObject enemyLight;
    public GameObject playerLight;

    public GameObject gameCanvas;
    public GameObject gameKoState;
    void Start()
    {
        //if (!LifeTraker.Instance.IsEnemy)
        //{ 
        //    _Player.gameObject.SetActive(true);
        //    return;
        //}
        //
        //if (LifeTraker.Instance.IsEnemy)
        //{ 
        //    _Enemy.gameObject.SetActive(true);
        //    return;
        //}
        //if(LifeTraker.Instance.IsEnemy) enemyLight.SetActive(true);
        //if(!LifeTraker.Instance.IsEnemy) playerLight.SetActive(true);
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _clock.StopAllCoroutines();
            _AudioSource.PlayOneShot(Lose);
            Fallen._gameOver = true;
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
            Fallen._gameOver = true;
            gameCanvas.SetActive(true);
            gameKoState.SetActive(false);
            StageCam.Instance.GoToEndgameCam();
            LoadManager.Instance.GameOver();
        }

        if (LifeTraker.Instance.IsEnemy && _clock._timer == 7 && LifeTraker.Instance.EnemyKO == 1)
            Fallen._fallen.SetTrigger("GetUp");

        if (LifeTraker.Instance.IsEnemy && _clock._timer == 3 && LifeTraker.Instance.EnemyKO == 2)
            Fallen._fallen.SetTrigger("GetUp");
    }
}
