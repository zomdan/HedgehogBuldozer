using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_LookAround : MonoBehaviour{

[SerializeField] private float mouseSensitivity = 2.0f;

    public Transform playerCamera;
    public float minY ;
    public float maxY ;

    private float rotationX = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    if (Input.GetMouseButtonDown(1))
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    HandleCameraRotation();
}



    private void HandleCameraRotation()
    {
        // Camera control
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        playerCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}