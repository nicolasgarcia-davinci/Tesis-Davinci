using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ButtomAction : MonoBehaviour
{
    [SerializeField] string _labelText;
    [SerializeField] TextMeshProUGUI _label;
    public Animator _pulsControl;
    public Animator _Console;
    public ConsoleMenu _MenuConsole;
    public MenuNavigation _miMenu;
    public MenuRobo _Display;
    public float activationdelay;
    [Range(.02f, 1f)] public float Volume;
    [Range(.02f, 0.10f)] public float VolumeVariant;
    public Slider VolumeSlider;
    public bool _isSelected;
    public bool _Activated;
    public int _targetID;
    public AudioSource Sound;
    public AudioClip ActSound;
    public GameObject Asambley;
    public int newDif;
    public ButtomType _thisType;

    
    public void Start()
    {
        if(_label!=null) _label.text = _labelText;

        if (VolumeSlider!=null)
        {
            if (_thisType == ButtomType.MVolume) Volume = StageSound.instance.InicialMasterAudio;
            if (_thisType == ButtomType.SVolume) Volume = StageSound.instance.InicialMusicAudio;
            if (_thisType == ButtomType.EVolume) Volume = StageSound.instance.InicialSoundAudio;
            VolumeSlider.value = Volume;
        }

        _miMenu = GetComponentInParent<MenuNavigation>();
    }

    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isSelected && !_Activated)
        {  
            _Activated = true;
            StartCoroutine(Action());
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && _isSelected)
        {
            if (_thisType == ButtomType.EVolume || _thisType == ButtomType.SVolume || _thisType == ButtomType.MVolume)
            {
                Volume-= VolumeVariant;
                if (Volume <= 0) Volume = 0.01f;
                VolumeSlider.value = Volume;
                if (_thisType == ButtomType.MVolume) StageSound.instance.GameMixer.SetFloat("MasterVolume", Mathf.Log10(Volume) * 20);
                if(_thisType == ButtomType.SVolume) StageSound.instance.GameMixer.SetFloat("MusicVolume", Mathf.Log10(Volume) * 20);
                if(_thisType == ButtomType.EVolume) StageSound.instance.GameMixer.SetFloat("SoundsVolume", Mathf.Log10(Volume) * 20);

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _isSelected)
        {
            if (_thisType == ButtomType.EVolume || _thisType == ButtomType.SVolume || _thisType == ButtomType.MVolume)
            {
                Volume += VolumeVariant;
                if (Volume > 1) Volume = 1;
                VolumeSlider.value = Volume;
                if (_thisType == ButtomType.MVolume) StageSound.instance.GameMixer.SetFloat("MasterVolume", Mathf.Log10(Volume) * 20);
                if (_thisType == ButtomType.SVolume) StageSound.instance.GameMixer.SetFloat("MusicVolume", Mathf.Log10(Volume) * 20);
                if (_thisType == ButtomType.EVolume) StageSound.instance.GameMixer.SetFloat("SoundsVolume", Mathf.Log10(Volume) * 20);
            }
        }
    }

    public IEnumerator Action()
    {
        _pulsControl.SetTrigger("Click");
        if (_Console != null) _Console.SetTrigger("ClickSpace");
        Sound.PlayOneShot(ActSound);

        yield return new WaitForSeconds(activationdelay);

        if (_thisType == ButtomType.NavButtom)
        {
            _Activated = false;
            _isSelected = false;
            ChangeMenu();
        }

        if (_thisType == ButtomType.Resume)
        {
            _Activated = false;
            FightControler.Instance.UnPause();
        }

        if (_thisType == ButtomType.LoadStage) LoadManager.Instance.Garage();

        if (_thisType == ButtomType.LoadMenu && LifeTraker.Instance.IsEnemy)
        {
            LifeTraker.Instance.Dificulty = newDif;
            LoadManager.Instance.LoadMenu();
        }else if (_thisType == ButtomType.LoadMenu && !LifeTraker.Instance.IsEnemy) LoadManager.Instance.LoadMenu();

        if (_thisType == ButtomType.Quit)
        {
            LifeTraker.Instance.Dificulty = newDif;
            Application.Quit();
        } 

        if (_thisType == ButtomType.Return)
        {
            _Activated = false;
            ChangeMenu();
        }

        if (_thisType == ButtomType.Continue)
        {
                LifeTraker.Instance.Dificulty = newDif;
            if(newDif==2 && !LifeTraker.Instance.HasUnlockDrill) LifeTraker.Instance.UnlockDrill=true;
            if(newDif==3 && !LifeTraker.Instance.HasUnlockClaw) LifeTraker.Instance.UnlockClaw=true;
                LoadManager.Instance.Garage();
        }

        if (_thisType == ButtomType.NextLvl)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.Garage();
        }

        if (_thisType == ButtomType.Play) LoadManager.Instance.LoadEnter();

        if (_thisType==ButtomType.Asambley)
        {
            _isSelected = false;
            _Activated = false;
            Asambley.SetActive(true);
            _miMenu.gameObject.SetActive(false);
            _MenuConsole.SetExit();
        }
    }

    public virtual void Select()
    {
        _pulsControl.SetBool("Selected", true);
        _isSelected = true;
    }
    public void DeSelect()
    {
        _pulsControl.SetBool("Selected", false);
        _isSelected = false;
    }

    public void ChangeMenu()
    {
        _miMenu.Menu(_targetID);
    }
}
public enum ButtomType
{
    NavButtom, LoadStage, LoadMenu, Color1, Color2, Quit, Return, Continue, NextLvl, Resume, MVolume, EVolume, SVolume, Play, Asambley
}
