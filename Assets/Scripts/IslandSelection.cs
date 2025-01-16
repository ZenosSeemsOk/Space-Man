using UnityEngine;

public class IslandSelection : MonoBehaviour
{
    public Transform[] paths; // Paths for this clickable object
    public Player player; // Reference to the Player script
    public GameObject otherIsland;
    public int islandID;
    public int value;
    private IslandMove move;

    private void Start()
    {
        move = GetComponent<IslandMove>();
    }

    private void OnMouseDown()
    {
        // Tell the player to move to this object's paths
        if (player != null)
        {
            player.MoveToPaths(paths);
        }
    }

    private void Update()
    {
        if (otherIsland != null)
        {
            IslandSelection checker = otherIsland.GetComponent<IslandSelection>();
            if (checker != null && checker.value == 1)
            {
                move.enabled = false;
                Debug.Log("The other island is selected");

            }
        }
    }
}
