using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image lifeBar;
    public DownedFigher _body;
    public Material _bodyMaterial;


    public void UpdateLife(float current, float max)
    {
        lifeBar.fillAmount = current / max;
        _bodyMaterial.SetFloat("_Actual_Life", lifeBar.fillAmount);
    }
    
    public void Heal()
    {
        _body.HealPart(this);
    }
}
