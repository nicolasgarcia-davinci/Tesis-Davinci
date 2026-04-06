using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDArrow : MonoBehaviour
{
    public bool IsUp;
    public bool IsDown;
    public bool IsRight;
    public bool IsLeft;

    public Color Correct;
    public Color Reset;

    public RawImage body;
    void Start()
    {
        //float direction = Random.Range(0, 4);
        //if (direction == 0 && direction<1) IsUp = true;
        //if (direction == 1 && direction<2) IsDown = true;
        //if (direction == 2 && direction<3) IsRight = true;
        //if (direction == 3 && direction<=4) IsLeft = true;
        //
        //if(IsUp) body.rectTransform.rotation = Quaternion.AngleAxis(0,new Vector3(0,0,1));
        //if(IsDown) body.rectTransform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
        //if (IsRight) body.rectTransform.rotation = Quaternion.AngleAxis(270, new Vector3(0, 0, 1));
        //if (IsLeft) body.rectTransform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
    }

    public void Randomize()
    {
        float direction = Random.Range(0, 4);
        if (direction == 0 && direction < 1) IsUp = true;
        if (direction == 1 && direction < 2) IsDown = true;
        if (direction == 2 && direction < 3) IsRight = true;
        if (direction == 3 && direction <= 4) IsLeft = true;

        if (IsUp) body.rectTransform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
        if (IsDown) body.rectTransform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
        if (IsRight) body.rectTransform.rotation = Quaternion.AngleAxis(270, new Vector3(0, 0, 1));
        if (IsLeft) body.rectTransform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
    }

    public void ChangeToCorrect()
    {
        body.color=Correct;
    }
    public void ChangeToReset()
    {
        body.color=Reset;
    }

    void Update()
    {
        
    }
}
