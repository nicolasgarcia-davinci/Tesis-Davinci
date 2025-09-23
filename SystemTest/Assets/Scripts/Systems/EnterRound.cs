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
        if (LifeTraker.Instance.ResetTimer)
        {
            RoundMessage.text = "Round " + LifeTraker.Instance.RundCounter;
            RoundMessage.font = RoundFont;
        }
        else
        { 
            RoundMessage.text = "Back in the Ring";
            RoundMessage.font = ReturnFont;
        }
        StartCoroutine(Clock());
    }

    void Update()
    {
        if (_timer == 0)
        {
            _game.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
