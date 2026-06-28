using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumboTron : EnterRound
{
    [SerializeField] TextMeshProUGUI[] RoundScreen;
    [SerializeField] TMP_FontAsset ScreenFont;
    public Animator animator;
    public override void Again()
    {
        if (LifeTraker.Instance.ResetTimer)
        {
            foreach(TextMeshProUGUI box in RoundScreen)
            {
                box.font = ScreenFont;
                box.text = "Ronda" + LifeTraker.Instance.RundCounter.ToString();
            }
        }
    }
    public override void CurtainCall()
    {
        FightControler.Instance.CallFighters();
    }

    public void CalllText()
    {
        animator.Play("ChangeRound");
    }
}
