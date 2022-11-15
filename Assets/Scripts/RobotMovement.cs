using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public CharacterController cc;
    public Transform cameraTransform;
    public float gravity = -9.81f;
    public float jumpheight = 1.5f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        float speed = 0;

        cameraTransform = Camera.main.transform;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)

        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right.normalized * x + cameraTransform.forward.normalized * z;
        move.y = 0;
        cc.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);


    }
}
