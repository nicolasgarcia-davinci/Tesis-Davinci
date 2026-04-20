using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownedFigher : MonoBehaviour
{
    public ArrowGroup[] _bodyIndicators;
    public IntermisionTimer _timer;

    void Update()
    {
        if(StageState.Instance.ResetRepair)
        {
            StageState.Instance.ResetRepair=false;
            StageCam.Instance.GoToRepairCam();
            _timer.LaunchTimer();
            Set();
        }
    }

    public void Start()
    {

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
        }
        if (part == _bodyIndicators[1].partlifeIndicator)
        {
            LifeTraker.Instance.pRight += 10;
            _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
        }
        if (part == _bodyIndicators[2].partlifeIndicator)
        {
            LifeTraker.Instance.pLeft += 10;
            _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
        }
        if (part == _bodyIndicators[3].partlifeIndicator)
        {
            LifeTraker.Instance.pLegs += 10;
            _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
        }
    }
}
