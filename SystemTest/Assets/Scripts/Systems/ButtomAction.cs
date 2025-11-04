using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtomAction : MonoBehaviour
{
    [SerializeField] string _labelText;
    [SerializeField] TextMeshProUGUI _label;
    public GloveAnim _selector;
    public MenuNavigation _miMenu;
    public MenuRobo _Display;
    public float activationdelay;
    public bool _isSelected;
    public bool _Activated;
    public int _targetID;
    public ButtomType _thisType;
    
    public void Start()
    {
        _label.text = _labelText;
        _miMenu = GetComponentInParent<MenuNavigation>();
    }

    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isSelected && !_Activated)
        {  
            _Activated = true;
            StartCoroutine(Action());
        }
    }

    public IEnumerator Action()
    {
        _selector.Hit();

        yield return new WaitForSeconds(activationdelay);

        _selector.gameObject.SetActive(false);

        if (_thisType == ButtomType.NavButtom) ChangeMenu();

        if (_thisType == ButtomType.LoadStage) LoadManager.Instance.LoadRing();

        if (_thisType == ButtomType.LoadMenu) LoadManager.Instance.LoadMenu();

        if (_thisType == ButtomType.Quit) Application.Quit();

        if (_thisType == ButtomType.Return) ChangeMenu();

        if (_thisType == ButtomType.Continue)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.LoadGym();
        }

        if (_thisType == ButtomType.NextLvl)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.LoadGym();
        }

        if (_thisType == ButtomType.RoboBoxer)
        {
            LifeTraker.Instance.PlayerRobo = RoboType.Boxer;
            _Display.ActivateBoxer();
            ChangeMenu();
        }

        if (_thisType == ButtomType.RoboDrill)
        {
            LifeTraker.Instance.PlayerRobo = RoboType.Drill;
            _Display.ActivateDrill();
            ChangeMenu();
        }
        if (_thisType == ButtomType.NextLvl)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.LoadGym();
        }
    }

    public void Select()
    {
        _selector.gameObject.SetActive(true);
        _isSelected = true;
    }
    public void DeSelect()
    {
        _selector.gameObject.SetActive(false);
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
