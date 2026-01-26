using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageIntro : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage2;
    public RawImage StartLabel;
    public Color Transparency;
    public bool toTranparent;
    public float BlinkInterval;
    public float transparancyRate;
    void Start()
    {
        StartCoroutine(TextFlash());
        if (LifeTraker.Instance.Dificulty==1)
        {
            Stage1.gameObject.SetActive(true);
        }else if(LifeTraker.Instance.Dificulty==2)
        {
            Stage2.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadManager.Instance.ToLVL();
        }
        if(toTranparent)
        {
            Transparency.a -= transparancyRate;
            StartLabel.color = Transparency; 
        }
        if(!toTranparent)
        {
            Transparency.a += transparancyRate;
            StartLabel.color = Transparency;
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
