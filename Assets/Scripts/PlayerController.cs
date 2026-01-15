using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    public float horizontalInput;
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
    }
}
