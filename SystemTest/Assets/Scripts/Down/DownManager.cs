using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownManager : MonoBehaviour
{
    public Fallen _fighter;
    public GetUp _clock;

    public GameObject _Loose;
    public GameObject _Win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_clock._timer==0)
        {
            _fighter._gameOver = true;
            if(_fighter._isEnemy) _Win.SetActive(true);
            if(!_fighter._isEnemy) _Loose.SetActive(true);
        }
    }
}
