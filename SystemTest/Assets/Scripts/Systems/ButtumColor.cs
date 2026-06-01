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
            ColorCordination.Instance.color1 = color;
            _Activated = false;
            ChangeMenu();
        }
        if (_thisType == ButtomType.Color2)
        {
            DeSelect();
            ColorCordination.Instance.color2 = color;
            _Activated = false;
            partsToPaint.PaintThem();
            ChangeMenu();
        }
    }
}
