using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private float minX = -1.5f;
    private float maxX = 1.5f;

    private float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Read Player input (-1..1)
        
        horizontalInput = Input.GetAxis("Horizontal");

        // Move left/right

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Keep the player inside the horizontal bounds
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(
                minX,
                transform.position.y,
                transform.position.z
            );
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(
                maxX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
