using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;
    CharacterController characterController;
    public float speed = 6.0f;
    public float rotateSpeed = 25f;
    public float jumpSpeed = 7.5f;
    public float gravity = 20f;
    Vector3 inputVec;
    Vector3 tragetDirection;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = -(Input.GetAxisRaw("Vertical"));
        float z = (Input.GetAxisRaw("Horizontal"));
        inputVec = new Vector3 (x,0, z);

        anim.SetFloat("Input X", z);
        anim.SetFloat("Input Z", -(x));

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
        //Jumping

        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
           
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
