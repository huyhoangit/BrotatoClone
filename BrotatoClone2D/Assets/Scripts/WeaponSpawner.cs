using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform player;
    public float spawnRadius = 2f; // Distance from the player
    public float spawnInterval = 0.2f;
    public float startDelay = 1.0f;
    public float weaponSpeed = 10f; // Speed of the flying weapon
    public float maxTravelDistance = 5f; // Max distance before destroying weapon

    private IEnumerator SpawnWeaponRoutine()
    {
        yield return new WaitForSeconds(startDelay); // Wait before first spawn

        while (true) // Infinite loop
        {
            SpawnWeapon(); // Spawn weapon
            yield return new WaitForSeconds(spawnInterval); // Wait before next spawn
        }
    }

    void Start()
    {
        StartCoroutine(SpawnWeaponRoutine()); // Start the weapon spawning loop
    }

    void SpawnWeapon()
    {
        if (player == null) return;

        // Random spawn position around the player
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;

        // Create weapon
        GameObject weapon = Instantiate(weaponPrefab, spawnPos, Quaternion.identity);

        // Calculate direction away from the player
        Vector2 direction = ((Vector2)spawnPos - (Vector2)player.position).normalized;

        // Get Rigidbody and apply force
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * weaponSpeed;
        }

        // Rotate weapon to face its flying direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Attach WeaponDestroyer script to track distance
        WeaponDestroyer destroyer = weapon.AddComponent<WeaponDestroyer>();
        destroyer.Initialize((Vector2)player.position, maxTravelDistance);
    }
}
