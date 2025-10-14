using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class Fallen : MonoBehaviour
{
    public Animator _fallen;
    public float _defaultBar;
    public float _maxBar;
    public float _actualBar;

    public bool _rigth;
    public bool _left;
    public bool _gameOver;
    public bool _isEnemy;

    public GetUpPlayer _player;
    public AIGetUp _ai;


    [Header("Mesh y materials")]
    public SkinnedMeshRenderer body;
    public Material PMaterial;
    public Material EMaterial;

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

        if(LifeTraker.Instance.IsEnemy)
        {
            _isEnemy=true;
            _maxBar=_defaultBar*LifeTraker.Instance.EnemyKO;
        }
        if(_isEnemy) _ai.gameObject.SetActive(true);
        else
        {
            _player.gameObject.SetActive(true);
            _maxBar = _defaultBar * LifeTraker.Instance.PlayerKO;
        }
        _fallen = GetComponentInChildren<Animator>();
        _rightArrow.SetActive(!_rigth);
        _leftArrow.SetActive(!_left);
        _bar.fillAmount = _actualBar / _maxBar;
        Play();
        if(_isEnemy)body.material = EMaterial;
        if(!_isEnemy)
        {
            body.material = PMaterial;
            ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
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
        CamPos.Instance.changePos();
    }
    public void Stop()
    {
        _fallen.speed = 0;
    }
    public void ColorChange(Color color1, Color color2)
    {
        body.material.SetColor("_Color1", color1);
        body.material.SetColor("_Color2", color2);
    }
}
