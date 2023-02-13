using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float jumpY = 13f;
    public float jumpX = 13f;
    public float speedX = 6f;
    public float speedY = 2f;
    public float dashspeedY = 10f;
    public float dashspeedX = 10f;
    public float gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;
    bool isjumping;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isjumping = false;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, transform.position.y, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                if (Input.GetKey("space") && isGrounded && isjumping == false)
                {
                    velocity.y = Mathf.Sqrt(jumpX * -2 * gravity);
                    isjumping = true;
                }
                else if (isjumping == false)
                {
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speedY * Time.deltaTime);
                }
                if (isjumping == true)
                {
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * dashspeedX * Time.deltaTime);
                }
            }
            if (Input.GetKey("w") || Input.GetKey("s"))
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                if (Input.GetKey("space") && isGrounded && isjumping == false)
                {
                    velocity.y = Mathf.Sqrt(jumpY * -2 * gravity);
                    isjumping = true;
                }
                else if (isjumping == false)
                {
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speedY * Time.deltaTime);
                }
                if (isjumping == true)
                {
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * dashspeedY * Time.deltaTime);
                }
            }

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
