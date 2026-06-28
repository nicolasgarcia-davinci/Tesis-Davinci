using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCam : MonoBehaviour
{

    public Animator _animator;

    public GameObject Fight;
    public GameObject FightCurtain;
    public GameObject Repair;
    public GameObject KO;
    public GameObject Controls;

    public JumboTron BossScreen;
    
    
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

    public void PlayerBackToFight()
    {
        _animator.Play("PlayerBackToFight");
    }
    public void EnemyBackToFight()
    {
        _animator.Play("EnemyBackToFight");
    }
    public void GoToRound2()
    {
        StageState.Instance.ResetFight = false;
        _animator.Play("Round 2");
    }
    public void GoToRepairCam()
    {
        StageState.Instance.ResetRepair = true;
        Controls.SetActive(false);
        _animator.Play("MoveToRepair");
    }

    public void GoToEndgameCam()
    {
        _animator.Play("EndGame");
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
        if(LifeTraker.Instance.IsEnemy)
        {
            _animator.Play("MoveToEnemyKo");
            StageState.Instance.ResetKO = true;
            LoadManager.Instance.LoadKO();
        } else
        {
            _animator.Play("MoveToPlayer Ko");
            StageState.Instance.ResetKO = true;
            LoadManager.Instance.LoadKO();
        }
    }
    public void GoToEnemyKOCam()
    {
        _animator.Play("MoveToEnemyKo");
        LoadManager.Instance.LoadKO();
        StageState.Instance.ResetKO = true;
    }

    public void TurnOffFight()
    {
        Controls.SetActive(false);
        Fight.SetActive(false);
    }
    public void TurnOffKO()
    {
        KO.SetActive(false);
    }
    public void TurnOffRepair()
    {
        StageState.Instance.ResetFight = false;
        Repair.SetActive(false);
    }
    public void TurnOnFight()
    {
        StageState.Instance.ResetFight = true;
        Fight.SetActive(true);
    }
    public void TurnOnRound()
    {
        StageState.Instance.RoundEnter = true;
        Fight.SetActive(true);
        if (FightCurtain != null) FightCurtain.SetActive(true);
        else BossScreen.CalllText();
    }
    public void TurnOnKO()
    {
        KO.SetActive(true);
    }
    public void TurnOnRepair()
    {
        Repair.SetActive(true);
    }
    public void StopCam()
    {
        _animator.speed = 0;
    }
    public void ResumeCam()
    {
        _animator.speed = 1;
    }

}
