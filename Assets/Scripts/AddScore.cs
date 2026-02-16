using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int points = 5;
    public AudioClip collectSound;

    private ScoreManager scoreManager;

    private void Start()
    {
        // Get reference to ScoreManager in the scene
        scoreManager = GameObject.Find("ScoreManager")
                                 .GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react if the Player enters the trigger
        if (!other.CompareTag("Player")) return;

        // Add points to the score
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        // Play collect sound
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Remove the collected object
        Destroy(gameObject);
    }
}
