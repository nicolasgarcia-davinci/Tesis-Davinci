using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDisplay : MonoBehaviour
{

    public GameObject[] part;
    
    public void DisplayMini(int index)
    {
        foreach(GameObject p in part) { p.SetActive(false); }
        part[index].SetActive(true);
    }
}
