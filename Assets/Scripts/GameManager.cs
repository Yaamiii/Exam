using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public float restartDelay = 2f;

    private bool isGameOver;
    private float restartTimer;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If game over, count time using real time (not affected by timeScale)
        if (isGameOver)
        {
            restartTimer += Time.unscaledDeltaTime;

            if (restartTimer >= restartDelay)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        restartTimer = 0f;

        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.score = 0;
            Debug.Log("Score: " + scoreManager.score);
        }

        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}
