using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public int level;
    public Sprite[] sprites;
    private IslandSelection island;
    private SceneManagement sceneManager;

    private void Start()
    {
        sceneManager = SceneManagement.Instance;
        level = sceneManager.totalUnlockedLevel;
        island = GetComponent<IslandSelection>();
        if (level == 1)
        {
            switch (island.islandNumberValue)
            {
                case 0:
                    island.spriteRenderer.sprite = sprites[0];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 1:
                    island.spriteRenderer.sprite = sprites[1];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 2:
                    island.spriteRenderer.sprite = sprites[2];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 3:
                    island.spriteRenderer.sprite = sprites[3];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 4:
                    island.spriteRenderer.sprite = sprites[4];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                default:
                    island.spriteRenderer.sprite = sprites[1];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                
              
            }
        }
    }
}