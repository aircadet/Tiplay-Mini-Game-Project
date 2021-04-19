using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Playing)
        {
            animator.SetTrigger("Surf");
        }
    }


    public void JumpAnim()
    {
        animator.SetTrigger("Jump");
    }
}
