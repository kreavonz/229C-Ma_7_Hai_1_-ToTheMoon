using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollingController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody rb;
    private Animator anim;
    private bool facingToRight;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        facingToRight = true;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0);

        if (move > 0 && !facingToRight)
        {
            Flip();
        }
        else if (move < 0 && facingToRight)
        {
            Flip();
        }

        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void CheckGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f, LayerMask.GetMask("Ground"));
        isGrounded = colliders.Length > 0;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Flip()
    {
        facingToRight = !facingToRight;
        Vector3 tScale = transform.localScale;
        tScale.z *= -1;
        transform.localScale = tScale;
    }
}