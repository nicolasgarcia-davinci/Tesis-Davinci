using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterRound : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RoundMessage;
    [SerializeField] TMP_FontAsset RoundFont;
    [SerializeField] TMP_FontAsset ReturnFont;
    public int _timer;
    public GameObject _game;
    public RoundTimer RT;
    

    void Start()
    {

    }
    public void Again()
    {
        if (LifeTraker.Instance.ResetTimer)
        {
            RoundMessage.font = RoundFont;
            RoundMessage.text = "Round " + LifeTraker.Instance.RundCounter;
        }
            _timer = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Again();
        }
        if (StageState.Instance.ResetFight)
        {
            Again();
        }
    }

    public void CurtainCall()
    {
        StopAllCoroutines();
        _game.gameObject.SetActive(true);
        RT.LaunchTimer();
        FightControler.Instance.EnterStage();
        this.gameObject.SetActive(false);
    }
    public IEnumerator Clock()
    {
        _timer--;
        yield return new WaitForSeconds(1);
        StartCoroutine(Clock());
    }
}
