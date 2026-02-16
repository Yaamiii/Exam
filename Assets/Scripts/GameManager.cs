using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverText;

    [Header("Restart")]
    public float restartDelay = 2f;

    [Header("Audio")]
    public AudioSource musicSource;

    [Header("References")]
    public SpawnManager spawner;
    public PlayerController player;
    public ScoreManager scoreManager;
    public WizardController wizard;

    private bool isGameOver = false;
    private float restartTimer = 0f;

    private void Start()
    {
        // Hide Game Over text and start background music
        gameOverText.SetActive(false);
        musicSource.Play();
    }

    private void Update()
    {
        // After Game Over, wait and reload the scene
        if (!isGameOver) return;

        restartTimer += Time.deltaTime;

        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TriggerGameOver()
    {
        // Activate Game Over state
        isGameOver = true;
        restartTimer = 0f;

        // Stop music and reset score
        musicSource.Stop();
        scoreManager.ResetScore();

        // Show UI and stop gameplay systems
        gameOverText.SetActive(true);
        spawner.enabled = false;
        player.enabled = false;

        // Play wizard reaction animation
        wizard.PlayNo();
    }
}
