using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 10f;
    public float distanceFromGround = 5f;
    public float rotationSpeed = 5f;
    public float rotationDampening = 0.9f;

    private Vector3 rotation = Vector3.zero;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, distanceFromGround, -distanceFromTarget);
    }

    private void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rotation.y += horizontal * rotationSpeed;

        Quaternion newRotation = Quaternion.Euler(rotation);

        Vector3 newPosition = target.position + (newRotation * offset);

        transform.position = Vector3.Lerp(transform.position, newPosition, rotationDampening * Time.deltaTime);

        transform.LookAt(target.position + new Vector3(0, 1, 0));
    }
}
