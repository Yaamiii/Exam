using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float explosionDuration = 2f;

    private GameManager gameManager;

    private void Start()
    {
        // Get reference to GameManager in the scene
        GameObject managerObject = GameObject.Find("GameManager");

        if (managerObject != null)
        {
            gameManager = managerObject.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react to the Player
        if (!other.CompareTag("Player")) return;

        // Spawn explosion effect
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(explosion, explosionDuration);
        }

        // Play explosion sound
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // Destroy the bomb object
        Destroy(gameObject);

        // Trigger Game Over state
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
