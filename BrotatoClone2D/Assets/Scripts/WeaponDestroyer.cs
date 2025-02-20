using UnityEngine;

public class WeaponDestroyer : MonoBehaviour
{
    private Vector2 startPosition;
    private float maxDistance;
    private bool isInitialized = false;
    private Transform player;

    public void Initialize(Vector2 spawnPos, float maxTravelDistance, Transform playerTransform)
    {
        isInitialized = true;
        startPosition = spawnPos;
        maxDistance = maxTravelDistance;
        player = playerTransform;
    }

    void Update()
    {
        if (!isInitialized) return;

        //if (player == null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
