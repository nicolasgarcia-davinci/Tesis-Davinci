using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartColor : MonoBehaviour
{
    public Arm RArmToPaint;
    public bool IsRArm;
    public Arm LArmToPaint;
    public bool IsLArm;
    public Leg LegToPaint;
    public bool IsLeg;
    public Head HeadToPaint;
    public bool IsHead;
    public Chest ChestToPaint;
    public bool IsChest;
    public PartPainter painter;
    public PainterOption _thisType;

    public float activationdelay;
    public bool _isSelected;
    public bool _Activated;

    public Animator _pulsControl;
    public AudioSource Sound;
    public AudioClip ActSound;
    public ConsoleControls controls;
    public PartSelector selector;

    public Color color;
    public Image colorCatalog;
    public Image Back;

    void Start()
    {
        colorCatalog.color = color;
        Back.color = color;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isSelected && !_Activated)
        {
            _Activated = true;
            StartCoroutine(Action());
        }
    }
    public void Select()
    {
        _pulsControl.SetBool("Selected", true);
        _isSelected = true;
        if (_thisType == PainterOption.Color1)
        {
            if (IsRArm)
            {
                ColorCordination.Instance.Rightcolor1 = color;
                RArmToPaint.SetColor();
            }

            if (IsLArm)
            {
                ColorCordination.Instance.Leftcolor1 = color;
                LArmToPaint.SetColor();
            }
            
            if (IsLeg)
            {
                ColorCordination.Instance.Legscolor1 = color;
                LegToPaint.SetColor();
            }
            
            if (IsHead)
            {
                ColorCordination.Instance.Headcolor1 = color;
                HeadToPaint.SetColor();
            } 

            if (IsChest)
            {
                ColorCordination.Instance.Chestcolor1 = color;
                ChestToPaint.SetColor();
            }
        }
        if (_thisType == PainterOption.Color2)
        {
            if (IsRArm)
            {
                ColorCordination.Instance.Rightcolor2 = color;
                RArmToPaint.SetColor();
            }

            if (IsLArm)
            {
                ColorCordination.Instance.Leftcolor2 = color;
                LArmToPaint.SetColor();
            }

            if (IsLeg)
            {
                ColorCordination.Instance.Legscolor2 = color;
                LegToPaint.SetColor();
            }

            if (IsHead)
            {
                ColorCordination.Instance.Headcolor2 = color;
                HeadToPaint.SetColor();
            }

            if (IsChest)
            {
                ColorCordination.Instance.Chestcolor2 = color;
                ChestToPaint.SetColor();
            }
        }
    }
    public void DeSelect()
    {
        _pulsControl.SetBool("Selected", false);
        _isSelected = false;
    }
    public void Clean()
    {
        IsRArm = false;
        IsLArm = false;
        IsLeg = false;
        IsHead = false;
        IsChest = false;
        RArmToPaint = null;
        LArmToPaint = null;
        LegToPaint = null;
        HeadToPaint = null;
        ChestToPaint = null;
    }
    public IEnumerator Action()
    {
        _pulsControl.SetTrigger("Click");
        Sound.PlayOneShot(ActSound);

        yield return new WaitForSeconds(activationdelay);

        if (_thisType == PainterOption.Color1)
        {
            _Activated = false;
            painter.nextColumn();
        }
        if (_thisType == PainterOption.Color2)
        {
            selector.IsOn = true;
            _Activated = false;
            controls.IsColoring = false;
            painter.End();
        }
        if (_thisType == PainterOption.Pass)
        {
            _Activated = false;
            painter.nextColumn();
        }
        if (_thisType == PainterOption.End)
        {
            selector.IsOn = true;
            _Activated = false;
            controls.IsColoring = false;
            painter.End();
        }
    }
}
public enum PainterOption
{
    Color1, Color2, Pass, End
}
