using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int points = 5;
    public AudioClip collectSound;

    private ScoreManager scoreManager;
    private JarManager jarManager;

    private void Start()
    {
        // Get reference to ScoreManager in the scene
        GameObject scoreManagerObject = GameObject.Find("ScoreManager");
        if (scoreManagerObject != null)
        {
            scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        }

        // Get reference to JarManager in the scene
        GameObject jarManagerObject = GameObject.Find("JarManager");
        if (jarManagerObject != null)
        {
            jarManager = jarManagerObject.GetComponent<JarManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react if the Player enters the trigger
        if (!other.CompareTag("Player")) return;

        // Add points
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        // Show one jar for each collected fruit
        if (jarManager != null)
        {
            jarManager.ShowNextJar();
        }

        // Play collect sound
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        // Destroy collected object
        Destroy(gameObject);
    }
}

