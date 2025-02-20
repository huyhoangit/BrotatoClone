using UnityEngine;

public class WeaponDestroyer : MonoBehaviour
{
    private Vector2 startPosition;
    private float maxDistance;
    private bool isInitialized = false;

    public void Initialize(Vector2 spawnPos, float maxTravelDistance)
    {
        isInitialized = true;
        startPosition = spawnPos;
        maxDistance = maxTravelDistance;
    }

    void Update()
    {
        if (!isInitialized) return;

        // Check how far the weapon has traveled
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
