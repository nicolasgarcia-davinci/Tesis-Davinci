using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    public float _timer;
    public float _RoundTime;
    [SerializeField] TextMeshProUGUI _counter;

    public static RoundTimer instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    void Start()
    {
        DataSaver.Instance.LoadTimer();
        if (_timer == 0) _timer = _RoundTime;
        StartCoroutine(CountDown());
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if (_timer == 0) LoadManager.Instance.LoadIntermision();
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
