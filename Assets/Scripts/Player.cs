using UnityEngine;
using System;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    private Transform[] paths; // Array of waypoints the player will follow
    [SerializeField] private Transform groundDetector;
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;
    private int currentPathIndex = 0;
    public bool checkGameOver;
    private bool isMoving = false;
    private bool canInteract = true; // Controls whether the player can interact with sprites
    public bool hasTakenOff;
    public bool isGliding;
    public bool isLanding;

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Ensure Rigidbody is dynamic at the start
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        // Initially, the player is not moving
        checkGameOver = true;
        isMoving = false;
        canInteract = true;
    }

    public void StartMoving()
    {
        // Only allow movement if the player is on the ground and not already moving
        if (canInteract && IsOnGround() && paths.Length > 0 && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            currentPathIndex = 0; // Start from the first waypoint
            EnableKinematicRigidbody(); // Switch to kinematic while moving
            isMoving = true;
            canInteract = false; // Disable further interactions until movement is complete
            hasTakenOff = true; // Trigger takeoff animation
        }
        else
        {
            Debug.Log("Cannot move: Either not on ground or already moving.");
        }
    }

    public void MoveToPaths(Transform[] newPaths)
    {
        if (canInteract && newPaths != null && newPaths.Length > 0)
        {
            hasTakenOff = true; // Trigger takeoff animation
            paths = newPaths;

            // Only allow setting paths if the player is on the ground and not already moving
            if (IsOnGround())
            {
                currentPathIndex = 0;
                EnableKinematicRigidbody(); // Switch to kinematic when paths are set
                isMoving = true;
                canInteract = false; // Disable further interactions until movement is complete
            }
            else if (!IsOnGround())
            {
                Debug.Log("Cannot set paths: Player is not on the ground.");
            }
        }
        else
        {
            Debug.Log("Cannot interact: Player is already moving.");
        }
    }

    private void Update()
    {
        if (isMoving && paths.Length > 0)
        {
            isGliding = true; // Enable gliding animation
            Transform target = paths[currentPathIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentPathIndex++;
                if (currentPathIndex >= paths.Length)
                {
                    // Movement complete
                    isGliding = false; // Disable gliding animation
                    isLanding = false; // Reset landing state
                    isMoving = false;
                    canInteract = true; // Allow interactions again
                    EnableDynamicRigidbody(); // Switch back to dynamic
                    GroundDetection();
                }
                else if (currentPathIndex == paths.Length - 1)
                {
                    // Trigger landing animation
                    isGliding = false; // Disable gliding animation
                    isLanding = true; // Enable landing animation
                }
            }
        }
    }

    private void GroundDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, 2f);
        // Check if the raycast hit something
        if (hit.collider != null)
        {
            // Access the GameObject that was hit
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Raycast hit: " + hitObject.name);

            IslandSelection island = hitObject.GetComponent<IslandSelection>();
            if (island != null)
            {
                island.value = 1;
                if (island.islandID == 1)
                {
                    Debug.Log("Correct Island");
                }
                else
                {
                    Debug.Log("Incorrect Island");
                    checkGameOver = false;
                }
            }

            // Check if the object has the PingPongMovement script and disable it
            IslandMove islandMove = hitObject.GetComponent<IslandMove>();
            if (islandMove != null)
            {
                islandMove.enabled = false; // Disable the PingPong movement
                Debug.Log("PingPongMovement disabled on " + hitObject.name);
            }
        }
        else
        {
            Debug.Log("No object detected.");
        }
    }

    public bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, 0.5f);
        return hit.collider != null && hit.collider.CompareTag("Ground");
    }

    private void EnableDynamicRigidbody()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void EnableKinematicRigidbody()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

}
