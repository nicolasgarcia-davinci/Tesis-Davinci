using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheker : MonoBehaviour
{
    public ArrowGroup[] CollectionsOnScreen;
    public int Index=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            if(!group.Secuence[Index].IsUp && group.perfect)
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
        if (Index >= CollectionsOnScreen[0].Secuence.Length)
        {
            foreach (ArrowGroup group in CollectionsOnScreen)
            {
                if(group.perfect)
                {
                    group.partlifeIndicator.Heal();
                }
                group.perfect = true;
                foreach (Arrow flecha in group.Secuence)
                    flecha.ChangeToNormal();
            }
        }
    }
}
