using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform pocemkamdeš;
    private Vector3 movingTargetPosition;
    public static int enemies;

    [Range(1f, 25f)]
    public float spawnRadius = 19f;

    [Range(0.5f, 15f)]
    public float innerRadius = 13f;

    [Range (1f,20f)]
    public float spawnpersec = 1f;

    public float spawnInterval = 3f;

    void Start()
    {
        // Initialize the moving target position
        if (pocemkamdeš != null)
        {
            movingTargetPosition = pocemkamdeš.position;
        }
        InvokeRepeating("updateSpawn", 0f, 1f);
    }

    void updateSpawn()
    {
        spawnInterval = 1f / spawnpersec;
        // Call the SpawnEnemy function repeatedly with the calculated spawn interval.
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), spawnRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), innerRadius);
    }

    void SpawnEnemy()
    {
        enemies++;
        float randomAngle = Random.Range(0f, 360f);
        Vector3 spawnPosition = spawnPoint.position + Quaternion.Euler(0f, 0f, randomAngle) * Vector3.up * spawnRadius;

        // Make sure the enemy is outside the inner circle
        if (Vector3.Distance(new Vector3(spawnPosition.x, spawnPosition.y, 0f), new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f)) < innerRadius)
        {
            return;
        }

        // Instantiate a new enemy at the spawn position
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Set the target position for the enemy movement
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
        enemyMovement.SetTargetPosition(pocemkamdeš);
    }

}