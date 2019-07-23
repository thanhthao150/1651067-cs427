using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;   

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private Transform m_GroundCheck; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here.
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator animator;


    bool isGrounded = false;
        
    private bool facingLeft = true;
    private void Start()
    {
        //get collider
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //jump -> fall
        if (animator.GetBool("Jumping"))
        {
            if(rb.velocity.y < .1)
            {
                animator.SetBool("Falling", true);
                animator.SetBool("Jumping", false);
            }
        }

        //fall -> idle
        if (coll.IsTouchingLayers(groundLayer) && animator.GetBool("Falling"))
        {
            animator.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        //check if on ground
        isGrounded = Physics2D.OverlapCircle(m_GroundCheck.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground  
        Debug.Log(isGrounded);
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);


        if (facingLeft)
        {
            //test if we are beyond the left cap
            if (transform.position.x > leftCap)
            {
                //sprite is facing corrected location, if not, face right
                if (transform.localScale.x != 8)
                {
                    transform.localScale = new Vector3(8, 8);
                }

                //test if frog is on the ground => jump
                if (coll.IsTouchingLayers(groundLayer))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        //facing right
        else
        {
            if (transform.position.x < rightCap)
            {
                //sprite is facing corrected location, if not, face right
                if (transform.localScale.x != -8)
                {
                    transform.localScale = new Vector3(-8, 8);
                }

                //test if frog is on the ground => jump
                if (coll.IsTouchingLayers(groundLayer))
                {
                    //jump
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }   

    public void Tremble()
    {
        animator.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
