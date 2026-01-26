using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksControler : MonoBehaviour
{
    public ParticleSystem FireWork;
    public Color[] colors;
    public float ChangeInterval;
    public float StartInterval;
    public float Timer;
    public bool hasStarted;

    void Start()
    {
        StartInterval = UnityEngine.Random.Range(0f, 1f);
    }

    public IEnumerator ChangeColor()
    {
        int thiscolor;
        thiscolor = UnityEngine.Random.Range(0, colors.Length);
        FireWork.startColor = colors[thiscolor];
        yield return new WaitForSeconds(ChangeInterval);
        StartCoroutine(ChangeColor());
    }

    void Update()
    {
        Timer += 1 * Time.deltaTime;
        if (Timer > StartInterval&& !hasStarted)
        {
            hasStarted = true;
            FireWork.Play();
            StartCoroutine(ChangeColor());
        }
    }
}
