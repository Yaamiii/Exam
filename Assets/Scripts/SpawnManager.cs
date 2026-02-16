using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float bombSpawnChance = 0.1f;

    public float spawnXRange = 1.5f;
    public float spawnYPosition = 2.1f;
    public float spawnInterval = 1.0f;

    private float timer = 0f;

    private void Update()
    {
        // Count time between spawns
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        // Prevent errors if no fruits are assigned
        if (fruitPrefabs == null || fruitPrefabs.Length == 0)
        {
            return;
        }

        // Calculate random spawn position
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );

        // Decide whether to spawn a bomb or a fruit
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
