using System;
using System.Xml.Serialization;
using UnityEngine;

public class IslandSelection : MonoBehaviour
{
    public Transform[] paths;
    public Player player;
    public GameObject otherIsland;
    private new BoxCollider2D collider;
    public int islandID;
    public int value;
    public int islandNumberValue;
    private IslandMove move;
    PauseMenu pauseMenu;
    SettingsMenu settingsMenu;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        move = GetComponent<IslandMove>();
        pauseMenu = PauseMenu.instance;
        settingsMenu = SettingsMenu.instance;

        RandomizeIslandPosition();
    }

    private void OnMouseDown()
    {
        // Tell the player to move to this object's paths
        if (player != null && !pauseMenu.isPaused && !settingsMenu.isPaused)
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

    private void RandomizeIslandPosition()
    {
      
    }
}
