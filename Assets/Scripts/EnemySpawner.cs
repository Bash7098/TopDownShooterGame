using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;

    private int currentEnemyCount = 0;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        // Start the coroutine to spawn enemies regardless of the player's presence
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
            if (isPlayerInTrigger)
            {
                // Spawn an enemy if the player is in the trigger zone
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentEnemyCount++;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger, set the flag
            isPlayerInTrigger = true;
        }
    }

    // OnTriggerExit2D is called when the Collider2D other has stopped touching the trigger
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player left the trigger, no need to set any flag
        }
    }
}
