using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int points = 5;

    // Sound played when fruit is collected
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        // Play pickup sound
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        // Add score
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        // Destroy the fruit
        Destroy(gameObject);
    }
}
