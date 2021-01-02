using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed = 500f;
    public float maxSpeed = 5f;
    public float playerBounds = 10f;
    
    private Rigidbody2D rb2d;
    private bool jump = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0f, 1f);  // Auto jump at start to wait for user
    }

    private void Jump() { jump = true; }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            // Also checks if user presses W once 
            if (IsInvoking("Jump"))
            {
                CancelInvoke("Jump"); // Stop autojump at start when users interacts
                FindObjectOfType<GameManager>().StartGame();
            }

            FindObjectOfType<AudioManager>().Play("PlayerJump");
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
            jump = false;
        }

        // Restrict speed
        if (rb2d.velocity.magnitude >= maxSpeed)
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);

        // Check if player is out of bounds
        if (rb2d.position.y < -playerBounds || rb2d.position.y > playerBounds)
            FindObjectOfType<GameManager>().EndGame();
    }
}
