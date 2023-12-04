using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPosition;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found.");
        }

        // Initialize the previous position to the current position at the start
        previousPosition = transform.position;
    }

    void Update()
    {
        // Assuming your A* script updates the position directly
        Vector3 currentPosition = transform.position;

        // Calculate the velocity manually
        float currentVelocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;

        // Update the "Velocity" parameter in the Animator
        if (animator != null)
        {
            animator.SetFloat("Velocity", currentVelocity);
        }

        // Update the previous position for the next frame
        previousPosition = currentPosition;
    }
}
