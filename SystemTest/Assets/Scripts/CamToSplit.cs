using System;
using System.Collections;
using UnityEngine;

public class CamToSplit : MonoBehaviour
{
    public Camera MainCam;
    public Camera SplitCam;
    public float Cam2XToSplit;

    public float Cam2XToGarage;

    public GameObject Selector;
    public GameObject GarageMenu;
    public Transform oldcampos;
    public Transform newcampos;


    public float panDegree;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SplitIt()
    {
        SplitCam.gameObject.SetActive(true);
        //StartCoroutine(Spliting());
        MainCam.rect = new Rect(-0.5f, 0, 1, 1);
        MainCam.transform.position= newcampos.position;
        SplitCam.rect = new Rect(0.5f, 0, 1, 1);
        Selector.SetActive(true);
    }
    public IEnumerator Spliting()
    {
        SplitCam.rect = new Rect(1 - panDegree*Time.deltaTime, 0, 1, 1);
        MainCam.rect = new Rect(MainCam.rect.x - panDegree*Time.deltaTime, 0, 1, 1);
        if (SplitCam.rect.x > Cam2XToSplit)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(Spliting());
        }
        else
        {
            MainCam.rect = new Rect(-0.5f, 0, 1, 1);
            SplitCam.rect = new Rect(0.5f, 0, 1, 1);
        }
    }

    public void BackToGarage()
    {
        //StartCoroutine(Merge());
        Selector.SetActive(false);
        SplitCam.gameObject.SetActive(false);
        GarageMenu.SetActive(true);
        MainCam.rect = new Rect(0, 0, 1, 1);
        MainCam.transform.position = oldcampos.position;
        SplitCam.rect = new Rect(1, 0, 1, 1);
    }
    public IEnumerator Merge()
    {
        SplitCam.rect = new Rect(1 + panDegree * Time.deltaTime, 0, 1, 1);
        if (SplitCam.rect.x < Cam2XToSplit)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(Merge());
        }
        else
        {
            MainCam.rect = new Rect(0, 0, 1, 1);
            SplitCam.rect = new Rect(1, 0, 1, 1);
            SplitCam.gameObject.SetActive(false);
        }
    }
}
