using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform player;
    public float spawnRadius = 2f;
    public float spawnInterval = 0.2f;
    public float startDelay = 1.0f;
    public float weaponSpeed = 10f; 
    public float maxTravelDistance = 5f;

    private IEnumerator SpawnWeaponRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        while (true) 
        {
            SpawnWeapon();
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    void Start()
    {
        StartCoroutine(SpawnWeaponRoutine());
    }

    void SpawnWeapon()
    {
        if (player == null) return;

        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;

        GameObject weapon = Instantiate(weaponPrefab, spawnPos, Quaternion.identity);

        Vector2 direction = ((Vector2)spawnPos - (Vector2)player.position).normalized;

        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * weaponSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);

        WeaponDestroyer destroyer = weapon.AddComponent<WeaponDestroyer>();
        destroyer.Initialize((Vector2)player.position, maxTravelDistance, player);
    }
}
