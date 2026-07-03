using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    public Animator animator;
    public Arm Right;
    public Arm Left;
    public Leg Down;
    public Head Up;
    public Chest Center;

    public SkinnedMeshRenderer bodyPaint;

    public Color LockColor;

    public int minDif;

    private void Start()
    {
        if (minDif > LifeTraker.Instance.Dificulty) Lock();
    }
    public void Lock()
    {
        bodyPaint.material.color = LockColor;
        foreach (var part in Right.components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", LockColor);
            coloring.material.SetColor("_Color_2", LockColor);
        }
        foreach (var part in Left.components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", LockColor);
            coloring.material.SetColor("_Color_2", LockColor);
        }
        foreach (var part in Down.components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", LockColor);
            coloring.material.SetColor("_Color_2", LockColor);
        }
        foreach (var part in Up.components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", LockColor);
            coloring.material.SetColor("_Color_2", LockColor);
        }
        foreach (var part in Center.components)
        {
            var coloring = part.GetComponent<MeshRenderer>();
            coloring.material.SetColor("_Color_1", LockColor);
            coloring.material.SetColor("_Color_2", LockColor);
        }
    }
}
