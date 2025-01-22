using System;
using System.Xml.Serialization;
using UnityEngine;

public class IslandSelection : MonoBehaviour
{
    public Transform[] paths; // Paths for this clickable object
    public Player player; // Reference to the Player script
    public GameObject otherIsland;
    private new BoxCollider2D collider; // Use 'new' keyword to hide inherited member
    public int islandID;
    public int value;
    private IslandMove move;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
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
        GameOver();
        if (otherIsland != null)
        {
            IslandSelection checker = otherIsland.GetComponent<IslandSelection>();
            if (checker != null && checker.value == 1)
            {
                move.enabled = false;
                //Debug.Log("The other island is selected");

            }
        }
    }

    private void GameOver()
    {
        collider.enabled = player.checkGameOver;
    }

    
}
