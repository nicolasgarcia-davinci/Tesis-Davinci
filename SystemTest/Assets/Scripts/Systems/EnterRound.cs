using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterRound : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RoundMessage;
    [SerializeField] TMP_FontAsset RoundFont;
    
    public virtual void Again()
    {
        if (LifeTraker.Instance.ResetTimer)
        {
            RoundMessage.font = RoundFont;
            RoundMessage.text = "Ronda" + LifeTraker.Instance.RundCounter.ToString();
        }
    }

    public virtual void CurtainCall()
    {
        FightControler.Instance.CallFighters();
        this.gameObject.SetActive(false);
    }
}
