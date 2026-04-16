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
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadGym()
    {
        //check
        VignetControler.Instance.DeActivate();
        LifeTraker.Instance.ResetTimer = true;
        LifeTraker.Instance.Reset();
        SceneManager.LoadSceneAsync(2);
    }
    //public void LoadGymKo()
    //{
    //    //check
    //    DataSaver.Instance.SaveTimer();
    //    LifeTraker.Instance.UpdateLife();
    //    SceneManager.LoadSceneAsync(5);
    //}
    //public void LoadGymRest()
    //{
    //    //check
    //    DataSaver.Instance.SaveTimer();
    //    LifeTraker.Instance.UpdateLife();
    //    SceneManager.LoadSceneAsync(6);
    //}
    //public void Round2Gym()
    //{
    //    VignetControler.Instance.DeActivate();
    //    DataSaver.Instance.LoadTimer();
    //    Debug.Log("sasa");
    //    SceneManager.LoadSceneAsync(4);
    //}
    public void Round2()
    {
        VignetControler.Instance.DeActivate();
        //SceneManager.LoadSceneAsync(1);
    }
    public void LoadMenu()
    {
        LifeTraker.Instance.Dificulty = 1;
        SceneManager.LoadSceneAsync(0);
        Pixelation.Instance.HighDefinition();
    }
    public void Reaload()
    {
        if(LifeTraker.Instance.Dificulty == 1)
        {
            LoadRing();
        }
        if (LifeTraker.Instance.Dificulty == 2)
        {
            LoadGym();
        }
    }

    public void LoadIntermision()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        //SceneManager.LoadSceneAsync(3);
    }

    public void LoadKO()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
        //SceneManager.LoadSceneAsync(2);
    }

    public void LoadEnter()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ToLVL()
    {
        if(LifeTraker.Instance.Dificulty == 1)
        {
            LoadRing();
        }
        else if (LifeTraker.Instance.Dificulty == 2)
        {
            LoadGym();
        }
    }

    public void Garage()
    {
        SceneManager.LoadSceneAsync(05);
    }

    public void GameOver()
    {
        VignetControler.Instance.DeActivate();
        //SceneManager.LoadSceneAsync(7);
    }
    public void ENDGAME()
    { SceneManager.LoadSceneAsync(4);}
}
