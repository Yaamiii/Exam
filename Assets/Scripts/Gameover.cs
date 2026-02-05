using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float explosionDuration = 2f;

    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager automatically (needed for spawned objects)
        GameObject managerObject = GameObject.Find("GameManager");

        if (managerObject != null)
        {
            gameManager = managerObject.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react to the player
        if (!other.CompareTag("Player")) return;

        // Spawn explosion
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(explosion, explosionDuration);
        }

        // Play sound
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // Destroy the bomb
        Destroy(gameObject);

        // Trigger Game Over
        if (gameManager != null)
        {
            gameManager.TriggerGameOver();
        }
        else
        {
            Debug.LogWarning("GameManager not found!");
        }
    }
}