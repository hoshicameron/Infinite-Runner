using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        enemyAnimation = GetComponentInParent<EnemyAnimation>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            enemyAnimation.PlayAttack();
            AudioManager.Instance.Play_EnemyAttackSound();
        }

    }
}
