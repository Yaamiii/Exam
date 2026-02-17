using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    [Header("Bomb Ramp Up")]
    public float maxBombChance = 0.2f;     // final bomb chance (20%)
    public int rampUpSpawns = 10;          // reach max chance after N spawns

    [Header("Top Spawn")]
    public float spawnXRange = 1.5f;
    public float spawnYPosition = 2.1f;
    public float spawnInterval = 1.0f;

    [Header("Side Launch (Physics)")]
    public int sideSpawnFrequency = 4;     
    public float sideSpawnX = 3.0f;
    public float sideSpawnY = 0.5f;
    public float sideImpulseX = 3.0f;
    public float sideImpulseY = 5.0f;

    private float timer = 0f;
    private int spawnCount = 0;

    private void OnEnable()
    {
        // Reset spawning values when the scene restarts
        timer = 0f;
        spawnCount = 0;
    }

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
        if (fruitPrefabs == null || fruitPrefabs.Length == 0)
        {
            return;
        }

        // Calculate bomb chance based on how many objects were spawned so far
        float bombSpawnChance = GetBombChance();

        // Choose what to spawn (bomb or fruit)
        GameObject prefabToSpawn;

        if (bombPrefab != null && Random.value < bombSpawnChance)
        {
            prefabToSpawn = bombPrefab;
        }
        else
        {
            int randomIndex = Random.Range(0, fruitPrefabs.Length);
            prefabToSpawn = fruitPrefabs[randomIndex];
        }

        if (prefabToSpawn == null)
        {
            return;
        }

        // Increase spawn counter AFTER selecting the chance (so first spawn is 0% bombs)
        spawnCount++;

        // Decide if this spawn is a side launch or a top spawn
        if (sideSpawnFrequency > 0 && spawnCount % sideSpawnFrequency == 0)
        {
            SpawnFromSide(prefabToSpawn);
        }
        else
        {
            SpawnFromTop(prefabToSpawn);
        }
    }

    private float GetBombChance()
    {
        if (rampUpSpawns <= 0)
        {
            return maxBombChance;
        }

        if (spawnCount >= rampUpSpawns)
        {
            return maxBombChance;
        }

        return maxBombChance * ((float)spawnCount / rampUpSpawns);
    }

    private void SpawnFromTop(GameObject prefabToSpawn)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );

        Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);
    }

    private void SpawnFromSide(GameObject prefabToSpawn)
    {
        float side = (Random.value < 0.5f) ? -1f : 1f;

        Vector3 spawnPosition = new Vector3(
            side * sideSpawnX,
            sideSpawnY,
            0f
        );

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);

        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            return;
        }

        Vector3 impulse = new Vector3(-side * sideImpulseX, sideImpulseY, 0f);
        rb.AddForce(impulse, ForceMode.Impulse);
    }
}





