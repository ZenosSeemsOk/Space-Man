using UnityEngine;

public class IslandSelection : MonoBehaviour
{
    public Transform[] paths; // Paths for this clickable object
    public Player player; // Reference to the Player script
    public int value;

    private void OnMouseDown()
    {
        // Tell the player to move to this object's paths
        if (player != null)
        {
            player.MoveToPaths(paths);
        }
    }
}
