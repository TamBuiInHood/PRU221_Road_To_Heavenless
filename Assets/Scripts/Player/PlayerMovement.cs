using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement speed of the player
    [SerializeField] private float speed;

    // Force applied when the player jumps
    [SerializeField] private float jumpForce;

    // Reference to the Rigidbody2D component attached to the player
    private Rigidbody2D body;

    // Reference to the Animator component attached to the player
    private Animator anim;

    // Flag to check if the player is grounded
    private bool grounded;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the Rigidbody2D component attached to the player
        body = GetComponent<Rigidbody2D>();

        // Get the Animator component attached to the player
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Move the player horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the player's sprite based on the direction of movement
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(5, 5, 1); // Corrected z scale to 1
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 1); // Corrected z scale to 1

        // Check for jump input and whether the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        // Set animator parameters
        anim.SetBool("run", Mathf.Abs(horizontalInput) > 0.01f); // Use Mathf.Abs for comparing floating point numbers
        anim.SetBool("grounded", grounded);
    }

    // Method to handle player jumps
    private void Jump()
    {
        // Apply vertical force to the player for jumping
        body.velocity = new Vector2(body.velocity.x, jumpForce);

        // Trigger the "jump" animation
        anim.SetTrigger("jump");

        // Set grounded to false when jumping
        grounded = false;
    }

    // Called when the player collides with another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground")) // Use CompareTag for better performance
            anim.SetTrigger("grounded");
        grounded = true; // Update grounded state
    }

    // Called when the player stops colliding with another collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player stops colliding with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground")) // Use CompareTag for better performance
            grounded = false; // Update grounded state
    }
}