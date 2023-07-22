using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    public float bobFrequency = 2f; // How fast the headbob occurs
    public float bobAmplitude = 0.1f; // The amount of headbob movement
    public float runMultiplier = 2f; // Multiplier for headbob when running

    private float timer = 0f;
    private float originalYPos;

    void Start()
    {
        originalYPos = transform.localPosition.y;
    }

    void Update()
    {
        // Get the player's movement magnitude to determine headbob intensity
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;
        float moveMagnitude = moveDirection.magnitude;

        // Calculate the headbob position
        float bobAmount = Mathf.Sin(timer) * bobAmplitude * moveMagnitude;

        // Apply headbob with extra intensity when running
        if (moveMagnitude > 0.1f)
            bobAmount *= runMultiplier;

        // Apply the headbob to the camera's Y position
        transform.localPosition = new Vector3(transform.localPosition.x, originalYPos + bobAmount, transform.localPosition.z);

        // Increment the timer based on time and bob frequency
        timer += bobFrequency * Time.deltaTime;
        if (timer > Mathf.PI * 2f)
            timer -= Mathf.PI * 2f;
    }
}
