using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public GameObject pinPrefab; // Reference to the Pin prefab
    public Transform shootPoint; // The point where the pin will spawn

    private Rigidbody2D rb;
    private Vector2 movement;

    private Vector2 screenBounds;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Calculate screen bounds based on camera view
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // Get horizontal and vertical input (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Store movement direction
        movement = new Vector2(moveX, moveY).normalized;

        // Check for Fire1 input (usually Space key)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootPin();
        }
    }

    void FixedUpdate()
    {
        // Move the player by setting the velocity
        rb.velocity = movement * moveSpeed;

        // Clamp the player's position within the screen bounds
        Vector3 clampedPosition = transform.position;

        // Calculate the boundary limits
        clampedPosition.x = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        clampedPosition.y = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);

        // Apply the clamped position
        transform.position = clampedPosition;
    }

    // Method to shoot a pin
    void ShootPin()
    {
        if (pinPrefab != null && shootPoint != null)
        {
            // Instantiate the pin at the shoot point's position and rotation
            GameObject pin = Instantiate(pinPrefab, shootPoint.position, Quaternion.identity);

            // Start the pin's movement (you should have a script attached to the pin that handles its movement)
            PinMovement pinMovement = pin.GetComponent<PinMovement>();
            if (pinMovement != null)
            {
                pinMovement.StartMoving(); // Assuming there's a method to start the pin's movement
            }
        }
    }
}
