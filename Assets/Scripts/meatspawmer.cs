using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatspawmer : MonoBehaviour
{
    public GameObject Player;
    public GameObject meatPrefab; // The prefab for the meat object
    public int maxMeats; // The maximum number of slimes that can be spawned
    public float spawnInterval; // The time interval between slime spawns
    public float maxSpawnDistance; // The maximum distance from the player that slimes can spawn

    private GameObject player; // Reference to the player GameObject
    private int numMeats = 0; // The current number of spawned slimes
    private float timeSinceLastSpawn = 0.0f; // The time since the last slime was spawned
    private bool hasSpawnedFirstSlime = false; // Flag indicating if the first slime has already been spawned

    void Start()
    {
        // Find the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // If the maximum number of slimes has not been reached, check if it's time to spawn another slime
        if (numMeats < maxMeats)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (!hasSpawnedFirstSlime || timeSinceLastSpawn >= spawnInterval)
            {
                SpawnSlime();
                timeSinceLastSpawn = 0.0f;
            }
        }
    }

    void SpawnSlime()
    {
        // Check if the player GameObject has been found
        if (Player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        // Calculate a random position within the maximum spawn distance of the player
        Vector3 spawnOffset = new Vector3(Random.Range(-maxSpawnDistance, maxSpawnDistance), Random.Range(-maxSpawnDistance, maxSpawnDistance), 0.0f);

        // Instantiate the slime prefab at the spawn position, offset from the player's position
        Vector3 spawnPosition = player.transform.position + spawnOffset;
        GameObject slimeObject = Instantiate(meatPrefab, spawnPosition, Quaternion.identity);

        // Increment the number of spawned slimes and set the flag indicating the first slime has been spawned
        numMeats++;
        hasSpawnedFirstSlime = true;
    }
}
