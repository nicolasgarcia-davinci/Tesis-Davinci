using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpPlayer : MonoBehaviour
{
    void Update()
    {
        if (!Fallen.Instance._gameOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) Fallen.Instance.CheckLeft();

            if (Input.GetKeyDown(KeyCode.RightArrow)) Fallen.Instance.CheckRight();

            if (Input.GetKeyDown(KeyCode.DownArrow)) Fallen.Instance.CheckDown();

            if (Input.GetKeyDown(KeyCode.UpArrow)) Fallen.Instance.CheckUp();
        }
    }
}
