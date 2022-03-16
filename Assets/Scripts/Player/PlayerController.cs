using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition=null;
    [SerializeField] private PlayerAnimation playerAnimation = null;

    [Header("Attack")]
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform shootTransform=null;

    [Header("Collider")]
    [SerializeField] private Vector2 colliderSlideSize=new Vector2(0.8f,0.7133794f);
    [SerializeField] private Vector2 colliderSlideOffset=new Vector2(0f,-0.18f);

    private Rigidbody2D rbody2D = null;
    private bool canDoubleJump=true;
    /*private BoxCollider2D boxCollider2D = null;
    private Vector2 colliderStartSize=Vector2.zero;
    private Vector2 colliderStartOffset=Vector2.zero;*/

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        /*boxCollider2D = GetComponent<BoxCollider2D>();
        colliderStartSize = boxCollider2D.size;
        colliderStartOffset = boxCollider2D.offset;*/

        playerAnimation.shootBullet+=PlayerAnimation_ShootBullet;

    }


    private void PlayerAnimation_ShootBullet()
    {
        GameObject bullet =
            PoolManager.Instance.ReuseGameObject(bulletPrefab, shootTransform.position, Quaternion.identity);
        bullet.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(IsGrounded())    playerAnimation.PlayAttack();
            else                playerAnimation.PlayJumpAttack();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimation.PlaySlide();
        }

        AnimatePlayer();
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

    private void AnimatePlayer()
    {
        playerAnimation.PlayJump(rbody2D.velocity.y);
        playerAnimation.PlayerFromJumpToRunning(IsGrounded());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(groundCheckPosition.position, 0.1f);
    }


}
