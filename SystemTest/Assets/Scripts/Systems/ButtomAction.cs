using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtomAction : MonoBehaviour
{
    [SerializeField] string _labelText;
    [SerializeField] TextMeshProUGUI _label;
    public GameObject _selector;
    public MenuNavigation _miMenu;
    public MenuRobo _Display;
    public bool _isSelected;
    public int _targetID;
    public ButtomType _thisType;
    
    public void Start()
    {
        _label.text = _labelText;
        _miMenu = GetComponentInParent<MenuNavigation>();
    }

    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isSelected)
        {  
            if(_thisType == ButtomType.NavButtom) ChangeMenu();

            if (_thisType == ButtomType.LoadStage) LoadManager.Instance.LoadRing();

            if (_thisType == ButtomType.LoadMenu) LoadManager.Instance.LoadMenu();

            if(_thisType == ButtomType.Quit) Application.Quit();

            if (_thisType == ButtomType.Return) ChangeMenu();

            if (_thisType == ButtomType.Continue) LoadManager.Instance.LoadGym();

            if (_thisType == ButtomType.NextLvl)
            {
                LifeTraker.Instance.Dificulty++;
                LoadManager.Instance.LoadGym();
            }

                if (_thisType == ButtomType.RoboBoxer)
            {
                LifeTraker.Instance.PlayerRobo=RoboType.Boxer;
                _Display.ActivateBoxer();
                ChangeMenu();
            }

            if (_thisType == ButtomType.RoboDrill)
            {
                LifeTraker.Instance.PlayerRobo = RoboType.Drill;
                _Display.ActivateDrill();
                ChangeMenu();
            }
            if(_thisType==ButtomType.NextLvl)
            {
                LifeTraker.Instance.Dificulty=2;
                LoadManager.Instance.LoadGym();
            }
        }
    }

    public void Select()
    {
        _selector.SetActive(true);
        _isSelected = true;
    }
    public void DeSelect()
    {
        _selector.SetActive(false);
        _isSelected = false;
    }

    public void ChangeMenu()
    {
        _miMenu.Menu(_targetID);
    }
}
public enum ButtomType
{
    NavButtom, LoadStage, LoadMenu, Color1, Color2, Quit, Return, Continue, NextLvl , RoboBoxer, RoboDrill
}
