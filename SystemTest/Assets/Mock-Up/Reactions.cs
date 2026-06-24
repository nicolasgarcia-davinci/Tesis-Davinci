using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactions : MonoBehaviour
{
    public AudioSource Public;
    public AudioClip Cheers, Boos;
    public Material CrowdMat;
    public float ChantDuration;
    
    public void Celebrate()
    {
        Public.PlayOneShot(Cheers);
        StartCoroutine(AudienceMov());
    }
    public void Hakle()
    {
        Public.PlayOneShot(Boos);
        StartCoroutine(AudienceMov());
    }
    public IEnumerator AudienceMov()
    {
        CrowdMat.SetFloat("_Crowd_Speed", 60);
        yield return new WaitForSeconds(ChantDuration);
        CrowdMat.SetFloat("_Crowd_Speed", 15);
    }
}
