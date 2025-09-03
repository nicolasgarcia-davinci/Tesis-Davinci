using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class Fallen : MonoBehaviour
{
    public Animator _fallen;
    public float _maxBar;
    public float _actualBar;

    public bool _rigth;
    public bool _left;

    public Image _bar;
    // Start is called before the first frame update
    void Start()
    {
        _bar.fillAmount = _actualBar / _maxBar;
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Checkright();
        }
    }

    public void CheckLeft()
    {
        if (!_left)
        {
            _actualBar++;
            if (_actualBar % 5 == 0) Play();
            _bar.fillAmount = _actualBar / _maxBar;
            if (_actualBar == _maxBar)
            {
                if(LifeTraker.Instance.IsEnemy) LifeTraker.Instance.eOverHealt = 70;
                else LifeTraker.Instance.pOverHealt = 70;
                LoadManager.Instance.Round2();
            }
            _left = true;
            _rigth = false;
        }
    }
    public void Checkright()
    {
        if (!_rigth)
        {
            _actualBar++;
            if (_actualBar % 5 == 0) Play();
            _bar.fillAmount = _actualBar / _maxBar;
            if (_actualBar == _maxBar)
            {
                if (LifeTraker.Instance.IsEnemy) LifeTraker.Instance.eOverHealt = 70;
                else LifeTraker.Instance.pOverHealt = 70;
                LoadManager.Instance.Round2();
            }
            _rigth = true;
            _left = false;
        }
    }

    public void Play()
    {
        _fallen.speed = 1;
    }
    public void Stop()
    {
        _fallen.speed = 0;
    }
}
