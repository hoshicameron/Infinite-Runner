using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Tree_TAG) || other.CompareTag(TagManager.Tree1_TAG) ||
            other.CompareTag(TagManager.Tree2_TAG) || other.CompareTag(TagManager.Cloud1_TAG) ||
            other.CompareTag(TagManager.Cloud2_TAG) || other.CompareTag(TagManager.Ground_TAG))
        {
            other.gameObject.SetActive(false);
        }
    }
}
