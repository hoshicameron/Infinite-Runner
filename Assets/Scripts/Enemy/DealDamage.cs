using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private bool destroyable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            print("Add Damage to Player");

            if(destroyable)    gameObject.SetActive(false);
        }
    }
}
