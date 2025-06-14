
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private static PlayerMovement instance;
    bool isFacingRight = true;

    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2; //double jump
    int jumpRemaining;

    [Header("GroundCheck")]//check if player is grounded
    public Transform groundCheckPos; 
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    bool isGrounded;

    [Header("Gravity")]
    public float baseGravity = 1f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    [Header("WallCheck")]//check for walls that is infront of the player
    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask wallLayer;

    [Header("WallMovement")]
    public float wallSlideSpeed = 2;
    bool isWallSliding;

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        GroundCheck();
        ProcessWallSlide();
        Gravity();
        Flip();
        // debug
        if (isWallSliding)
        {
            Debug.Log("Player is sliding on the wall.");
       
        }
    }
    private void Gravity()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; // fall increasingly faster
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpRemaining > 0)
        {
            if (context.performed)
            {   //big jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                jumpRemaining--;
            }
            else if (context.canceled)
            {
                //light jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                jumpRemaining--;
            }
        }

    }
    // Detect if player is standing on ground using a box overlap check
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpRemaining = maxJumps;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
 
    }
    // Check if player is touching a wall (for sliding)
    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, wallLayer);
    }
    // Flip player sprite horizontally when changing movement direction
    private void Flip()
    {
        if(isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    private void ProcessWallSlide()
    {
        //Not grounded & On a wall & movement != 0
        if (!isGrounded & WallCheck() & horizontalMovement != 0)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
        }
        else
        {
            isWallSliding = false;
        }

    }
    // Visualize ground and wall check areas
    private void OnDrawGizmosSelected()
    {
        //ground check visual
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
        //wall chedck visual
        Gizmos.color = Color.blue;
        
        // Save current Gizmos matrix
        Matrix4x4 oldMatrix = Gizmos.matrix;

        // Apply transform from WallCheck
        Gizmos.matrix = Matrix4x4.TRS(wallCheckPos.position, wallCheckPos.rotation, Vector3.one);

        //draw the cube  
        Gizmos.DrawWireCube(Vector3.zero, wallCheckSize);

        // Restore original Gizmos matrix
        Gizmos.matrix = oldMatrix;
    }


}
