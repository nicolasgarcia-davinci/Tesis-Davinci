using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntermisionTimer : MonoBehaviour
{
    public float _timer;
    public float _IntermisionDuration;
    [SerializeField] TextMeshProUGUI _counter;
    public RestAnim _player;


    public void LaunchTimer()
    {
        DataSaver.Instance.LoadTimer();
        if (_timer <= 0 && LifeTraker.Instance.ResetTimer)
        {
            _timer = _IntermisionDuration;
            LifeTraker.Instance.ResetTimer = false;
        }
        StartCoroutine(CountDown());
    }


    public IEnumerator CountDown()
    {
        _counter.text = _timer.ToString();
        if (_timer <= 0 )
        {
            LoadManager.Instance.Round2();
            LifeTraker.Instance.ResetTimer = true;
            StageState.Instance.ResetFight = true;
            _player.Anim.SetTrigger("Exit Rest");
            StageSound.instance.Mute();
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
