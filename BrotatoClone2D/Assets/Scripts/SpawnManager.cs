using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRangeX = 50;
    public float spawnRangeY = 50;
    public float startDelay = 2.0f;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void Update()
    {
    }

    void SpawnRandomEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);

        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            // Randomly assign an enemy type
            enemyScript.enemyType = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);

            Debug.Log("Spawned Enemy: " + enemyScript.enemyType);
        }
    }
}
