using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    [SerializeField] private string bgTag=string.Empty;

    private GameObject[] backgrounds=null;
    private float highestXPosition=0;
    private float offsetValue = 0;
    private float newXPos = 0;
    private Vector3 newPosition;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(bgTag);

        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;

        highestXPosition = backgrounds[0].transform.position.x;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].transform.position.x > highestXPosition)
                highestXPosition = backgrounds[i].transform.position.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(bgTag))
        {
            newXPos = highestXPosition + offsetValue;
            highestXPosition = newXPos;

            newPosition=other.transform.position;
            newPosition.x = newXPos;

            other.transform.position = newPosition;

        }
    }
}
