using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Current game score (starts at 0)
    public int score = 0;

    // Reference to the UI text that shows the score on screen
    // Drag the ScoreText (TMP) object into this field in the Inspector
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // At the start of the game, show the initial score on screen
        UpdateScoreText();
    }

    // Called when the player collects a fruit
    public void AddScore(int value)
    {
        // Increase the score by the amount passed in (example: +5)
        score += value;

        // Update the UI text so the player sees the new score immediately
        UpdateScoreText();
    }

    // Called when the game ends (bomb collected)
    public void ResetScore()
    {
        // Reset score back to 0
        score = 0;

        // Update the UI text so it immediately shows "Score: 0"
        UpdateScoreText();
    }

    // Updates the text shown on the screen
    void UpdateScoreText()
    {
        // Safety check: if the text is not assigned, do nothing
        // (This avoids errors if you forgot to link it in the Inspector)
        if (scoreText == null)
        {
            return;
        }

        // Show the score in a simple format
        scoreText.text = "Score: " + score;
    }
}
