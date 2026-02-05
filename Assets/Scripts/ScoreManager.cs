using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public WizardController wizard;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        // Wizard jumps every 50 points
        if (wizard != null && score % 50 == 0)
        {
            wizard.PlayJump();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText == null)
        {
            return;
        }

        scoreText.text = "Score: " + score;
    }
}