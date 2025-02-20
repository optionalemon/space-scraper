using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab; // Assign rock prefab in Inspector
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float spawnInterval = 2f; // Time between spawns

    public int rockPerInterval = 5;

    void Start()
    {
        InvokeRepeating("SpawnRock", 0f, spawnInterval);
    }

    void SpawnRock()
    {
        if (rockPrefab == null) return;

    
        for (int i = 0; i < rockPerInterval; i++) {
            // Instantiate rock at this spawn point's position
            GameObject rock = Instantiate(rockPrefab, transform.position, Random.rotation);

            Rigidbody rb = rock.GetComponent<Rigidbody>();
            if (rb == null)
                rb = rock.AddComponent<Rigidbody>(); // Ensure Rigidbody exists

            // Apply random flying direction & speed
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            rb.isKinematic = false;
            rb.velocity = randomDirection * Random.Range(minSpeed, maxSpeed);
            Destroy(rock, 2f);
        }
        
    }
}
