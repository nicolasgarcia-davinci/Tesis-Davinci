using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtomAction : MonoBehaviour
{
    public string _labelText;
    public TextMeshProUGUI _label;
    public GameObject _selector;
    public MenuNavigation _miMenu;
    public bool _isSelected;
    public ButtomType _thisType;
    
    void Start()
    {
        _selector.SetActive(false);
        _label.text = _labelText;
        _miMenu = GetComponentInParent<MenuNavigation>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isSelected)
        {  
            if(_thisType == ButtomType.NavButtom)
            {
                ChangeMenu();
            }
            if (_thisType == ButtomType.LoadStage)
            {
                LoadManager.Instance.LoadRing();
            }
            if (_thisType == ButtomType.LoadMenu)
            {
                LoadManager.Instance.LoadMenu();
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
        _miMenu.Menu();
    }
}
public enum ButtomType
{
    NavButtom, LoadStage ,LoadMenu
}
