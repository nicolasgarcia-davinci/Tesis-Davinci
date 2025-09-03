using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermisionTimer : MonoBehaviour
{
    public float _timer;
    [SerializeField] TextMeshProUGUI _counter;
    void Start()
    {
        StartCoroutine(CountDown());
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if (_timer == 0) LoadManager.Instance.Round2();
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
