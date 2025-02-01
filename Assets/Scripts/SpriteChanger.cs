using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public int level;
    public int value;
    public Sprite[] sprites;
    private IslandSelection island;
    private SceneManagement sceneManager;
    private void Start()
    {
        island = GetComponent<IslandSelection>();
        sceneManager = SceneManagement.Instance;
        level = sceneManager.totalUnlockedLevel;
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
                case 5:
                    island.spriteRenderer.sprite = sprites[5];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 6:
                    island.spriteRenderer.sprite = sprites[6];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 7:
                    island.spriteRenderer.sprite = sprites[7];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 8:
                    island.spriteRenderer.sprite = sprites[8];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 9:
                    island.spriteRenderer.sprite = sprites[9];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 10:
                    island.spriteRenderer.sprite = sprites[10];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 11:
                    island.spriteRenderer.sprite = sprites[11];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 12:
                    island.spriteRenderer.sprite = sprites[12];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 13:
                    island.spriteRenderer.sprite = sprites[13];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 14:
                    island.spriteRenderer.sprite = sprites[14];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 15:
                    island.spriteRenderer.sprite = sprites[15];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 16:
                    island.spriteRenderer.sprite = sprites[16];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 17:
                    island.spriteRenderer.sprite = sprites[17];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 18:
                    island.spriteRenderer.sprite = sprites[18];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 19:
                    island.spriteRenderer.sprite = sprites[19];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
                case 20:
                    island.spriteRenderer.sprite = sprites[20];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
            default:
                    island.spriteRenderer.sprite = sprites[4];
                    Debug.Log($"Sprite changed for {island.islandID}");
                    break;
            }
    }

    private void Update()
    {
        value = island.islandNumberValue;
    }
}