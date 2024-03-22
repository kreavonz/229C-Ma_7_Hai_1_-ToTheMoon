using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    Animator anim; //Animator component
    CharacterController characterController; //CharacterController component
    public float speed = 6.0f;
    public float rotateSpeed = 3f; 
    public float jumpForce = 5f; 
    public float gravity = 9.8f;
    Vector3 inputVec; //Input vector for movement
    Vector3 tragetDirection; //Target direction for rotation
    private Vector3 moveDirection = Vector3.zero; //Movement direction

    //Start is called before the first frame update
    void Start()
    {
        //Set the time scale and initialize references
        Time.timeScale = 1.0f;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    //Update is called once per frame
    void Update()
    {
        //Get input for movement
        float x = -(Input.GetAxisRaw("Vertical"));
        float z = (Input.GetAxisRaw("Horizontal"));
        inputVec = new Vector3(x, 0, z);

        //Set parameters in the Animator based on input for animation blending
        anim.SetFloat("Input X", z);
        anim.SetFloat("Input Z", -(x));

        //Check if character is moving and set animation parameters accordingly
        if (x != 0 || z != 0)
        {
            anim.SetBool("Running", true);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Running", false);
            anim.SetBool("Moving", false);
        }

        //Check if Jump key is pressed and trigger jump animation
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("Jumping", true);
        }

        //Check if character is grounded
        if (characterController.isGrounded)
        {
            //Calculate movement direction and apply speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //Check if Jump button is pressed and apply jump force
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("Jumping", true);
                moveDirection.y = jumpForce;
            }
            else
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", moveDirection.magnitude > 0.0f);
            }
        }

        //Apply gravity and move the character
        characterController.Move(moveDirection * Time.deltaTime);

        //Update movement direction
        UpdateMovement();
    }

    //Update movement direction based on input
    void UpdateMovement()
    {
        Vector3 motion = inputVec;
        motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? 0.7f : 1;

        //Rotate character towards movement direction
        RotateTowardMovementDirection();
        //Get camera-relative movement direction
        getCameraRealtive();
    }

    //Rotate character towards movement direction
    void RotateTowardMovementDirection()
    {
        if (inputVec != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tragetDirection), Time.deltaTime * rotateSpeed);
        }
    }

    //Get movement direction relative to the camera
    void getCameraRealtive()
    {
        Transform cameraTranform = Camera.main.transform;
        Vector3 forward = cameraTranform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        tragetDirection = (h * right) + (v * forward);
    }
}
