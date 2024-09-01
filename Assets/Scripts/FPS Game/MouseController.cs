using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Mouse Sentivity
    public float mouseSentivity;

    // Change Rotation Y of Player
    public Transform player;

    // Change Rotation X Up Down Camera of Player
    private float xRotation;

    // Change Rotation Y Right Left Camera of Player
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Input Mouse while move with direction X & Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSentivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSentivity;

        // Set value mouseX plus for direction Y and mouse Y minus for direction X (If  it's opposite, it will reverse direction)
        yRotation += mouseX;
        xRotation -= mouseY;

        // Limited xRotation between -90 and 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // Camera Rotate follow X & Y direction
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Player rotate right & left combine with mouseX
        player.Rotate(Vector3.up * mouseX);

        
    }
}
