using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreView : MonoBehaviour
{
    public int _timer;
    public GameObject _game;
    public bool HasToReset;
    // Start is called before the first frame update
    void Start()
    {  

    }
    

    // Update is called once per frame
    void Update()
    {
        if(_timer==0)
        {
            StopAllCoroutines();
            _timer = 3;
            HasToReset=true;
            _game.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public IEnumerator Clock()
    {
        _timer--;
        yield return new WaitForSeconds(1);
        StartCoroutine(Clock());
    }
}
