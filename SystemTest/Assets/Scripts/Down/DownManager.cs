using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownManager : MonoBehaviour
{
    public Fallen _Boxer;
    public Fallen _Drill;
    public GetUp _clock;

    public GameObject _Loose;
    public GameObject _Win;

    public GameObject enemyLight;
    public GameObject playerLight;
    void Start()
    {
        if(LifeTraker.Instance.PlayerRobo==RoboType.Boxer && !LifeTraker.Instance.IsEnemy)_Boxer.gameObject.SetActive(true);
        if(LifeTraker.Instance.Dificulty==1 && LifeTraker.Instance.IsEnemy)_Boxer.gameObject.SetActive(true);
        if (LifeTraker.Instance.PlayerRobo == RoboType.Drill && !LifeTraker.Instance.IsEnemy) _Drill.gameObject.SetActive(true);
        if (LifeTraker.Instance.Dificulty == 2 && LifeTraker.Instance.IsEnemy) _Drill.gameObject.SetActive(true);
        if(LifeTraker.Instance.IsEnemy) enemyLight.SetActive(true);
        if(!LifeTraker.Instance.IsEnemy) playerLight.SetActive(true);
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            LoadManager.Instance.GameOver();
        }
        if(_clock._timer==0)
        {
            _Boxer._gameOver = true;
            _Drill._gameOver = true;
            if(_Boxer._isEnemy) _Win.SetActive(true);
            if(!_Boxer._isEnemy) _Loose.SetActive(true);
        }
    }
}
