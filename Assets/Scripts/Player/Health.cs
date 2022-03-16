using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            other.GetComponentInParent<PlayerHealth>().IncreaseHealth();

            AudioManager.Instance.Play_PlayerCollectSound();

            gameObject.SetActive(false);
        }
    }
}
