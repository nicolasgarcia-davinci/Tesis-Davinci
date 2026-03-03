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
    public GloveAnim _selector;
    public MenuNavigation _miMenu;
    public MenuRobo _Display;
    public float activationdelay;
    [Range(.01f, 1f)] public float Volume;
    public Slider VolumeSlider;
    public bool _isSelected;
    public bool _Activated;
    public int _targetID;
    public AudioSource Sound;
    public AudioClip ActSound;
    public ButtomType _thisType;
    
    public void Start()
    {
        if(_label!=null) _label.text = _labelText;

        if (VolumeSlider!=null)
        {
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

        if(Input.GetKey(KeyCode.LeftArrow) && _isSelected)
        if(Input.GetKeyDown(KeyCode.LeftArrow) && _isSelected)
        {
            if (_thisType == ButtomType.EVolume || _thisType == ButtomType.SVolume || _thisType == ButtomType.MVolume)
            {
                Volume-= 0.01f;
                if (Volume < 0) Volume = 0;
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
                Volume += 0.01f;
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
        _selector.Hit();
        Sound.PlayOneShot(ActSound);

        yield return new WaitForSeconds(activationdelay);

        _selector.gameObject.SetActive(false);

        if (_thisType == ButtomType.NavButtom)
        {
            _Activated = false;
            ChangeMenu();
        }

        if (_thisType == ButtomType.Resume)
        {
            _Activated = false;
            FightControler.Instance.UnPause();
        }

        if (_thisType == ButtomType.LoadStage) LoadManager.Instance.LoadEnter();

        if (_thisType == ButtomType.LoadMenu) LoadManager.Instance.LoadMenu();

        if (_thisType == ButtomType.Quit) Application.Quit();

        if (_thisType == ButtomType.Return)
        {
            _Activated = false;
            ChangeMenu();
        }

        if (_thisType == ButtomType.Continue)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.LoadEnter();
        }

        if (_thisType == ButtomType.NextLvl)
        {
            LifeTraker.Instance.Dificulty = 2;
            LoadManager.Instance.LoadGym();
        }

        if (_thisType == ButtomType.RoboBoxer)
        {
            _Activated = false;
            LifeTraker.Instance.PlayerRobo = RoboType.Boxer;
            _Display.ActivateBoxer();
            ChangeMenu();
        }

        if (_thisType == ButtomType.RoboDrill)
        {
            _Activated = false;
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
    NavButtom, LoadStage, LoadMenu, Color1, Color2, Quit, Return, Continue, NextLvl, RoboBoxer, RoboDrill, Resume, MVolume, EVolume, SVolume 
}
