using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIGetUp : MonoBehaviour
{
    public float _timer;
    public float _interval;

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
                float attackNum = Random.Range(0, 100);
                if (attackNum <= 50) Fallen.Instance.CheckLeft();
                if (attackNum >= 51) Fallen.Instance.Checkright();
                _timer = 0;
            }
        }
    }
}
