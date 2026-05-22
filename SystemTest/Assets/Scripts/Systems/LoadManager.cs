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
        LifeTraker.Instance.Reset();
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadGym()
    {
        LifeTraker.Instance.ResetTimer = true;
        LifeTraker.Instance.Reset();
        SceneManager.LoadSceneAsync(2);
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
            LoadRing();
            //LoadGym();
        }
    }

    public void LoadIntermision()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
    }

    public void LoadKO()
    {
        DataSaver.Instance.SaveTimer();
        LifeTraker.Instance.UpdateLife();
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
            LoadRing();
            //LoadGym();
        }
    }

    public void Garage()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void ENDGAME()
    { SceneManager.LoadSceneAsync(4);}
}
