using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // Get input
        horizontalInput = Input.GetAxis("Horizontal"); // Left/Right (A/D or Arrow keys)
        verticalInput = Input.GetAxis("Vertical");     // Up/Down (W/S or Arrow keys)

        // Move the player in 2D space (X, Y)
        transform.Translate(new Vector2(horizontalInput, verticalInput) * Time.deltaTime * speed);
    }
}
