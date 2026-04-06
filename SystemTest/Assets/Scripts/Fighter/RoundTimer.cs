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

    public GameObject TransitToRepair;

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


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if(_timer <= 10)
        {
            _counter.color = endTime;
            _animator.SetTrigger("Pulse");
        }
        if (_timer == 0)
        {
            if(LifeTraker.Instance.Dificulty==1)
            {
                LifeTraker.Instance.RundCounter++;
                LifeTraker.Instance.ResetTimer = true;
                LoadManager.Instance.LoadIntermision();
                TransitToRepair.SetActive(true);
            }
            if (LifeTraker.Instance.Dificulty == 2)
            {
                LifeTraker.Instance.RundCounter++;
                LifeTraker.Instance.ResetTimer = true;
                LoadManager.Instance.LoadGymRest();
            }
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
    }
    public void UnPause()
    {
        StartCoroutine(CountDown());
    }
}
