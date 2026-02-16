using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public WizardController wizard;

    private void Start()
    {
        // Initialize UI with starting score
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        // Increase score and update UI
        score += value;
        UpdateScoreText();

        // Trigger wizard animation every 50 points
        if (wizard != null && score % 50 == 0)
        {
            wizard.PlayJump();
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
