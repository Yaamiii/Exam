using UnityEngine;
using UnityEngine.SceneManagement;

public class JarManager : MonoBehaviour
{
    public GameObject[] jars;
    public GameObject youWonText;

    public SpawnManager spawner;
    public PlayerController player;

    public KeyCode restartKey = KeyCode.Space;

    private int jarsShown = 0;
    private bool hasWon = false;

    private void Start()
    {
        // Hide win text
        if (youWonText != null)
        {
            youWonText.SetActive(false);
        }

        // Hide all jars at start
        for (int i = 0; i < jars.Length; i++)
        {
            if (jars[i] != null)
            {
                jars[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        // After winning, press Space to restart
        if (hasWon && Input.GetKeyDown(restartKey))
        {
            RestartGame();
        }
    }

    public void ShowNextJar()
    {
        if (hasWon) return;

        if (jarsShown < jars.Length)
        {
            jars[jarsShown].SetActive(true);
            jarsShown++;
        }

        if (jarsShown >= jars.Length)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        hasWon = true;

        if (youWonText != null)
        {
            youWonText.SetActive(true);
        }

        if (spawner != null)
        {
            spawner.enabled = false;
        }

        if (player != null)
        {
            player.enabled = false;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


