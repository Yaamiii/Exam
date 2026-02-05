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
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (musicSource != null)
        {
            musicSource.Play();
        }
    }

    private void Update()
    {
        if (!isGameOver) return;

        restartTimer += Time.deltaTime;

        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        restartTimer = 0f;

        if (musicSource != null)
        {
            musicSource.Stop();
        }

        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        if (spawner != null)
        {
            spawner.enabled = false;
        }

        if (player != null)
        {
            player.enabled = false;
        }

        if (wizard != null)
        {
            wizard.PlayNo();
        }
    }
}