using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtumColor : ButtomAction
{
    public Color color;
    public Image colorCatalog;

    public PartsToPaint partsToPaint;
    public void Awake()
    {
        colorCatalog.color = color;
    }
    public override void Select()
    {
        base.Select();
        if(_thisType == ButtomType.Color1)
        {
            ColorCordination.Instance.Rightcolor1 = color;
            ColorCordination.Instance.Leftcolor1 = color;
            ColorCordination.Instance.Headcolor1 = color;
            ColorCordination.Instance.Legscolor1 = color;
            ColorCordination.Instance.Chestcolor1 = color;
            partsToPaint.PaintThem();
        }
        if (_thisType == ButtomType.Color2)
        {
            ColorCordination.Instance.Rightcolor2 = color;
            ColorCordination.Instance.Leftcolor2 = color;
            ColorCordination.Instance.Headcolor2 = color;
            ColorCordination.Instance.Legscolor2 = color;
            ColorCordination.Instance.Chestcolor2 = color;
            partsToPaint.PaintThem();
        }
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isSelected && !_Activated)
        {
            _Activated = true;
            StartCoroutine(SetColor());
        }
    }
    public IEnumerator SetColor()
    {
        _selector.Hit();

        yield return new WaitForSeconds(activationdelay);

        _selector.gameObject.SetActive(false);

        if (_thisType == ButtomType.Color1)
        {
            DeSelect();
            _Activated = false;
            ChangeMenu();
        }
        if (_thisType == ButtomType.Color2)
        {
            DeSelect();
            _Activated = false;
            ChangeMenu();
        }
    }
}
