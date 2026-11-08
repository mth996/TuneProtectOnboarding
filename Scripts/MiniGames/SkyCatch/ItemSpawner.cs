using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public float itemFallSpeed = 20f; // Speed at which items fall
    public RectTransform canvasRect; // Reference to the Canvas GameObject

    private float canvasWidth;
    private bool canSpawn = true; // Flag to control spawning

    
    private void Start()
    {
        canvasWidth = canvasRect.rect.width;

        InvokeRepeating("SpawnItem", Random.Range(minSpawnInterval, maxSpawnInterval), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnItem()
    {

        if (!canSpawn)
        {
            return; // Stop spawning when the game is over
        }
        int randomIndex = Random.Range(0, itemPrefabs.Length);

        // Calculate a random X position within the Canvas boundaries
        float randomX = Random.Range(0, canvasWidth);

        // Set the spawn position at the top of the Canvas
        Vector3 spawnPosition = new Vector3(randomX, canvasRect.rect.height, 0);
        GameObject item = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        item.transform.SetParent(canvasRect);

        // Apply horizontal speed to the item while keeping vertical speed zero
        Rigidbody2D itemRigidbody = item.GetComponent<Rigidbody2D>();
        itemRigidbody.velocity = new Vector2(0f, -itemFallSpeed);

        Destroy(item, 10f); // Destroy items after a few seconds
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
}
