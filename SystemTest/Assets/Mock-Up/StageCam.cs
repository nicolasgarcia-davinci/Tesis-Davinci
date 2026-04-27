using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCam : MonoBehaviour
{
    public Transform FightPos;
    public Transform RepairPos;
    public Transform[] KOPos;
    public float desiredDuration;
    private float _elapsedTime;
    private Transform _startPos;
    private Quaternion _startRot;
    public int Index;

    public Animator _animator;

    public GameObject Fight;
    public GameObject FightCurtain;
    public GameObject Repair;
    public GameObject KO;

    public IntermisionTimer _intermisionTimer;
    
    
    public static StageCam Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GoToFightCamFromKO()
    {
        StageState.Instance.ResetFight = true;
        _animator.Play("MoveToFightFromKO");
    }
    public void GoToFightCamFromRepair()
    {
        StageState.Instance.ResetFight = true;
        _animator.Play("MoveTorFightFromRepair");
    }
    public void GoToRepairCam()
    {
        StageState.Instance.ResetRepair = true;
        _animator.Play("MoveToRepair");
    }

    public void GoToEndgameCam()
    {
        _animator.Play("EndGame");
        //transform.position = FightPos.position;
        //transform.rotation = FightPos.rotation;
    }

    #region Codigo Deprecado
    /*IEnumerator MoveCamera(Transform target)
    {
        _startPos = this.transform;
        _startRot = this.transform.rotation;
    
        _elapsedTime = 0;
    
        while(_elapsedTime < desiredDuration)
        {
            Debug.Log("Entre a la corutina");
            float t = _elapsedTime / desiredDuration;
            t = Mathf.SmoothStep(0,1,t);
    
            transform.position = Vector3.Lerp(_startPos.position, target.position, t);
            transform.rotation = Quaternion.Lerp(_startRot, target.rotation, t);
    
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
    
        Debug.Log("Me movi a la posición correcta");
        transform.position = target.position;
        transform.rotation = target.rotation;
    }*/
    #endregion

    public void GoToKOCam()
    {
        _animator.Play("MoveToKo");
        LoadManager.Instance.LoadKO();
        StageState.Instance.ResetKO = true;
    }
    //public void Spin()
    //{
    //    _animator.Play("KoSpin");
    //}

    public void TurnOffFight()
    {
        Fight.SetActive(false);
    }
    public void TurnOffKO()
    {
        KO.SetActive(false);
    }
    public void TurnOffRepair()
    {
        Repair.SetActive(false);
    }
    public void TurnOnFight()
    {
        FightCurtain.SetActive(true);
    }
    public void TurnOnKO()
    {
        KO.SetActive(true);
        //Spin();
    }
    public void TurnOnRepair()
    {
        Repair.SetActive(true);
    }
}
