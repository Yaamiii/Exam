using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public float restartDelay = 2f;

    private bool isGameOver = false;
    private float restartTimer = 0f;

    void Start()
    {
        // Hide Game Over text at the beginning
        gameOverText.SetActive(false);
    }

    void Update()
    {
        // If the game is over, count time and restart the scene
        if (isGameOver)
        {
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void TriggerGameOver()
    {
        // Mark the game as over
        isGameOver = true;
        restartTimer = 0f;

        // Reset the score
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        // Show Game Over text
        gameOverText.SetActive(true);

        // Stop gameplay scripts
        SpawnManager spawner = FindFirstObjectByType<SpawnManager>();
        if (spawner != null)
        {
            spawner.enabled = false;
        }

        PlayerController player = FindFirstObjectByType<PlayerController>();
        if (player != null)
        {
            player.enabled = false;
        }
    }
}
