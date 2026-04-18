using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownManager : MonoBehaviour
{
    public Fallen _Enemy;
    public Fallen _Player;
    public GetUp _clock;
    public AudioSource _AudioSource;
    public AudioClip Lose;

    public GameObject enemyLight;
    public GameObject playerLight;
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
            _Player._gameOver = true;
            _Enemy._gameOver = true;
            LoadManager.Instance.GameOver();
        }
        if(_clock._timer==0)
        {
            _clock.StopAllCoroutines();
            _AudioSource.PlayOneShot(Lose);
            _Player._gameOver = true;
            _Enemy._gameOver = true;
            LoadManager.Instance.GameOver();
        }
    }
}
