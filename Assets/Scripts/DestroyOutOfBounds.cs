using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float destroyY = -10f;

    private void Update()
    {
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
