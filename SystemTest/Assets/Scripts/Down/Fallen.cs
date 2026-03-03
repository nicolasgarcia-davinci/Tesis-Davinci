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
    public Material DrillMaterial;
    public Material BoxerMaterial;
    public Material EBMaterial;
    public Material EDMaterial;

    public Image _bar;
    public Color _Invisible;

    public GameObject _rightArrow;
    public GameObject _leftArrow;

    public AudioClip Succes;
    public AudioSource Sound;

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
    void Start()
    {

        if (LifeTraker.Instance.IsEnemy)
        {
            _isEnemy = true;
            _maxBar = _defaultBar * LifeTraker.Instance.EnemyKO;
            _bar.color = _Invisible;
        }
        if (_isEnemy)
        {
            VignetControler.Instance.ActivateEnemyColor();
            _ai.gameObject.SetActive(true);
            _rightArrow.SetActive(false);
            _leftArrow.SetActive(false);
        }
        else
        {
            VignetControler.Instance.ActivatePlayerColor();
            _player.gameObject.SetActive(true);
            _maxBar = _defaultBar * LifeTraker.Instance.PlayerKO;
        }
        _fallen = GetComponentInChildren<Animator>();
        if (!_isEnemy)
        {
            _rightArrow.SetActive(!_rigth);
            _leftArrow.SetActive(!_left);
        }
        _bar.fillAmount = _actualBar / _maxBar;
        if (_isEnemy)
        {
            if (LifeTraker.Instance.Dificulty == 2) body.material = EDMaterial;
            else body.material = EBMaterial;
        }
        if (!_isEnemy)
        {
            if (LifeTraker.Instance.PlayerRobo == RoboType.Boxer) body.material = BoxerMaterial;
            if (LifeTraker.Instance.PlayerRobo == RoboType.Drill) body.material = DrillMaterial;
            ColorChange(ColorCordination.Instance.color1, ColorCordination.Instance.color2);
        }
    }

    public void CheckLeft()
    {
        if (_gameOver) return;
        if (!_left)
        {
            _actualBar++;
            if (_actualBar % 5 == 0) Play();
            _bar.fillAmount = _actualBar / _maxBar;
            if (_actualBar == _maxBar)
            {
                if (LifeTraker.Instance.IsEnemy) 
                    LifeTraker.Instance.eOverHealt = 70;
                else LifeTraker.Instance.pOverHealt = 70;
                
                if (LifeTraker.Instance.Dificulty > 2)
                {
                    Sound.PlayOneShot(Succes);
                    LoadManager.Instance.Round2Gym();
                    return;
                }

                    Sound.PlayOneShot(Succes);
                    LoadManager.Instance.Round2();
            }
            _left = true;
            _rigth = false;
            if (_isEnemy) 
                return;
            _rightArrow.SetActive(!_rigth);
            _leftArrow.SetActive(!_left);
        }
    }
    public void Checkright()
    {
        if (_gameOver) return;
        if (!_rigth)
        {
            _actualBar++;
            if (_actualBar % 5 == 0) Play();
            _bar.fillAmount = _actualBar / _maxBar;
            if (_actualBar == _maxBar)
            {
                if (LifeTraker.Instance.IsEnemy) 
                    LifeTraker.Instance.eOverHealt = 70;
                else LifeTraker.Instance.pOverHealt = 70;
                
                if (LifeTraker.Instance.Dificulty > 1)
                {
                    Sound.PlayOneShot(Succes);
                    LoadManager.Instance.Round2Gym();
                    return;
                }

                Sound.PlayOneShot(Succes);
                LoadManager.Instance.Round2();
            }
            _rigth = true;
            _left = false;

            if (_isEnemy) 
                return;

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
        body.material.SetFloat("_Transparencia", 1);
    }
}
