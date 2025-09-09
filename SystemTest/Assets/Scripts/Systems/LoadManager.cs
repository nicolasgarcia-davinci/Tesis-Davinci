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
        LifeTraker.Instance.ResetTimer = true;
        DataSaver.Instance.LoadLvl();
        SceneManager.LoadSceneAsync(1);
    }
    public void Round2()
    {
        DataSaver.Instance.LoadTimer();
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadMenu()
    {
        DataSaver.Instance.LoadLvl();
        DataSaver.Instance.SaveLvl();
        SceneManager.LoadSceneAsync(0);
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
