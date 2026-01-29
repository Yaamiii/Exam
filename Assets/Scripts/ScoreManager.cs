using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // Current game score
    public int score = 0;

    public void AddScore(int value)
    {
        // Increase the score
        score += value;

        // Show score in the Console
        Debug.Log("Score: " + score);
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
