using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepairButtom : MonoBehaviour
{
    [SerializeField] string _labelText;
    [SerializeField] TextMeshProUGUI _label;
    [SerializeField] TextMeshProUGUI _percentil;
    public GameObject _selector;
    public HealMenu _HealMenu;
    public float activationdelay;
    public bool _isSelected;
    public bool _Activated;
    public AudioSource Sound;
    public AudioClip ActSound;
    public DownedFigher RepariBot;
    public IntermisionTimer IT;
    public HealPart _thisType;
    public LifeBar _lifebar;

    public void Update()
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
    }
    public void DeSelect()
    {
        _selector.gameObject.SetActive(false);
        _isSelected = false;
    }
    public void Set()
    {
        if (_thisType == HealPart.HealHead && _HealMenu.HealUses > 0)
        {
            _label.text = _labelText;
            _lifebar.UpdateLife(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
            _percentil.text= GetPercentil(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth).ToString()+ "%";
        }
        if (_thisType == HealPart.HealRightArm && _HealMenu.HealUses > 0)
        {
            _label.text = _labelText;
            _lifebar.UpdateLife(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth).ToString() + "%";
        }
        if (_thisType == HealPart.HealLeftArm && _HealMenu.HealUses > 0)
        {
            _label.text = _labelText;
            _lifebar.UpdateLife(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth).ToString() + "%";
        }
        if (_thisType == HealPart.HealLegs && _HealMenu.HealUses > 0)
        {
            _label.text = _labelText;
            _lifebar.UpdateLife(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth).ToString() + "%";
        }
        if (_thisType == HealPart.Pass)
        {
            _label.text = _labelText;
        }
    }
    public void Used()
    {
        _Activated = false;
        _isSelected = false;
    }

    public float GetPercentil(float current, float max)
    {  
        return (current/max)*100; 
    }
    public IEnumerator Action()
    {
        Used();
        Sound.PlayOneShot(ActSound);

        yield return new WaitForSeconds(activationdelay);
        _selector.gameObject.SetActive(false);

        if (_thisType == HealPart.HealHead && _HealMenu.HealUses>0)
        {
            RepariBot.HealMenuPart(0);
            _HealMenu.UseHeal();
            _lifebar.ProgresiveEnter(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pHead, LifeTraker.Instance.maxHeadHealth).ToString() + "%";
        }
        if (_thisType == HealPart.HealRightArm && _HealMenu.HealUses > 0)
        {
            RepariBot.HealMenuPart(1);
            _HealMenu.UseHeal();
            _lifebar.ProgresiveEnter(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pRight, LifeTraker.Instance.maxRarmHealth).ToString() + "%";
        }
        if (_thisType == HealPart.HealLeftArm && _HealMenu.HealUses > 0)
        {
            RepariBot.HealMenuPart(2);
            _HealMenu.UseHeal();
            _lifebar.ProgresiveEnter(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pLeft, LifeTraker.Instance.maxLarmHealth).ToString() + "%";
        }
        if (_thisType == HealPart.HealLegs && _HealMenu.HealUses > 0)
        {
            RepariBot.HealMenuPart(3);
            _HealMenu.UseHeal();
            _lifebar.ProgresiveEnter(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth);
            _percentil.text = GetPercentil(LifeTraker.Instance.pLegs, LifeTraker.Instance.maxLegsHealth).ToString() + "%";
        }
        if (_thisType == HealPart.Pass)
        {
            RepariBot.ExitRepair();
            LifeTraker.Instance.ResetTimer = true;
            StageState.Instance.ResetFight = true;
            StageSound.instance.Mute();
            IT.Stop();
            StageCam.Instance.GoToRound2();
        }
    }
    public enum HealPart
    {
        HealHead, HealLeftArm, HealRightArm, HealLegs, Pass
    }
}
