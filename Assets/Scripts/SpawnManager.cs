using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float bombSpawnChance = 0.1f;

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

        // Count how many objects we have spawned
        spawnCount++;

        // Choose whether to spawn a bomb or a fruit
        GameObject prefabToSpawn;

        if (Random.value < bombSpawnChance && bombPrefab != null)
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

        // 1 out of N spawns: launch from the side using physics
        if (sideSpawnFrequency > 0 && spawnCount % sideSpawnFrequency == 0)
        {
            SpawnFromSide(prefabToSpawn);
        }
        else
        {
            SpawnFromTop(prefabToSpawn);
        }
    }

    private void SpawnFromTop(GameObject prefabToSpawn)
    {
        // Spawn at random X from above
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );

        Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);
    }

    private void SpawnFromSide(GameObject prefabToSpawn)
    {
        // Pick left or right side
        float side = (Random.value < 0.5f) ? -1f : 1f;

        // Spawn off-screen on the chosen side
        Vector3 spawnPosition = new Vector3(
            side * sideSpawnX,
            sideSpawnY,
            0f
        );

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);

        // Apply impulse only if the object has a Rigidbody
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            return;
        }

        // Push towards the center and upward to create an arc
        Vector3 impulse = new Vector3(-side * sideImpulseX, sideImpulseY, 0f);
        rb.AddForce(impulse, ForceMode.Impulse);
    }
}




