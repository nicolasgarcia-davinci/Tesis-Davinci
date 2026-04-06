using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitTo : MonoBehaviour
{
    public GameObject TurnOff;
    public GameObject TurnOn;

    public void ChangeState()
    {
      TurnOff.SetActive(false);
      TurnOn.SetActive(true);
      this.gameObject.SetActive(false);
    }
}
