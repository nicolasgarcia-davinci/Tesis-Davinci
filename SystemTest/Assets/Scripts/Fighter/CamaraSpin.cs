using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSpin : MonoBehaviour
{
    public static CamaraSpin Instance;

    public float SpinDuration;
    public float SpinPower;
    public GameObject Camara;

    public bool _spinLeft;
    public bool _spinRight;
    public bool _spinUp;
    public bool _spinDown;

    private void Awake()
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
    void Update()
    {
        if(_spinLeft)
            Camara.transform.Rotate(new Vector3(0, SpinPower * Time.deltaTime, 0));
        if (_spinRight)
            Camara.transform.Rotate(new Vector3(0, -SpinPower * Time.deltaTime, 0));
        if(_spinUp)
            Camara.transform.Rotate(new Vector3(SpinPower * Time.deltaTime, 0 , 0));
        if (_spinDown)
            Camara.transform.Rotate(new Vector3(-SpinPower * Time.deltaTime, 0 , 0));
    }
    public void UpSpin()
    {
        StartCoroutine(UpSide());
    }
    public void RightSpin()
    {
        StartCoroutine(RightSide());
    }
    public void LeftSpin()
    {
        StartCoroutine(LeftSide());
    }
    public void DownSpin()
    {
        StartCoroutine(DownSide());
    }

    public IEnumerator LeftSide()
    {
        _spinLeft = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinLeft = false;
        _spinRight = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinRight = false;
    }
    public IEnumerator RightSide()
    {
        _spinRight = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinRight = false;
        _spinLeft = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinLeft = false;
    }
    public IEnumerator UpSide()
    {
        _spinUp = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinUp = false;
        _spinDown = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinDown = false;
    }
    public IEnumerator DownSide()
    {
        _spinDown = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinDown = false;
        _spinUp = true;
        yield return new WaitForSeconds(SpinDuration);
        _spinUp = false;
    }
}
