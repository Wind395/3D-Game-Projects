using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;


public class PlayerMovements : MonoBehaviour
{

    [Header("Player Status")]
    public float moveSpeed; // MoveSpeed
    // Just Gravity
    private const float gravity = -9.8f;

    // Move Direction for Player
    private Vector3 moveDir;

    // GetComponent of CharacterController
    CharacterController controller;
    

    [Header("Jump")]

    //JumpForce
    public float jump;

    // Check Ground for Jump Limit
    public LayerMask groundMask;

    // Position of Sphere to check ground
    public Transform groundCheckPos;

    // True or False for jumpLimit
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        //Player
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create Sphere for JumpLimit
        isGrounded = Physics.CheckSphere(groundCheckPos.position, 0.4f, groundMask);

        //Move Player with Input & direction X and Z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Right & Left with A, D. Forward & Behind with W, S
        Vector3 move = transform.right * x + transform.forward * z;

        // deltaY = 1/2 * gravity * time^2
        moveDir.y += 0.5f * gravity * Time.deltaTime;

        // Move Player with input direction, speed and time
        controller.Move(move * moveSpeed * Time.deltaTime);

        // deltaY = 1/2 * gravity * time^2. Combine with CharacterController.Move to move player
        controller.Move(moveDir * Time.deltaTime);

        // Jump input and checkGround to jumpLimit
        if (Input.GetButtonDown("Jump") && isGrounded) {
            moveDir.y = jump;
        }
    }
}
