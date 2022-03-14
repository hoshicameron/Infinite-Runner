using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float xOffset = -6;

    private Transform playerTransform;
    private Vector3 tempPosition;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(playerTransform==null)    return;

        tempPosition = transform.position;
        tempPosition.x = playerTransform.position.x + xOffset;
        transform.position = tempPosition;
    }

}
