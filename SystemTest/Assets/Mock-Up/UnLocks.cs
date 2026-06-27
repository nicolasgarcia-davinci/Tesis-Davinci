using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UnLocks : MonoBehaviour
{
    public MenuNavigation Menu;
    public TextMeshProUGUI UnlockMesage;
    public TextMeshProUGUI Instruction;
    public Color Transparency;
    public bool toTranparent;
    public float BlinkInterval;
    public float transparancyRate;
    void Start()
    {
        if (LifeTraker.Instance.UnlockDrill) UnlockMesage.text = "You Have Unlocked the Drill Set";
        if (LifeTraker.Instance.UnlockClaw) UnlockMesage.text = "You Have Unlocked the Claw Set";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Menu.gameObject.SetActive(true);
            Menu.act1();
            LifeTraker.Instance.UnlockClaw=false;
            LifeTraker.Instance.UnlockDrill=false;
            gameObject.SetActive(false);
        }
        if (toTranparent)
        {
            Transparency.a -= transparancyRate;
            Instruction.color = Transparency;
        }
        if (!toTranparent)
        {
            Transparency.a += transparancyRate;
            Instruction.color = Transparency;
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
