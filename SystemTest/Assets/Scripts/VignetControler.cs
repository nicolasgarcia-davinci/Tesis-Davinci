using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetControler : MonoBehaviour
{
    public Material vignete;
    public Color player;
    public Color enemy;
    public Color off;

    public static VignetControler Instance;

    public void Awake()
    {
        if(Instance == null)
        Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        vignete.SetColor("_Color", off);
    }

    public void ActivatePlayerColor()
    {
        vignete.SetColor("_Color", player);
    }
    public void ActivateEnemyColor()
    {
        vignete.SetColor("_Color", enemy);
    }
    public void DeActivate()
    {
        vignete.SetColor("_Color", off);
    }
}
