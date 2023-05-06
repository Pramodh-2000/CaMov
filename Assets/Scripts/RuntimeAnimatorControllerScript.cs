using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeAnimatorControllerScript : MonoBehaviour
{
    public Animator animator;
    public CameraController cameraController;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the game object
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.position += movement * Time.deltaTime;

        // Rotate the game object
        transform.Rotate(Vector3.up, Time.deltaTime * 10f);

        // Update the animator parameters
        animator.SetFloat("MoveSpeed", movement.magnitude);
        animator.SetBool("IsMoving", movement.magnitude > 0f);
        animator.SetBool("IsJumping", Input.GetKey(KeyCode.Space));

        // Update the camera controller parameters
        cameraController.distanceFromTarget = Mathf.Clamp(cameraController.distanceFromTarget + Input.mouseScrollDelta.y, 1f, 10f);
    }
}
