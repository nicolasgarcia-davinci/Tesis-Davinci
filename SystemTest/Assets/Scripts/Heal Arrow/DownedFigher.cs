using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownedFigher : MonoBehaviour
{
    public ArrowGroup[] _bodyIndicators;
    public bool IsPlayer;

    void Update()
    {

    }
    void Start()
    {
        if(!LifeTraker.Instance.IsEnemy)
        {
            IsPlayer = true;
        }
        if(!IsPlayer)
        {
           _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.eHead, LifeTraker.Instance.MaxHealt);
           _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.eRight, LifeTraker.Instance.MaxHealt);
           _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.eLeft, LifeTraker.Instance.MaxHealt);
           _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.eLegs, LifeTraker.Instance.MaxHealt);
        }
        if(IsPlayer)
        {
            _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.MaxHealt);
            _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.MaxHealt);
            _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.MaxHealt);
            _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.MaxHealt);
        }
    }

    public void HealPart(LifeBar part)
    {
        if(!IsPlayer)
        {
            if (part == _bodyIndicators[0].partlifeIndicator)
            {
                LifeTraker.Instance.eHead += 10;
                _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.eHead, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[1].partlifeIndicator)
            {
                LifeTraker.Instance.eRight += 10;
                _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.eRight, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[2].partlifeIndicator)
            {
                LifeTraker.Instance.eLeft += 10;
                _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.eLeft, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[3].partlifeIndicator)
            {
                LifeTraker.Instance.eLegs += 10;
                _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.eLegs, LifeTraker.Instance.MaxHealt);
            }
        }
        if (IsPlayer)
        {
            if (part == _bodyIndicators[0].partlifeIndicator)
            {
                LifeTraker.Instance.pHead += 10;
                _bodyIndicators[0].partlifeIndicator.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[1].partlifeIndicator)
            {
                LifeTraker.Instance.pRight += 10;
                _bodyIndicators[1].partlifeIndicator.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[2].partlifeIndicator)
            {
                LifeTraker.Instance.pLeft += 10;
                _bodyIndicators[2].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.MaxHealt);
            }
            if (part == _bodyIndicators[3].partlifeIndicator)
            {
                LifeTraker.Instance.pLegs += 10;
                _bodyIndicators[3].partlifeIndicator.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.MaxHealt);
            }
        }

    }
}
