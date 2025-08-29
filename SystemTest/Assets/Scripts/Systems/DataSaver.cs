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
    public void SaveLife()
    {
        PlayerPrefs.SetFloat("_Max", LifeTraker.Instance.MaxHealt);
        PlayerPrefs.SetFloat("_Head", LifeTraker.Instance.pHead);
        PlayerPrefs.SetFloat("_Right", LifeTraker.Instance.pRight);
        PlayerPrefs.SetFloat("_Left", LifeTraker.Instance.pLeft);
        PlayerPrefs.SetFloat("_Legs", LifeTraker.Instance.pLegs);
        PlayerPrefs.SetFloat("_EnemyHead", LifeTraker.Instance.eHead);
        PlayerPrefs.SetFloat("_EnemyRight", LifeTraker.Instance.eRight);
        PlayerPrefs.SetFloat("_EnemyLeft", LifeTraker.Instance.eLeft);
        PlayerPrefs.SetFloat("_EnemyLegs", LifeTraker.Instance.eLegs);
    }
    public void LoadLifes()
    {
        LifeTraker.Instance.pHead = PlayerPrefs.GetFloat("_Max", 100);
        LifeTraker.Instance.pHead = PlayerPrefs.GetFloat("_Head", 100);
        LifeTraker.Instance.pRight = PlayerPrefs.GetFloat("_Right", 100);
        LifeTraker.Instance.pLeft = PlayerPrefs.GetFloat("_Left", 100);
        LifeTraker.Instance.pLegs = PlayerPrefs.GetFloat("_Legs", 100);
        LifeTraker.Instance.eHead = PlayerPrefs.GetFloat("_EnemyHead", 100);
        LifeTraker.Instance.eRight = PlayerPrefs.GetFloat("_EnemyRight", 100);
        LifeTraker.Instance.eLeft = PlayerPrefs.GetFloat("_EnemyLeft", 100);
        LifeTraker.Instance.eLegs = PlayerPrefs.GetFloat("_EnemyLegs", 100);
        
    }
}
