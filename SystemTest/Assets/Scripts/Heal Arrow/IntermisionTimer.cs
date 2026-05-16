using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermisionTimer : MonoBehaviour
{
    public float _timer;
    public float _IntermisionDuration;
    [SerializeField] TextMeshProUGUI _counter;


    public void LaunchTimer()
    {
        _timer = _IntermisionDuration;
        StartCoroutine(CountDown());
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if(_timer < 10) _counter.text = "0"+_timer.ToString();
        if (_timer <= 0 )
        {
            LifeTraker.Instance.ResetTimer = true;
            StageState.Instance.ResetFight = true;
            StageSound.instance.Mute();
            StageCam.Instance.GoToRound2();
            Stop();
        }
        yield return new WaitForSeconds(1);
        _timer--;
        StartCoroutine(CountDown());
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
}
