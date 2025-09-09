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
    public bool _gameOver;
    public bool _isEnemy;

    public GetUpPlayer _player;
    public AIGetUp _ai;

    public Image _bar;

    public GameObject _rightArrow;
    public GameObject _leftArrow;

    public static Fallen Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        if(LifeTraker.Instance.IsEnemy) _isEnemy=true;
        if(_isEnemy) _ai.gameObject.SetActive(true);
        else _player.gameObject.SetActive(true);
        _fallen = GetComponentInChildren<Animator>();
        _rightArrow.SetActive(!_rigth);
        _leftArrow.SetActive(!_left);
        _bar.fillAmount = _actualBar / _maxBar;
        Play();
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
            _rightArrow.SetActive(!_rigth);
            _leftArrow.SetActive(!_left);
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
            _rightArrow.SetActive(!_rigth);
            _leftArrow.SetActive(!_left);
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
