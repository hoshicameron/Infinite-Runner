using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private GameObject damageCollider;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDead()
    {
        AudioManager.Instance.Play_EnemyDeathSound();
        animator.SetTrigger(TagManager.DeadAnimationParameter);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(TagManager.AttackTriggerAnimationParameter);
    }


    private void ActiveDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    private void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }

    private void DisableGameobject()
    {
        gameObject.SetActive(false);
    }
}
