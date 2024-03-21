using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Direction move
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * moveSpeed * Time.deltaTime;

        // Move the Rigidbody
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Rotate the player
        if (movement != Vector3.zero)
        {
            // Calculate the rotation angle
            float targetAngle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;

            // Create the rotation vector
            Vector3 rotationVector = new Vector3(0f, targetAngle, 0f);

            // Rotate the player smoothly
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotationVector), rotationSpeed * Time.deltaTime);
        }
    }
}
