using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float rotationSpeed = 1f;
    private Vector3 moveDirection;
    private bool isGrounded;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input Move X and Y
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Calculate direction character move
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
        moveDirection = cameraForward * moveVertical + cameraRight * moveHorizontal;

        //Rotate Character follow
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Input Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        void FixedUpdate()
        {
            //Direction character move
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.MovePosition(rb.position + moveDirection.normalized * runSpeed * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + moveDirection.normalized * walkSpeed * Time.fixedDeltaTime);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            //Check character to ground
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

    }
}
