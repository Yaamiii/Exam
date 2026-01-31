using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        // Spawn explosion effect at bomb position
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, explosionDuration);
        }

        // Remove bomb
        Destroy(gameObject);

        // Trigger game over
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.TriggerGameOver();
        }
    }
}
