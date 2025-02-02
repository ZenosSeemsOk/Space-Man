using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public int level = 2;
    public Sprite[] sprites;
    private IslandSelection island;
    private SceneManagement sceneManager;

    private void Start()
    {
        island = GetComponent<IslandSelection>();
        sceneManager = SceneManagement.Instance;

    }


    private void Update()
    {
        level = sceneManager.currentLevelIndex;

        // Ensure the islandNumberValue is within the bounds of the sprites array
        if (island.islandNumberValue >= 0 && island.islandNumberValue < sprites.Length)
        {
            island.spriteRenderer.sprite = sprites[island.islandNumberValue];
        }
        else
        {
            // Default to a specific sprite if the index is out of bounds
            island.spriteRenderer.sprite = sprites[4]; // Default sprite
        }

        Debug.Log($"Sprite changed for {island.islandID}");
        // If you need to debug the islandNumberValue, you can log it directly
        Debug.Log($"Current island number value: {island.islandNumberValue}");
    }
}