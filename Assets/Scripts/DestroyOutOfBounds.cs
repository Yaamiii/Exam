using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Y position where the object gets destroyed
    private float destroyY = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is below the limit
        if (transform.position.y < destroyY)
        {
            // Destroy the object if it falls too low
            Destroy(gameObject);
        }
    }
}
