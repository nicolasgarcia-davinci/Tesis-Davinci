using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownedFigher : MonoBehaviour
{
    public ArrowGroup[] _bodyIndicators;
    public IntermisionTimer _timer;
    public AudioRequester _stageTheme;
    public RestAnim Player;
    public HealMenu MyHeal;

    void Update()
    {
        if(StageState.Instance.ResetRepair)
        {
            StageState.Instance.ResetRepair=false;
            _timer.LaunchTimer();
            _stageTheme.CallSong();
            Player.SetBody();
            //Set();
            MyHeal.ResetHeals();
        }
    }

    public void Set()
    {   
        _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
        _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
        _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
        _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
    }

    public void HealPart(LifeBar part)
    {
        if (part == _bodyIndicators[0].partlifeIndicator)
        {
            LifeTraker.Instance.pHead += 10;
            _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
            Player.CheckParts();
        }
        if (part == _bodyIndicators[1].partlifeIndicator)
        {
            LifeTraker.Instance.pRight += 10;
            _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
            Player.CheckParts();
        }
        if (part == _bodyIndicators[2].partlifeIndicator)
        {
            LifeTraker.Instance.pLeft += 10;
            _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
            Player.CheckParts();
        }
        if (part == _bodyIndicators[3].partlifeIndicator)
        {
            LifeTraker.Instance.pLegs += 10;
            _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
            Player.CheckParts();
        }
    }
    public void HealMenuPart(int partId)
    {
        if (partId == 0)
        {
            LifeTraker.Instance.pHead += 30;
            //_bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
            Player.CheckParts();
            Player.RepairUP();
        }

        if (partId == 1)
        {
            LifeTraker.Instance.pRight += 30;
            //_bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
            Player.CheckParts();
            Player.RepairRight();
        }

        if (partId == 2)
        {
            LifeTraker.Instance.pLeft += 30;
            //_bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
            Player.CheckParts();
            Player.RepairLeft();
        }

        if (partId == 3)
        {
            LifeTraker.Instance.pLegs += 30;
            //_bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
            Player.CheckParts();
            Player.RepairDown();
        }
    }
}
