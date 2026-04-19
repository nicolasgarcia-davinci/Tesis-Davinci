using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    public float _timer;
    public float _RoundTime;
    [SerializeField] TextMeshProUGUI _counter;
    public Color endTime;
    public Animator _animator;



    public static RoundTimer instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    void Start()
    {
        DataSaver.Instance.LoadTimer();
        if (_timer <= 0 || LifeTraker.Instance.ResetTimer)
        {
            _timer = _RoundTime;
            LifeTraker.Instance.ResetTimer = false;
        }
        StartCoroutine(CountDown());
    }
    public void LaunchTimer()
    {
        _counter.color = Color.white;
        _animator.SetBool("Pulse", false);
        DataSaver.Instance.LoadTimer();
        if (_timer <= 0 || LifeTraker.Instance.ResetTimer)
        {
            _timer = _RoundTime;
            LifeTraker.Instance.ResetTimer = false;
        }
        StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if(_timer <= 10)
        {
            _counter.color = endTime;
            _animator.SetBool("Pulse",true);
        }
        if (_timer == 0)
        {
            StopAllCoroutines();
            FightControler.Instance.ExitStage();
            //StageCam.Instance.GoToRepairCam();

            //if (LifeTraker.Instance.Dificulty==1)
            //{
            //    LifeTraker.Instance.RundCounter++;
            //    LifeTraker.Instance.ResetTimer = true;
            //    LoadManager.Instance.LoadIntermision();
            //    StageState.Instance.ResetRepair=true;
            //    StopAllCoroutines();
            //    TransitToRepair.SetActive(true);
            //}
            //if (LifeTraker.Instance.Dificulty == 2)
            //{
            //    LifeTraker.Instance.RundCounter++;
            //    LifeTraker.Instance.ResetTimer = true;
            //    LoadManager.Instance.LoadGymRest();
            //}
        }
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }

    public void Pause()
    {
        StopAllCoroutines();
        StopCoroutine(CountDown());
        _counter.text = "";
    }

    public void Stop()
    {
        StopAllCoroutines();
        StopCoroutine(CountDown());
        _counter.text = "";
    }
    public void UnPause()
    {
        StartCoroutine(CountDown());
    }
}
