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

    void Start()
    {
        if(LifeTraker.Instance.PlayerRobo==RoboType.Boxer)_Boxer.gameObject.SetActive(true);
        if(LifeTraker.Instance.PlayerRobo==RoboType.Drill)_Drill.gameObject.SetActive(true);
    }



    void Update()
    {
        if(_clock._timer==0)
        {
            _Boxer._gameOver = true;
            if(_Boxer._isEnemy) _Win.SetActive(true);
            if(!_Boxer._isEnemy) _Loose.SetActive(true);
        }
    }
}
