using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float bombSpawnChance = 0.1f; // 10% bombs

    public float spawnXRange = 1.5f;
    public float spawnYPosition = 2.1f;
    public float spawnInterval = 1.0f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        // Safety check
        if (fruitPrefabs == null || fruitPrefabs.Length == 0)
        {
            return;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );

        // Spawn bomb or fruit
        if (Random.value < bombSpawnChance && bombPrefab != null)
        {
            Instantiate(bombPrefab, spawnPosition, bombPrefab.transform.rotation);
        }
        else
        {
            int randomIndex = Random.Range(0, fruitPrefabs.Length);
            GameObject fruitToSpawn = fruitPrefabs[randomIndex];

            if (fruitToSpawn != null)
            {
                Instantiate(fruitToSpawn, spawnPosition, fruitToSpawn.transform.rotation);
            }
        }
    }
}