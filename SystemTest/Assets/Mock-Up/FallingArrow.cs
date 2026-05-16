using UnityEngine;
using UnityEngine.UI;

public class FallingArrow : MonoBehaviour
{
    public Image Arrow;

    public bool IsRight;
    public bool IsLeft;
    public bool IsUp;
    public bool IsDown; 

    public Animator Animator;

    public DDManager DDManager;

    public bool CanBeHit;
    public bool IsFalling;
    void Start()
    {
        
        if (IsLeft) Arrow.rectTransform.Rotate(0, 0, 180);
        if (IsUp) Arrow.rectTransform.Rotate(0, 0, 90);
        if (IsDown) Arrow.rectTransform.Rotate(0, 0, 270);
    }

    public void PlayerSpeed()
    {
        Animator.speed = 1;
    }
    public void EnemySpeed()
    {
        Animator.speed = 2;
    }

    public void Fall()
    {
        Animator.SetTrigger("InAction");
    }

    public void CallFriend()
    {
        DDManager.SpawnArrow();
        IsNotInRange();
    }

    public void IsInRange()
    {
        CanBeHit = true;
        DDManager.EnemyMess();
    }
    public void IsNotInRange()
    {
        IsFalling = false;
        CanBeHit = false;
        Arrow.color = Color.clear;
    }
    public void Correct()
    {
        Debug.Log("Hit");
        Arrow.color = Color.green;
    }
    public void Wrong()
    {
        Debug.Log("Hit");
        Arrow.color = Color.red;
    }
    public void IsReady()
    {
        Arrow.color = Color.white;
        IsFalling = true;
    }
    public void StopAnim()
    {
        Animator.speed = 0;
    }
}
