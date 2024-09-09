using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    [SerializeField] private Camera cameras;
    private float yRotation;
    private float xRotation;

    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float jumpForce = 5.0f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
        CameraController();
        if (Input.GetButtonDown("Jump")) 
        {
            JumpController();
        }
    }

    void MoveController() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDir = cameras.transform.right * moveX + cameras.transform.forward * moveZ;

        rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);

        //rb.velocity = moveDir * speed;

    }

    void JumpController() 
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CameraController() 
    {
        // Input Mouse while move with direction X & Y
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Set value mouseX plus for direction Y and mouse Y minus for direction X (If  it's opposite, it will reverse direction)
        yRotation += mouseX;
        xRotation -= mouseY;

         // Limited xRotation between -90 and 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Camera Rotate follow X & Y direction
        cameras.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Player rotate right & left combine with mouseX
        transform.Rotate(Vector3.up * mouseX);
    }
}
