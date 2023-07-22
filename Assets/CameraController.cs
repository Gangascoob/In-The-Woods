using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float damping = 6f; // Adjust this value to control the damping strength
    public float verticalLookLimit = 90f; // Set the maximum angle the camera can look up and down
    public Transform target; // Reference to the target that the cameras will follow

    private Vector3 offset; // Offset from the target to the cameras
    private float verticalRotation = 0f; // Store the vertical rotation
    private float horizontalRotation = 0f; // Store the horizontal rotation

    public float sensitivity = 200f;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calculate the target position for the cameras
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the cameras towards the target position using damping
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);

        // Player Look (Mouse) - Handle vertical and horizontal rotation separately
        float mouseX = Input.GetAxis("Mouse X") * damping * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * damping * Time.deltaTime;

        verticalRotation -= sensitivity* mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        horizontalRotation += sensitivity * mouseX;
        target.localRotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}
