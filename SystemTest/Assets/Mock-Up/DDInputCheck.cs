using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDInputCheck : MonoBehaviour
{
    public DDArrow[] CollectionsOnScreen;
    public int MaxIndex = 4;
    public int Index=0;

    public float _defaultBar;
    public float _maxBar;
    public float _actualBar;

    public Image _bar;
    public Color _Invisible;

    bool check = false;
    void Start()
    {
        if (LifeTraker.Instance.IsEnemy)
        {
            _maxBar = _defaultBar * LifeTraker.Instance.EnemyKO;
            _bar.color = _Invisible;
        }
        else
        {
            _maxBar = _defaultBar * LifeTraker.Instance.PlayerKO;
        }
        _bar.fillAmount = _actualBar / _maxBar;
        foreach (var item in CollectionsOnScreen)
        {
            item.gameObject.SetActive(false);
        }
        ActivateSet();
    }

    void Update()
    {
        //if (check) return;
        //if (Input.GetKeyDown(KeyCode.UpArrow)) CheckUp();
        //if (Input.GetKeyDown(KeyCode.RightArrow)) CheckRight();
        //if (Input.GetKeyDown(KeyCode.LeftArrow)) CheckLeft();
        //if (Input.GetKeyDown(KeyCode.DownArrow)) CheckDown();
    }
    public void Restart()
    {
        _bar.fillAmount = 0;
        _actualBar = 0;
        MaxIndex = 4;
        if (LifeTraker.Instance.IsEnemy)
        {
            _maxBar = _defaultBar * LifeTraker.Instance.EnemyKO;
            _bar.color = _Invisible;
        }
        else
        {
            _maxBar = _defaultBar * LifeTraker.Instance.PlayerKO;
        }
        _bar.fillAmount = _actualBar / _maxBar;
        foreach (var item in CollectionsOnScreen)
        {
            item.gameObject.SetActive(false);
        }
        ActivateSet();
    }

    public void ActivateSet()
    {
        Index = 0;
        while(Index<MaxIndex)
        {
            CollectionsOnScreen[Index].gameObject.SetActive(true);
            CollectionsOnScreen[Index].Randomize();
            Index++;
        }
        Index = 0;
        if(MaxIndex>=CollectionsOnScreen.Length) return; 
        MaxIndex++;
    }

    public void Deactivate()
    {
        Index = 0;
        while (Index < MaxIndex)
        {
            CollectionsOnScreen[Index].gameObject.SetActive(false);
            Index++;
        }
        ActivateSet();
    }
    public void CheckUp()
    {
        if (check) return;
        Debug.Log("up");
        if (CollectionsOnScreen[Index].IsUp)
        {
            CollectionsOnScreen[Index].ChangeToCorrect();
            Index++;
        }
        if (Index == MaxIndex-1) StartCoroutine(DelayRestar());
        
    }
    public void CheckRight()
    {
        if (check) return;
        Debug.Log("right");
        if (CollectionsOnScreen[Index].IsRight)
        {
            CollectionsOnScreen[Index].ChangeToCorrect();
            Index++;
        }
        if (Index == MaxIndex-1) StartCoroutine(DelayRestar());
    }
    public void CheckLeft()
    {
        if (check) return;
        Debug.Log("left");
        if (CollectionsOnScreen[Index].IsLeft)
        {
            CollectionsOnScreen[Index].ChangeToCorrect();
            Index++;
        }
        if (Index == MaxIndex-1) StartCoroutine(DelayRestar());

    }
    public void CheckDown()
    {
        if(check)return;
            Debug.Log("left");
        if (CollectionsOnScreen[Index].IsDown)
        {
            CollectionsOnScreen[Index].ChangeToCorrect();
            Index++;
        }
        if (Index == MaxIndex-1) StartCoroutine(DelayRestar());
    }
    public IEnumerator DelayRestar()
    {
        check = true;
        _actualBar += 30;
        _bar.fillAmount = _actualBar / _maxBar;
        yield return new WaitForSeconds(0.5f);
        Index = 0;
        while (Index < MaxIndex)
        {
            CollectionsOnScreen[Index].ChangeToReset();
            Index++;
        }
        Deactivate();
        Index = 0;
        check = false;
    }
}
