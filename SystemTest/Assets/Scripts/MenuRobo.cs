using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRobo : MonoBehaviour
{
    public GameObject RBoxer;
    public GameObject RDrill;
    
    public void ActivateBoxer()
    {
        RDrill.gameObject.SetActive(false);
        RBoxer.gameObject.SetActive(true);
    }
    public void ActivateDrill()
    {
        RDrill.gameObject.SetActive(true);
        RBoxer.gameObject.SetActive(false);
    }
}
