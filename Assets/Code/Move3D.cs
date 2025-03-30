using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;
    public Transform cameraTransform; // Assign the Camera (or Player Head)

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.right * moveX + cameraTransform.forward * moveZ;
        move.y = 0;
        controller.Move(move.normalized * speed * Time.deltaTime);
    }
}
