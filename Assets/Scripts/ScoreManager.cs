using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public WizardController wizard;

    // Reference to GameManager to access the background music AudioSource
    public GameManager gameManager;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        // Increase score and update UI
        score += value;
        UpdateScoreText();

        // Wizard jumps every 50 points
        if (wizard != null && score % 50 == 0)
        {
            wizard.PlayJump();

            // Increase music pitch to raise tension
            if (gameManager != null && gameManager.musicSource != null)
            {
                gameManager.musicSource.pitch += 0.1f;
            }
        }
    }

    public void ResetScore()
    {
        // Reset score and update UI
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Prevent errors if UI reference is missing
        if (scoreText == null) return;

        scoreText.text = "Score: " + score;
    }
}

