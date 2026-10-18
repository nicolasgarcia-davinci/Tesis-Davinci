using UnityEngine;

public class StartGameBot : MonoBehaviour
{
    public Animator Animator;
    public AudioSource Audio;
    public AudioClip Clang;
    public GameObject[] hits;

    public void Ring()
    {
        Animator.Play("PunchRight");
    }
    public void Stop()
    {
        Animator.speed = 0;
    }
    public void Hit()
    {
        Audio.PlayOneShot(Clang);
        Animator.Play("GetHit Right");
        foreach (var hit in hits)
        {
            hit.gameObject.SetActive(true);
        }
    }
}
