using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRate = .5f; // The initial spawn rate in seconds
    public float spawnPositionY = 0.5f;
    private float timeSinceLastSpawn = 0f;

    // Start is called before the first frame update
    void Update()
    {
        // Increment the timer
        timeSinceLastSpawn += Time.deltaTime;

        // Check if enough time has passed to spawn a new prefab
        if (timeSinceLastSpawn >= spawnRate)
        {
            // Spawn a new prefab
            Instantiate(prefabToSpawn, new Vector3(transform.position.x, transform.position.y -spawnPositionY, transform.position.z), Quaternion.identity);

            // Reset the timer
            timeSinceLastSpawn = 0f;
        }
    }
}
