using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int points = 5;
    public AudioClip collectSound;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager")
                                 .GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Destroy(gameObject);
    }
}