using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        //Creates a sphere with a specified radius (groundDistance) and checks to see if its colliding with the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If the player is on the ground and the velocity is less than 0, reset the velocity so it isn't constantly building up
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Moves the x and z
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        //Check to see if the player can jump
        JumpCheck();

        velocity.y += gravity * Time.deltaTime;

        //Gravity based on the velocity given
        controller.Move(velocity * Time.deltaTime);
    }

    void JumpCheck()
    {
        //If jump button is pressed, have the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Physics equation for jumping a specific amount of units: square root of the units wanted * -2 * the gravitational force
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }//end of JumpCheck

}
