using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterRound : PreView
{
    [SerializeField] TextMeshProUGUI RoundMessage;
    [SerializeField] TMP_FontAsset RoundFont;
    [SerializeField] TMP_FontAsset ReturnFont;

    void Start()
    {
        Again();
    }
    public void Again()
    {
        if (LifeTraker.Instance.ResetTimer)
        {
            RoundMessage.text = "Round " + LifeTraker.Instance.RundCounter;
            RoundMessage.font = RoundFont;
        }     
            _timer = 3;
            StartCoroutine(Clock());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Again();//ARREGLO TEMPORAL DIBU
        }

        if (StageState.Instance.ResetFight && HasToReset)
        {
            HasToReset = false;
            Again();
        }

        if (_timer == 0)
        {
            StopAllCoroutines();
            _timer = 3;
            HasToReset = true;
            _game.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
