using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;

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
    public void SaveLvl()
    {
        PlayerPrefs.SetInt("_BattleLevel", LifeTraker.Instance.BtlLvl);

    }
    public void LoadLvl()
    {
        LifeTraker.Instance.BtlLvl = PlayerPrefs.GetInt("_BattleLevel", 1);
    }
    public void SaveTimer()
    {
        PlayerPrefs.SetFloat("_RoundTimer", RoundTimer.instance._timer);
    }
    public void LoadTimer()
    {
        RoundTimer.instance._timer = PlayerPrefs.GetFloat("_RoundTimer", 30);
    }
}
