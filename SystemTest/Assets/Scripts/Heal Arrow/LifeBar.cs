using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public float targetOuch;
    public float EnterHeal;
    public float progIncrement;
    public bool ProgHeal;
    public bool ProgOuch;
    public Image lifeBar;
    public DownedFigher _body;
    public Material _bodyMaterial;


    public void UpdateLife(float current, float max)
    {
        lifeBar.fillAmount = current / max;
        _bodyMaterial.SetFloat("_Actual_Life", lifeBar.fillAmount);
    }
    public void Update()
    {
        if(ProgHeal)
        {
            if(lifeBar.fillAmount < EnterHeal) lifeBar.fillAmount += Time.deltaTime * progIncrement;
            else
            {
                ProgHeal = false;
                _bodyMaterial.SetFloat("_Actual_Life", lifeBar.fillAmount);
            }
        }
        if(ProgOuch)
        {
            if(lifeBar.fillAmount > targetOuch) lifeBar.fillAmount -= Time.deltaTime * progIncrement;
            else ProgOuch = false;
        }
    }

    //public void Heal()
    //{
    //    _body.HealPart(this);
    //}

    public void ProgresiveUpdate(float current, float max)
    {
        targetOuch = current / max;
        ProgOuch = true;
    }
    public void ProgresiveEnter(float current, float max)
    {
        EnterHeal = current / max;
        ProgHeal = true;  
    }
}
