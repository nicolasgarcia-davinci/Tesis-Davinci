using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGroup : MonoBehaviour
{
    public Arrow[] Secuence;
    public int index = 0;
    public bool perfect = true;
    public LifeBar partlifeIndicator;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Arrow flecha in Secuence)
        { 
            if (flecha.IsLeft) flecha.transform.Rotate(0,0,90);
            if (flecha.IsRight) flecha.transform.Rotate(0,0,-90);
            if (flecha.IsDown) flecha.transform.Rotate(0,0,180);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
