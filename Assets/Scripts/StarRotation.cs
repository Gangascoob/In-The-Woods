using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    // Reference to the player's transform
    public Transform playerTransform;

    // Offset position relative to the player's forward direction
    public Vector3 offsetPosition = new Vector3(0f, 2f, 5f); // Adjust the values as needed

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position of the "north star" relative to the player
            Vector3 desiredPosition = playerTransform.position + playerTransform.forward * offsetPosition.z
                + playerTransform.up * offsetPosition.y + playerTransform.right * offsetPosition.x;

            // Set the position of the "north star" object to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10f);

            // Keep the "north star" object always upright (facing upwards)
            transform.rotation = Quaternion.Euler(0f, playerTransform.eulerAngles.y, 0f);
        }
    }

    //why didnt this change anything
}
