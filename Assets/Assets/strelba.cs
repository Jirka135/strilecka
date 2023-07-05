using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int bulletDamage = 10;
    public float bulletDespawnTimer = 2f;
    public float attackSpeed = 2f; // Number of shots per second

    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime; // Increase the shoot timer

        // Calculate the time interval between shots based on the attack speed
        float timeBetweenShots = 1f / attackSpeed;

        if (shootTimer >= timeBetweenShots)
        {
            Shoot();
            shootTimer = 0f; // Reset the shoot timer
        }
    }

    void Shoot()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen space mouse position to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the player to the world space mouse position
        Vector3 shootDirection = worldMousePosition - transform.position;
        shootDirection.z = 0f;
        shootDirection.Normalize();

        // Calculate the angle in degrees based on the shoot direction
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Calculate the position next to the player for bullet instantiation
        Vector3 spawnPosition = transform.position + shootDirection;

        // Instantiate a new bullet at the calculated spawn position with the calculated angle
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.AngleAxis(angle, Vector3.forward));

        // Set the bullet's velocity and damage
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetVelocity(shootDirection * bulletSpeed);
        bulletController.SetDamage(bulletDamage);

        // Set the bullet's despawn timer
        Destroy(bullet, bulletDespawnTimer);
    }
}