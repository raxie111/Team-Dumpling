using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;  // Reference to the slime prefab
    public Transform playerTransform;  // Reference to the player's transform
    public float spawnDistance = 10f;  // Distance away from the player to spawn slimes
    public float spawnInterval = 20f;  // Time in seconds between slime spawns
    public int maxSlimes = 5;  // Maximum number of slimes to spawn

    private int slimeCount = 0;  // Current number of spawned slimes
    private float lastSpawnTime = 0f;  // Time when the last slime was spawned

    void Update()
    {
        // Check if it's time to spawn a new slime
        if (slimeCount < maxSlimes && Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnSlime();
        }
    }

    void SpawnSlime()
    {
        // Calculate the position to spawn the slime
        Vector3 spawnPos = playerTransform.position + new Vector3(0f, spawnDistance, 0f);

        // Instantiate the slime at the spawn position
        GameObject newSlime = Instantiate(slimePrefab, spawnPos, Quaternion.identity);

        // Increment the slime count and update the last spawn time
        slimeCount++;
        lastSpawnTime = Time.time;
    }
}