using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public Animator anim;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk and Run
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Check movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Direction move calculate
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed;

        //Change Direction player move
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.deltaTime);

        // Play animation
        if (anim != null)
        {
            if (movement.magnitude > 0f)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    }
}
