using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class Fallen : MonoBehaviour
{
    public Animator _fallen;
    //public float _defaultBar;
    //public float _maxBar;
    //public float _actualBar;

    //public bool _rigth;
    //public bool _left;
    public bool _gameOver;
    public bool _isEnemy;

    public GetUpPlayer _player;
    public AIGetUp _ai;

    public DDInputCheck _Cheker;


    [Header("Mesh y materials")]
    public SkinnedMeshRenderer body;
    public Material DrillMaterial;
    public Material BoxerMaterial;
    public Material EBMaterial;
    public Material EDMaterial;

    //public Image _bar;
    //public Color _Invisible;

    //public GameObject _rightArrow;
    //public GameObject _leftArrow;

    public AudioClip Succes;
    public AudioSource Sound;

    public GetUp _timer;

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
        Set();
    }
    public void Update()
    {
        if (StageState.Instance.ResetKO)
        {
            StageState.Instance.ResetKO = false;
            Set();
            _timer.Set();
        }
    }
    public void Set()
    {
        _Cheker.Restart();
        if (LifeTraker.Instance.IsEnemy)
        {
            _isEnemy = true;
            //_maxBar = _defaultBar * LifeTraker.Instance.EnemyKO;
            //_bar.color = _Invisible;
        }
        if (_isEnemy)
        {
            VignetControler.Instance.ActivateEnemyColor();
            _ai.gameObject.SetActive(true);
            //_rightArrow.SetActive(false);
            //_leftArrow.SetActive(false);
        }
        else
        {
            VignetControler.Instance.ActivatePlayerColor();
            _player.gameObject.SetActive(true);
            //_maxBar = _defaultBar * LifeTraker.Instance.PlayerKO;
        }
        _fallen = GetComponentInChildren<Animator>();
        if (!_isEnemy)
        {
            //_rightArrow.SetActive(!_rigth);
            //_leftArrow.SetActive(!_left);
        }
        //_bar.fillAmount = _actualBar / _maxBar;
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
        _Cheker.CheckLeft();
        if(_Cheker._actualBar >= _Cheker._maxBar)
        {
            if (LifeTraker.Instance.IsEnemy)
                LifeTraker.Instance.eOverHealt = 70;
            else LifeTraker.Instance.pOverHealt = 70;

            Sound.PlayOneShot(Succes);
            LoadManager.Instance.Round2();
            _timer.Stop();
            StageState.Instance.ResetFight=true;
            StageCam.Instance.GoToFightCamFromKO();
        }
        
    }
    public void CheckRight()
    {
        if (_gameOver) return;
        _Cheker.CheckRight();
        if (_Cheker._actualBar >= _Cheker._maxBar)
        {
            if (LifeTraker.Instance.IsEnemy)
                LifeTraker.Instance.eOverHealt = 70;
            else LifeTraker.Instance.pOverHealt = 70;

            Sound.PlayOneShot(Succes);
            LoadManager.Instance.Round2();
            _timer.Stop();
            StageState.Instance.ResetFight = true;
            StageCam.Instance.GoToFightCamFromKO();
        }
    }
    public void CheckUp()
    {
        if (_gameOver) return;
        _Cheker.CheckUp();
        if (_Cheker._actualBar >= _Cheker._maxBar)
        {
            if (LifeTraker.Instance.IsEnemy)
                LifeTraker.Instance.eOverHealt = 70;
            else LifeTraker.Instance.pOverHealt = 70;

            Sound.PlayOneShot(Succes);
            LoadManager.Instance.Round2();
            _timer.Stop();
            StageState.Instance.ResetFight = true;
            StageCam.Instance.GoToFightCamFromKO();
        }
    }
    public void CheckDown()
    {
        if (_gameOver) return;
        _Cheker.CheckDown();
        if (_Cheker._actualBar >= _Cheker._maxBar)
        {
            if (LifeTraker.Instance.IsEnemy)
                LifeTraker.Instance.eOverHealt = 70;
            else LifeTraker.Instance.pOverHealt = 70;

            Sound.PlayOneShot(Succes);
            _timer.Stop();
            LoadManager.Instance.Round2();
            StageState.Instance.ResetFight = true;
            StageCam.Instance.GoToFightCamFromKO();
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
