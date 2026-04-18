using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIGetUp : MonoBehaviour
{
    public float _timer;
    public float _interval;
    public int _attNum;

    public void Start()
    {
        if (LifeTraker.Instance.Dificulty == 2) _interval = _interval / 2;
    }

    void Update()
    {
        if (!Fallen.Instance._gameOver)
        {
            _timer += Time.deltaTime;
            if(_timer > _interval )
            {
                _attNum = Random.Range(0, 100);
                if (_attNum <= 25) Fallen.Instance.CheckLeft();
                if (_attNum <= 50 && _attNum > 25) Fallen.Instance.CheckRight();
                if (_attNum <= 75 && _attNum > 50) Fallen.Instance.CheckUp();
                if (_attNum <= 100 && _attNum > 75) Fallen.Instance.CheckDown();
                _timer = 0;
            }
        }
    }
}
