using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform component to track their position
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask groundLayer; //identify what counts as ground for collision detection

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    public int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// Get the Rigidbody2D component attached to this enemy GameObject
    }

    void Update()
    {
        //Check if the enemy is grounded by casting a ray downwards
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Player direction
        // Calculate the horizontal direction towards the player
        // Mathf.Sign returns -1 if player is to the left, +1 if to the right
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        // player above detection
        // Check if the player is above the enemy within 5 units using a raycast upwards
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 5f, 1 << player.gameObject.layer);

        if (isGrounded)
        {
            // chase player
            // Move the enemy horizontally towards the player at chaseSpeed
            rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);

            //Detect if there is ground directly in front of the enemy in the direction it is moving
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

            //Detect if there is a gap ahead by casting a ray downward slightly in front of the enemy
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0), Vector2.down, 2f, groundLayer);

            //Detect if there is a platform above the enemy within 3 units
            RaycastHit2D platFormAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);

            if (!groundInFront.collider && !gapAhead.collider)
            {
                shouldJump = true;
            }
            else if (isPlayerAbove && platFormAbove.collider)
            {
                shouldJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 jumpDirection = direction * jumpForce;
            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }
}
