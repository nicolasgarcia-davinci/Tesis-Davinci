using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void LoadRing()
    {
        VignetControler.Instance.DeActivate();
        LifeTraker.Instance.ResetTimer = true;
        LifeTraker.Instance.Reset();
        DataSaver.Instance.LoadLvl();
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadGym()
    {
        //check
        VignetControler.Instance.DeActivate();
        LifeTraker.Instance.ResetTimer = true;
        LifeTraker.Instance.Reset();
        DataSaver.Instance.LoadLvl();
        SceneManager.LoadSceneAsync(4);
    }
    public void LoadGymKo()
    {
        //check
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        DataSaver.Instance.SaveLvl();
        DataSaver.Instance.LoadLvl();
        SceneManager.LoadSceneAsync(5);
    }
    public void LoadGymRest()
    {
        //check
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        DataSaver.Instance.LoadLvl();
        DataSaver.Instance.SaveLvl();
        SceneManager.LoadSceneAsync(6);
    }
    public void Round2Gym()
    {
        DataSaver.Instance.LoadTimer();
        SceneManager.LoadSceneAsync(4);
    }
    public void Round2()
    {
        VignetControler.Instance.DeActivate();
        DataSaver.Instance.LoadTimer();
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadMenu()
    {
        DataSaver.Instance.LoadLvl();
        DataSaver.Instance.SaveLvl();
        SceneManager.LoadSceneAsync(0);
    }
    public void Reaload()
    {
        //SceneManager.LoadSceneAsync();
    }

    public void LoadIntermision()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        DataSaver.Instance.LoadLvl();
        DataSaver.Instance.SaveLvl();
        SceneManager.LoadSceneAsync(3);
    }

    public void LoadKO()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        DataSaver.Instance.SaveLvl();
        DataSaver.Instance.LoadLvl();
        SceneManager.LoadSceneAsync(2);
    }
}
