using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DDManager : MonoBehaviour
{
    public FallingArrow[] DDPanels;

    public bool Set;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Set)
        {
            SpawnArrow();
            Set = true;
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsRight) panel.Correct();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsLeft) panel.Correct();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsUp) panel.Correct();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (var panel in DDPanels)
                if (panel.CanBeHit && panel.IsDown) panel.Correct();
        }
    }

    public void SpawnArrow()
    {
        float Rnum = Random.Range(0, 100);
        if (Rnum <= 25) DDPanels[0].Fall();
        if (Rnum <= 50 && Rnum > 25) DDPanels[1].Fall();
        if (Rnum <= 75 && Rnum > 50) DDPanels[2].Fall();
        if (Rnum <= 100 && Rnum > 75) DDPanels[3].Fall();
    }
}
