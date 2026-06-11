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
    public GloveAnim _selector;
    public float activationdelay;
    public bool _isSelected;
    public bool _Activated;
    public AudioSource Sound;
    public AudioClip ActSound;

    public Color color;
    public Image colorCatalog;

    void Start()
    {
        colorCatalog.color = color;
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
        _selector.gameObject.SetActive(true);
        _isSelected = true;
        if (_thisType == PainterOption.Color1)
        {
            if (IsRArm)
            {
                ColorCordination.Instance.Rightcolor1 = color;
                ColorCordination.Instance.Fullcolor1[0] = color;
                RArmToPaint.SetColor();
            }

            if (IsLArm)
            {
                ColorCordination.Instance.Leftcolor1 = color;
                ColorCordination.Instance.Fullcolor1[1] = color;
                LArmToPaint.SetColor();
            }
            
            if (IsLeg)
            {
                ColorCordination.Instance.Legscolor1 = color;
                ColorCordination.Instance.Fullcolor1[2] = color;
                LegToPaint.SetColor();
            }
            
            if (IsHead)
            {
                ColorCordination.Instance.Headcolor1 = color;
                ColorCordination.Instance.Fullcolor1[3] = color;
                HeadToPaint.SetColor();
            } 

            if (IsChest)
            {
                ColorCordination.Instance.Chestcolor1 = color;
                ColorCordination.Instance.Fullcolor1[4] = color;
                ChestToPaint.SetColor();
            }
        }
        if (_thisType == PainterOption.Color2)
        {
            if (IsRArm)
            {
                ColorCordination.Instance.Rightcolor2 = color;
                ColorCordination.Instance.Fullcolor2[0] = color;
                RArmToPaint.SetColor();
            }

            if (IsLArm)
            {
                ColorCordination.Instance.Leftcolor2 = color;
                ColorCordination.Instance.Fullcolor2[1] = color;
                LArmToPaint.SetColor();
            }

            if (LegToPaint)
            {
                ColorCordination.Instance.Legscolor2 = color;
                ColorCordination.Instance.Fullcolor2[2] = color;
                LegToPaint.SetColor();
            }

            if (HeadToPaint)
            {
                ColorCordination.Instance.Headcolor2 = color;
                ColorCordination.Instance.Fullcolor2[3] = color;
                HeadToPaint.SetColor();
            }

            if (ChestToPaint)
            {
                ColorCordination.Instance.Chestcolor2 = color;
                ColorCordination.Instance.Fullcolor2[4] = color;
                ChestToPaint.SetColor();
            }
        }
    }
    public void DeSelect()
    {
        _selector.gameObject.SetActive(false);
        _isSelected = false;
        IsRArm = false;
        IsLArm = false;
        IsLeg = false;
        IsHead = false;
        IsChest = false;
    }
    public IEnumerator Action()
    {
        _selector.Hit();
        Sound.PlayOneShot(ActSound);

        yield return new WaitForSeconds(activationdelay);

        _selector.gameObject.SetActive(false);

        if (_thisType == PainterOption.Color1)
        {
            _Activated = false;
            painter.nextColumn();
        }
        if (_thisType == PainterOption.Color2)
        {
            _Activated = false;
            painter.End();
        }
        if (_thisType == PainterOption.Pass)
        {
            _Activated = false;
            painter.nextColumn();
        }
        if (_thisType == PainterOption.End)
        {
            _Activated = false;
            painter.End();
        }
    }
}
public enum PainterOption
{
    Color1, Color2, Pass, End
}
