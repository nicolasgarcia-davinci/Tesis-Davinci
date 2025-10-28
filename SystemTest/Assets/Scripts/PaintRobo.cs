using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRobo : MonoBehaviour
{
    public SkinnedMeshRenderer body;
    // Start is called before the first frame update
    void Start()
    {
        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColorChange()
    {
        body.material.SetColor("_Color1", ColorCordination.Instance.color1);
        body.material.SetColor("_Color2", ColorCordination.Instance.color2);
        body.material.SetFloat("_Transparencia", 1f);
    }
}
