using UnityEngine;

// This script handles controlling the player movement
public class PlayerController : MonoBehaviour
{
    // A reference to the Sprite Renderer component, holding the player image
    public SpriteRenderer playerImage;
    public float moveSpeed = 5f;
    public float jumpForce = 7f; // Jump force variable

    private Camera mainCamera;
    private Rigidbody2D rb; // Rigidbody for physics-based movement
    private bool isGrounded; // Boolean to check if player is on the ground

    private float playerHalfWidth;
    private float rightScreenEdge;
    private float leftScreenEdge;
    private float maxPosX;
    private float minPosX;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        SetupScreenEdges();
    }

    void Update()
    {
        float inputHl = Input.GetAxis("Horizontal");
        Vector2 currentPos = gameObject.transform.position;

        if ((inputHl > 0) && (currentPos.x <= maxPosX))
        {
            Vector2 newPos = currentPos + Vector2.right;
            gameObject.transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
        else if (inputHl < 0 && (currentPos.x >= minPosX))
        {
            Vector2 newPos = currentPos + Vector2.left;
            gameObject.transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }

        // Jump function
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void SetupScreenEdges()
    {
        playerHalfWidth = playerImage.bounds.size.x * 0.5f;
        rightScreenEdge = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, 0)).x;
        leftScreenEdge = mainCamera.ScreenToWorldPoint(Vector2.zero).x;
        maxPosX = rightScreenEdge - playerHalfWidth;
        minPosX = leftScreenEdge + playerHalfWidth;
    }

    // Detect collision with ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
