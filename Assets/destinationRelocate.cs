using UnityEngine;

public class DestinationRelocate : MonoBehaviour
{
    [SerializeField] private float Xmax = 10f;
    [SerializeField] private float Xmin = -10f;
    [SerializeField] private float Ymax = 5f;
    [SerializeField] private float Ymin = -5f;
    [SerializeField] private float killZoneChance = 0.1f;
    [SerializeField] private float relocationInterval = 5f; // Adjust this value as needed

    private float timer;

    void Start()
    {
        // Initialize the timer
        timer = relocationInterval;
    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if it's time to relocate
        if (timer <= 0f)
        {
            RelocateDestination();
            // Reset the timer for the next relocation
            timer = relocationInterval;
        }
    }

    void RelocateDestination()
    {
        //Debug.Log("New position to be selected");

        // Decide whether to use a kill zone or a random position
        float chance = Random.value;
        if (chance <= killZoneChance)
        {
            // Kill zone position
            transform.position = new Vector3(9f, -9.5f, transform.position.z);
            //Debug.Log("Dead zone selected");
        }
        else
        {
            // Use a random position
            float randomX = Random.Range(Xmin, Xmax);
            float randomY = Random.Range(Ymin, Ymax);
            transform.position = new Vector3(randomX, randomY, transform.position.z);
            //Debug.Log("New position selected");
        }
    }
}
