using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCheker : MonoBehaviour
{
    public ArrowGroup[] CollectionsOnScreen;
    public int Index=0;
    public AudioSource Jingle;
    public AudioClip Correct,Wrong;

    public RestAnim player;

    public static InputCheker Instance;

    bool check=false;

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

    // Update is called once per frame
    void Update()
    {
        if(check) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) CheckUp();
        if (Input.GetKeyDown(KeyCode.RightArrow)) CheckRight();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) CheckLeft();
        if (Input.GetKeyDown(KeyCode.DownArrow)) CheckDown();
    }

    public void CheckUp()
    {
        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (Index >= group.Secuence.Length)
            {
                Index = 0;
                group.perfect = true;
            }
            if (!group.perfect)
                continue;
            if (group.Secuence[Index].IsUp && group.perfect)
                group.Secuence[Index].ChangeToCorrect();
            if(Index==0)
                player.RepairUP();
            if (!group.Secuence[Index].IsUp && group.perfect)
            {
                group.Secuence[Index].ChangeToWrong();
                group.perfect = false;
            }
        }
        Index++;
        CheckPerfect();
    }
    public void CheckRight()
    {
        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (Index >= group.Secuence.Length)
            {
                Index = 0;
                group.perfect = true;
            }
            if (!group.perfect)
                continue;
            if (group.Secuence[Index].IsRight && group.perfect)
                group.Secuence[Index].ChangeToCorrect();
            if (Index == 0)
                player.RepairRight();
            if (!group.Secuence[Index].IsRight && group.perfect)
            {
                group.Secuence[Index].ChangeToWrong();
                group.perfect = false;
            }
        }
        Index++;
        CheckPerfect();
    }
    public void CheckLeft()
    {

        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (Index >= group.Secuence.Length)
            {
                Index = 0;
                group.perfect = true;
            }
            if (!group.perfect)
                continue;
            if (group.Secuence[Index].IsLeft && group.perfect)
                group.Secuence[Index].ChangeToCorrect();
            if (Index == 0)
                player.RepairLeft();
            if (!group.Secuence[Index].IsLeft && group.perfect)
            {
                group.Secuence[Index].ChangeToWrong();
                group.perfect = false;
            }
        }
        Index++;
        CheckPerfect();
    }
    public void CheckDown()
    {
        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (Index >= group.Secuence.Length)
            {
                Index = 0;
                group.perfect = true;
            }
            if (!group.perfect)
                continue;
            if (group.Secuence[Index].IsDown && group.perfect)
                group.Secuence[Index].ChangeToCorrect();
            if (Index == 0)
                player.RepairDown();
            if (!group.Secuence[Index].IsDown && group.perfect)
            {
                group.Secuence[Index].ChangeToWrong();
                group.perfect = false;
            }
        }
        Index++;
        CheckPerfect();
    }

    public void CheckPerfect()
    {
        int totalImperfect= 0;
        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (!group.perfect) totalImperfect++;
            if(totalImperfect==4) StartCoroutine(DelayRestar());
        }
        if (Index >= CollectionsOnScreen[0].Secuence.Length)
        {
            StartCoroutine(DelayRestar());
        }
    }
    public IEnumerator DelayRestar()
    {
        check = true;
        yield return new WaitForSeconds(0.5f);
        foreach (ArrowGroup group in CollectionsOnScreen)
        {
            if (group.perfect)
            {
                group.partlifeIndicator.Heal();
                Jingle.PlayOneShot(Correct);
            }
            group.perfect = true;
            foreach (Arrow flecha in group.Secuence)
                flecha.ChangeToNormal();
        }
        player.ResetRepair();
        Index = 0;
        check = false;
    }
}
