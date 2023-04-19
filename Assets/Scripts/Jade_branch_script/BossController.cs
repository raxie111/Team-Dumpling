using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BossController : MonoBehaviour
{
    public Sprite slimeBallSprite;
    public float movementSpeed = 5f;
    public int maxHealth = 25;
    public GameObject slimePrefab;
    public int maxSlimeSpawnCount = 4;

    private int currentHealth;
    private float timeSinceLastSlimeSpawn = 0f;
    private int slimeSpawnCount = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Shoot slime balls
        ShootSlimeBall();

        // Spawn slimes after 15 seconds
        if (slimeSpawnCount < maxSlimeSpawnCount)
        {
            timeSinceLastSlimeSpawn += Time.deltaTime;
            if (timeSinceLastSlimeSpawn >= 15f)
            {
                SpawnSlimes();
                slimeSpawnCount++;
                timeSinceLastSlimeSpawn = 0f;
            }
        }

        // Move the boss
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
    }

    void ShootSlimeBall()
    {
        // Code for shooting slime balls goes here
        // You can use the slimeBallSprite variable to set the sprite of the slime ball
    }

    void SpawnSlimes()
    {
        // Spawn slimes two units away from boss in four cardinal directions
        Vector3 north = transform.position + Vector3.up * 2f;
        Vector3 south = transform.position + Vector3.down * 2f;
        Vector3 east = transform.position + Vector3.right * 2f;
        Vector3 west = transform.position + Vector3.left * 2f;

        Instantiate(slimePrefab, north, Quaternion.identity).GetComponent<SpriteRenderer>().sprite = slimeBallSprite;
        Instantiate(slimePrefab, south, Quaternion.identity).GetComponent<SpriteRenderer>().sprite = slimeBallSprite;
        Instantiate(slimePrefab, east, Quaternion.identity).GetComponent<SpriteRenderer>().sprite = slimeBallSprite;
        Instantiate(slimePrefab, west, Quaternion.identity).GetComponent<SpriteRenderer>().sprite = slimeBallSprite;
    }


    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            // Code for boss death goes here
        }
    }
}

