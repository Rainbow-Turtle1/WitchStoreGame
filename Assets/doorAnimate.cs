using UnityEngine;

public class doorAnimate : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    // Called when a 2D collider enters the trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has the tags "NPC" or "Player"
        if (other.CompareTag("NPC") || other.CompareTag("Player"))
        {
            Debug.Log("Enter Triggered");
            // Trigger the "Open" animation
            doorAnimator.SetTrigger("Open");
        }
    }

    // Called when a 2D collider exits the trigger collider
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting object has the tags "NPC" or "Player"
        if (other.CompareTag("NPC") || other.CompareTag("Player"))
        {
            Debug.Log("Exit Triggered");
            // Trigger the "Close" animation
            doorAnimator.SetTrigger("Close");
        }
    }
}
