using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermisionTimer : MonoBehaviour
{
    public float _timer;
    public float _IntermisionDuration;
    [SerializeField] TextMeshProUGUI _counter;
    public GameObject TransitToFight;
    public RepairSpawner spawner;

    public bool _hasUpdated;
    void Start()
    {
        _timer = _IntermisionDuration;
        _hasUpdated = true;
        StartCoroutine(CountDown());
    }

    public void Update()
    {
        if (!_hasUpdated)
            LaunchTimer();
    }

    public void LaunchTimer()
    {
        DataSaver.Instance.LoadTimer();
        if (_timer <= 0 || LifeTraker.Instance.ResetTimer)
        {
            _timer = _IntermisionDuration;
            _hasUpdated = true;
            LifeTraker.Instance.ResetTimer = false;
        }
        StartCoroutine(CountDown());
    }
    public void SetUpdate()
    {
        _hasUpdated = false;
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if (_timer == 0 && LifeTraker.Instance.Dificulty == 1)
        { 
           LoadManager.Instance.Round2();
            LifeTraker.Instance.ResetTimer=true;
            SetUpdate();
            TransitToFight.gameObject.SetActive(true);
            spawner.DesPawn();
            StopAllCoroutines();
        }
        if (_timer == 0 && LifeTraker.Instance.Dificulty==2) LoadManager.Instance.Round2Gym();
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
}
