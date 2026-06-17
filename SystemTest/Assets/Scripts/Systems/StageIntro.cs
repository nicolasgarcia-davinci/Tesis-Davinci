using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageIntro : MonoBehaviour
{
    public TextMeshProUGUI lab;
    public Color Transparency;
    public bool toTranparent;
    public float BlinkInterval;
    public float transparancyRate;
    void Start()
    {
        StartCoroutine(TextFlash());
    }

    void Update()
    {
        if(toTranparent)
        {
            Transparency.a -= transparancyRate;
            lab.color = Transparency;
        }
        if(!toTranparent)
        {
            Transparency.a += transparancyRate;
            lab.color = Transparency;
        }
    }
   public IEnumerator TextFlash()
   {
       toTranparent = true;
       yield return new WaitForSeconds(BlinkInterval);
       toTranparent = false;
       yield return new WaitForSeconds(BlinkInterval);
       StartCoroutine(TextFlash());
   }
}
