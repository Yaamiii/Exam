using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float bombSpawnChance = 0.1f; // 10% bombs

    public float spawnXRange = 1.5f;
    public float spawnYPosition = 2.1f;
    public float spawnInterval = 10f;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keeps track of time so objects don't spawn every frame
        timer += Time.deltaTime;

        // Spawn an object when the interval is reached
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }
    void SpawnObject()
    {
        // Choose a random position within the horizontal range
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );

        // Decide if we spawn a bomb or a fruit
        if (Random.value < bombSpawnChance)
        {
            Instantiate(bombPrefab, spawnPosition, bombPrefab.transform.rotation);
        }
        else
        {
            int randomIndex = Random.Range(0, fruitPrefabs.Length);
            Instantiate(fruitPrefabs[randomIndex], spawnPosition, fruitPrefabs[randomIndex].transform.rotation);
        }
    }

}
