using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterRound : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RoundMessage;
    [SerializeField] TMP_FontAsset RoundFont;
    [SerializeField] TMP_FontAsset ReturnFont;
    public GameObject _game;
    public RoundTimer RT;
    
    public void Again()
    {
        if (LifeTraker.Instance.ResetTimer)
        {
            RoundMessage.font = RoundFont;
            RoundMessage.text = "Ronda" + LifeTraker.Instance.RundCounter.ToString();
        }
    }

    public void CurtainCall()
    {
        StopAllCoroutines();
        _game.gameObject.SetActive(true);
        RT.LaunchTimer();
        FightControler.Instance.EnterStage();
        this.gameObject.SetActive(false);
    }
}
