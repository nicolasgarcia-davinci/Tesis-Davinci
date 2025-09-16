using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterRound : PreView
{
    [SerializeField] TextMeshProUGUI RoundMessage;
    // Start is called before the first frame update
    void Start()
    {
        if (LifeTraker.Instance.ResetTimer) RoundMessage.text = "Round " + LifeTraker.Instance.RundCounter;
        else RoundMessage.text = "Back in the Ring";
        StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer == 0)
        {
            _game.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
