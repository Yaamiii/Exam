using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fruitPrefab;

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
        // Keeps track of time so fruits don't spawn every frame
        timer += Time.deltaTime;

        // Spawn an object when the interval is reached
        if (timer >= spawnInterval)
        {
            SpawnFruit();
            timer = 0f;
        }
    }
    void SpawnFruit()
    {
        // Choose a random position within the horizontal range
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnXRange, spawnXRange),
            spawnYPosition,
            0f
        );
        
        // Spawn the fruit prefab at the chosen position
        Instantiate(fruitPrefab, spawnPosition, fruitPrefab.transform.rotation);
    }
}
