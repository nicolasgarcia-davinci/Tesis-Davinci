using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownedFigher : MonoBehaviour
{
    //public ArrowGroup[] _bodyIndicators;
    public IntermisionTimer _timer;
    public AudioRequester _stageTheme;
    public RestAnim Player;
    public HealMenu MyHeal;
    public LifeBar playerBar;
    public Animator FightCanUI;
    public int HealAmount;

    void Update()
    {
        if(StageState.Instance.ResetRepair)
        {
            StageState.Instance.ResetRepair=false;
            _timer.LaunchTimer();
            _stageTheme.CallSong();
            Player.SetBody();
            MyHeal.ResetHeals();
        }
    }

    public void ExitRepair()
    {
        Player.ResetRepair();
        FightCanUI.Play("Exit");
    }

    //public void Set()
    //{   
    //    _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
    //    _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
    //    _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
    //    _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
    //}

    //public void HealPart(LifeBar part)
    //{
    //    if (part == _bodyIndicators[0].partlifeIndicator)
    //    {
    //        LifeTraker.Instance.pHead += 10;
    //        _bodyIndicators[0].partlifeIndicator.ProgresiveEnter(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
    //        Player.CheckParts();
    //    }
    //    if (part == _bodyIndicators[1].partlifeIndicator)
    //    {
    //        LifeTraker.Instance.pRight += 10;
    //        _bodyIndicators[1].partlifeIndicator.ProgresiveEnter(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
    //        Player.CheckParts();
    //    }
    //    if (part == _bodyIndicators[2].partlifeIndicator)
    //    {
    //        LifeTraker.Instance.pLeft += 10;
    //        _bodyIndicators[2].partlifeIndicator.ProgresiveEnter(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
    //        Player.CheckParts();
    //    }
    //    if (part == _bodyIndicators[3].partlifeIndicator)
    //    {
    //        LifeTraker.Instance.pLegs += 10;
    //        _bodyIndicators[3].partlifeIndicator.ProgresiveEnter(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
    //        Player.CheckParts();
    //    }
    //}
    public void HealMenuPart(int partId)
    {
        if (partId == 0)
        {
            LifeTraker.Instance.pHead += HealAmount;
            LifeTraker.Instance.pOverHealt += HealAmount;
            if (LifeTraker.Instance.pOverHealt > LifeTraker.Instance.MaxHealt) LifeTraker.Instance.pOverHealt = LifeTraker.Instance.MaxHealt;
            playerBar.UpdateLife(LifeTraker.Instance.pOverHealt, LifeTraker.Instance.MaxHealt);
            if (LifeTraker.Instance.pHead > LifeTraker.Instance.maxHeadHealth) LifeTraker.Instance.pHead = LifeTraker.Instance.maxHeadHealth;
            //_bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
            Player.CheckParts();
            Player.RepairUP();
        }

        if (partId == 1)
        {
            LifeTraker.Instance.pRight += HealAmount;
            LifeTraker.Instance.pOverHealt += HealAmount;
            if (LifeTraker.Instance.pOverHealt > LifeTraker.Instance.MaxHealt) LifeTraker.Instance.pOverHealt = LifeTraker.Instance.MaxHealt;
            playerBar.UpdateLife(LifeTraker.Instance.pOverHealt, LifeTraker.Instance.MaxHealt);
            if (LifeTraker.Instance.pRight > LifeTraker.Instance.maxRarmHealth) LifeTraker.Instance.pRight = LifeTraker.Instance.maxRarmHealth;
            //_bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
            Player.CheckParts();
            Player.RepairRight();
        }

        if (partId == 2)
        {
            LifeTraker.Instance.pLeft += HealAmount;
            LifeTraker.Instance.pOverHealt += HealAmount;
            if (LifeTraker.Instance.pOverHealt > LifeTraker.Instance.MaxHealt) LifeTraker.Instance.pOverHealt = LifeTraker.Instance.MaxHealt;
            playerBar.UpdateLife(LifeTraker.Instance.pOverHealt, LifeTraker.Instance.MaxHealt);
            if (LifeTraker.Instance.pLeft > LifeTraker.Instance.maxLarmHealth) LifeTraker.Instance.pLeft = LifeTraker.Instance.maxLarmHealth;
            //_bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
            Player.CheckParts();
            Player.RepairLeft();
        }

        if (partId == 3)
        {
            LifeTraker.Instance.pLegs += HealAmount;
            LifeTraker.Instance.pOverHealt += HealAmount;
            if (LifeTraker.Instance.pOverHealt > LifeTraker.Instance.MaxHealt) LifeTraker.Instance.pOverHealt = LifeTraker.Instance.MaxHealt;
            playerBar.UpdateLife(LifeTraker.Instance.pOverHealt, LifeTraker.Instance.MaxHealt);
            if (LifeTraker.Instance.pLegs > LifeTraker.Instance.maxLegsHealth) LifeTraker.Instance.pLegs = LifeTraker.Instance.maxLegsHealth;
            //_bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
            Player.CheckParts();
            Player.RepairDown();
        }
    }
}
