using UnityEngine;

public class KillZone : MonoBehaviour
{
    private float timer = 0f;
    public float threshold = 10f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= threshold)
        {
            DestroyNPCs();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            Destroy(other.transform.parent.gameObject);
            Debug.Log("NPC entered the kill zone, destroying its parent");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            timer = 0f;
            Debug.Log("NPC exited the kill zone");
        }
    }

    void DestroyNPCs()
    {
        // This function is not needed for the updated behavior
    }
}
