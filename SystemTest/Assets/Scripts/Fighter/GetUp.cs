using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetUp : MonoBehaviour
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
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
