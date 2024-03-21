using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    public float jumpForce = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        anim.SetBool("Jumping", true);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void EndJumpAnimation()
    {
        anim.SetBool("Jumping", false);
    }
}

