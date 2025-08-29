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
        }
        else
        {
            Destroy(this);
        }
    }
    public void LoadRing()
    {
        DataSaver.Instance.LoadLifes();
        SceneManager.LoadSceneAsync(1);
        DataSaver.Instance.SaveLife();
    }
    public void LoadMenu()
    {
        DataSaver.Instance.LoadLifes();
        SceneManager.LoadSceneAsync(0);
        DataSaver.Instance.SaveLife();
    }

    public void LoadStatus()
    {
        DataSaver.Instance.LoadLifes();
        SceneManager.LoadSceneAsync(1);
        DataSaver.Instance.SaveLife();
    }

    public void LoadDown()
    {
        DataSaver.Instance.LoadLifes();
        SceneManager.LoadSceneAsync(1);
        DataSaver.Instance.SaveLife();
    }
}
