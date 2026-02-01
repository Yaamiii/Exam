using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public float explosionDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
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

        // Destroy bomb
        Destroy(gameObject);

        // Trigger game over
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.TriggerGameOver();
        }
    }
}
