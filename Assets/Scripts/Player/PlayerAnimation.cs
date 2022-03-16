using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public event Action shootBullet;


    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayerFromJumpToRunning(bool running)
    {
        animator.SetBool(TagManager.RunningAnimationParameter,running);
    }

    public void PlayJump(float velocityY)
    {
        animator.SetFloat(TagManager.JumpAnimationParameter, velocityY);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(TagManager.AttackAnimationParameter);
    }

    public void PlayJumpAttack()
    {
        animator.SetTrigger(TagManager.JumpAttackAnimationParameter);
    }

    public void PlaySlide()
    {
        animator.SetTrigger(TagManager.SlideAnimationParameter);
    }

    public void PlayDead()
    {
        animator.SetTrigger(TagManager.DeadAnimationParameter);
    }

    public void  ShootBulletTrigger()
    {
        shootBullet?.Invoke();
    }


}
