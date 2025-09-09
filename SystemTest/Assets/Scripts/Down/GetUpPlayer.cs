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

            if (Input.GetKeyDown(KeyCode.RightArrow)) Fallen.Instance.Checkright();
        }
    }
}
