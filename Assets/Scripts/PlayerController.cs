using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private Animator animator = null;

    private Rigidbody2D rbody2D = null;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rbody2D.velocity=new Vector2(moveSpeed,rbody2D.velocity.y);
    }
}
