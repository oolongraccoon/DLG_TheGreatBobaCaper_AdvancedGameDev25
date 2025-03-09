using UnityEngine;

// This script handles controlling the player movement
public class PlayerController : MonoBehaviour
{
    // A reference to the Sprite Renderer component, holding the player image
    public SpriteRenderer playerImage;

    public float moveSpeed = 5f;

    // Reference to the main camera that we see the game world through
    private Camera mainCamera;

    // Half the width and height of the player's character image
    private float playerHalfWidth;
    private float playerHalfHeight;

    // The game screen's edges, used to block the player from going outside screen boundaries
    private float rightScreenEdge;
    private float leftScreenEdge;
    private float topScreenEdge;
    private float bottomScreenEdge;

    private float maxPosX;
    private float minPosX;
    private float maxPosY;
    private float minPosY;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera reference from the Camera class
        mainCamera = Camera.main;
        SetupScreenEdges();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal and vertical movement
        float inputHl = Input.GetAxis("Horizontal");
        float inputVl = Input.GetAxis("Vertical");

        // Save the player's position at this moment in time
        Vector2 currentPos = gameObject.transform.position;

        // Calculate the new position based on input, factoring in speed and frame time
        Vector2 newPos = currentPos + new Vector2(inputHl, inputVl) * moveSpeed * Time.deltaTime;

        // Clamp the new position to keep the player within screen boundaries
        newPos.x = Mathf.Clamp(newPos.x, minPosX, maxPosX);
        newPos.y = Mathf.Clamp(newPos.y, minPosY, maxPosY);

        // Move the player to the new position
        gameObject.transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
    }

    void SetupScreenEdges()
    {
        // Get the player's half width and half height
        playerHalfWidth = playerImage.bounds.size.x * 0.5f;
        playerHalfHeight = playerImage.bounds.size.y * 0.5f;

        // Get the screen edges in world coordinates
        rightScreenEdge = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, 0)).x;
        leftScreenEdge = mainCamera.ScreenToWorldPoint(Vector2.zero).x;
        topScreenEdge = mainCamera.ScreenToWorldPoint(new Vector2(0, mainCamera.pixelHeight)).y;
        bottomScreenEdge = mainCamera.ScreenToWorldPoint(Vector2.zero).y;

        // Calculate the maximum and minimum possible values for the player's position
        maxPosX = rightScreenEdge - playerHalfWidth;
        minPosX = leftScreenEdge + playerHalfWidth;
        maxPosY = topScreenEdge - playerHalfHeight;
        minPosY = bottomScreenEdge + playerHalfHeight;
    }
}
