using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermisionTimer : MonoBehaviour
{
    public float _timer;
    [SerializeField] TextMeshProUGUI _counter;
    public GameObject TransitToFight;
    void Start()
    {
        StartCoroutine(CountDown());
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if (_timer == 0 && LifeTraker.Instance.Dificulty == 1)
        { 
           LoadManager.Instance.Round2();
            TransitToFight.gameObject.SetActive(true);
            LifeTraker.Instance.ResetTimer=true;
            StopAllCoroutines();
        }
        if (_timer == 0 && LifeTraker.Instance.Dificulty==2) LoadManager.Instance.Round2Gym();
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
