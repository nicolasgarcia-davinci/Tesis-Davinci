using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreView : MonoBehaviour
{
    public int _timer;
    public GameObject _game;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer==0)
        {
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
