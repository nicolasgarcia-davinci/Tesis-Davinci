using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCam : MonoBehaviour
{
    public Transform FightPos;
    public Transform RepairPos;
    public Transform[] KOPos;
    public float desiredDuration;
    private float _elapsedTime;
    private Transform _startPos;
    private Quaternion _startRot;
    public int Index;
    
    public static StageCam Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GoToFightCam()
    {
        StartCoroutine(MoveCamera(FightPos));
    }
    public void GoToRepairCam()
    {
        StartCoroutine(MoveCamera(RepairPos));
    }

    IEnumerator MoveCamera(Transform target)
    {
        _startPos = this.transform;
        _startRot = this.transform.rotation;

        while(_elapsedTime < desiredDuration)
        {
            Debug.Log("Entre a la corutina");
            float t = _elapsedTime / desiredDuration;
            t = Mathf.SmoothStep(0,1,t);

            transform.position = Vector3.Lerp(_startPos.position, target.position, t);
            transform.rotation = Quaternion.Lerp(_startRot, target.rotation, t);

            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Me movi a la posición correcta");
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    public void GoToKOCam()
    {
        if(Index>=KOPos.Length)Index = 0;
        StopCoroutine(MoveCamera(KOPos[Index - 1]));
        StartCoroutine(MoveCamera(KOPos[Index]));
        Index++;
    }
}
