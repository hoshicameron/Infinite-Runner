using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private Animator animator = null;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition=null;

    private Rigidbody2D rbody2D = null;
    private bool canDoubleJump=true;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        if (!IsGrounded() && canDoubleJump)
        {
            canDoubleJump = false;

            rbody2D.velocity=Vector2.zero;
            rbody2D.AddForce(new Vector2(0,jumpForce*0.9f),ForceMode2D.Impulse);
        }
        if (IsGrounded())
        {
            canDoubleJump = true;
            rbody2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rbody2D.velocity=new Vector2(moveSpeed,rbody2D.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(groundCheckPosition.position, 0.1f);
    }
}
