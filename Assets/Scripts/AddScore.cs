using UnityEngine;

public class Add : MonoBehaviour
{
    // Points given when this object is collected
    public int points = 5;

    private void OnTriggerEnter(Collider other)
    {
        // Find the ScoreManager in the scene
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        // Add points if ScoreManager exists
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        // Destroy this object after being collected
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
