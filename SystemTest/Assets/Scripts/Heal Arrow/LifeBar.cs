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


    public void UpdateLife(float current, float max)
    {
        lifeBar.fillAmount = currentHealth / maxHealth;
        currentHealth = current;
        maxHealth = max;
    }
    
    public void Heal()
    {
        _body.HealPart(this);
    }
}
