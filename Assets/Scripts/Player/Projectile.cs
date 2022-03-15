using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector2.right*speed*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Enemy_TAG))
        {
            other.gameObject.GetComponent<EnemyAnimation>().PlayDead();
            gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag(TagManager.Shredder_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}
