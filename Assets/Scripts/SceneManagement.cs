using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public int totalUnlockedLevel;
    public static SceneManagement Instance { get; private set; }
    public IslandSelection[] islands;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        if (totalUnlockedLevel == 1)
        {
            islands[0].islandNumberValue = 3;
            islands[1].islandNumberValue = 3;
            islands[2].islandNumberValue = 2;
            islands[3].islandNumberValue = 1; 

            islands[4].islandNumberValue = 7;
            islands[5].islandNumberValue = 9;
            islands[6].islandNumberValue = 5;
            islands[7].islandNumberValue = 8; 
                
            Debug.Log(islands[0].islandNumberValue + islands[1].islandNumberValue);
        }
        else if (totalUnlockedLevel == 2)
        {

        }
        else if (totalUnlockedLevel == 3)
        {

        }
        else
        {
            Debug.Log("Level index exceeds boundary");
        }
    }

    private void ChangeSprite()
    {

    }



}