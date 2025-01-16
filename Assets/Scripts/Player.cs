using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform[] paths; // Array of waypoints the player will follow
    [SerializeField] private Transform groundDetector;
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;
    private int currentPathIndex = 0;
    private bool isMoving = false;

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
        isMoving = false;
    }

    public void StartMoving()
    {
        // Begin movement along the path
        if (paths.Length > 0)
        {
            currentPathIndex = 0; // Start from the first waypoint
            EnableKinematicRigidbody(); // Switch to kinematic while moving
            isMoving = true;
        }
    }

    public void MoveToPaths(Transform[] newPaths)
    {
        if (newPaths != null && newPaths.Length > 0)
        {
            paths = newPaths;
            currentPathIndex = 0;
            EnableKinematicRigidbody(); // Switch to kinematic when paths are set
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving && paths.Length > 0)
        {
            Transform target = paths[currentPathIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentPathIndex++;
                if (currentPathIndex >= paths.Length)
                {
                    isMoving = false;
                    EnableDynamicRigidbody(); // Switch back to dynamic after movement
                    GroundDetection();
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
            // You can now interact with the hit object
            // Example: Check if it's a specific tag
            if (island.value == 1)
            {
                Debug.Log("Correct Island");
            }
            else if (island.value == 2)
            {
                Debug.Log("Incorrect Island");
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
}
