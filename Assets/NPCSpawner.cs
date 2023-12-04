using UnityEngine;
using System.Collections; 

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public int maxNPCs = 4;
    [SerializeField] private float spawnTimerLowerBound = 4f;
    [SerializeField] private float spawnTimerUpperBound = 12f;

    private void Start()
    {
        // Start the coroutine to spawn NPCs
        StartCoroutine(SpawnNPCRoutine());
    }

    private IEnumerator SpawnNPCRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimerLowerBound, spawnTimerUpperBound));

            // Check if there are less than maxNPCs NPCs in the scene
            if (CountNPCs() < maxNPCs)
            {
                // Spawn a new NPC
                SpawnNPC();
            }
        }
    }

    private void SpawnNPC()
    {
        Instantiate(npcPrefab, transform.position, Quaternion.identity);
    }

    private int CountNPCs()
    {
        // Count the number of NPCs in the scene
        return GameObject.FindGameObjectsWithTag("NPC").Length;
    }
}
