using UnityEngine;

public class Gameover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        // Remove bomb immediately
        Destroy(gameObject);

        if (gameManager != null)
        {
            gameManager.TriggerGameOver();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
