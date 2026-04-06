using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetUp : MonoBehaviour
{
    public float _timer;
    public float _KOTime;
    public bool _hasUpdated;
    [SerializeField] TextMeshProUGUI _counter;
    void Start()
    {
        StartCoroutine(CountDown());
    }

    public void Set()
    {
        _timer = _KOTime;
        _hasUpdated = true;
        StartCoroutine(CountDown());
    }

    public void Update()
    {
        if(!_hasUpdated) Set();
    }


    public IEnumerator CountDown()
    {
        _hasUpdated=true;
        _counter.text = _timer.ToString();
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
