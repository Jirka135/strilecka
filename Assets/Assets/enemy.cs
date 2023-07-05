using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public float spawnRadius = 5f;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPoint.position, spawnRadius);
    }

    void SpawnEnemy()
    {
        // Generate a random azimuth angle (horizontal angle) within the circle
        float randomAzimuth = Random.Range(0f, 2f * Mathf.PI);

        // Generate a random inclination angle (vertical angle) within the circle
        float randomInclination = Random.Range(-Mathf.PI / 2f, Mathf.PI / 2f);

        // Calculate the spawn position based on the azimuth, inclination, and radius
        Vector3 spawnPosition = spawnPoint.position + new Vector3(
            Mathf.Cos(randomAzimuth) * Mathf.Cos(randomInclination),
            Mathf.Sin(randomInclination),
            Mathf.Sin(randomAzimuth) * Mathf.Cos(randomInclination)
        ) * spawnRadius;

        // Instantiate a new enemy at the spawn position
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Optional: You can add additional logic to modify the enemy's properties or behavior here
    }
}