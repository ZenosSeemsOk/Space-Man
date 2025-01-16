using UnityEngine;

public class IslandMove : MonoBehaviour
{
    public float islandMoveSpeed = 5f; // Speed of movement
    public float moveRange = 3f;      // How far left/right the sprite moves

    private float startX;             // Initial X position

    void Start()
    {
        startX = transform.position.x; // Store the starting X position
    }

    void Update()
    {
        // Calculate new position using PingPong for smooth left-right movement
        float newX = startX + Mathf.PingPong(Time.time * islandMoveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
