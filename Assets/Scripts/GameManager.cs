using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public float restartDelay = 2f;

    // Background music
    public AudioSource musicSource;

    private bool isGameOver = false;
    private float restartTimer = 0f;

    void Start()
    {
        // Hide Game Over text at start
        gameOverText.SetActive(false);

        // Start background music
        if (musicSource != null)
        {
            musicSource.Play();
        }
    }

    void Update()
    {
        // After game over, wait and restart the scene
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
        isGameOver = true;
        restartTimer = 0f;

        // Stop background music
        if (musicSource != null)
        {
            musicSource.Stop();
        }

        // Reset score
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        // Show Game Over UI
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

        // Wizard reaction on game over
        WizardController wizard = FindFirstObjectByType<WizardController>();
        if (wizard != null)
        {
            wizard.PlayNo();
        }

    }

}
