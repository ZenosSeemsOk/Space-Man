using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public int totalUnlockedLevel;
    public static SceneManagement Instance { get; private set; }
    public IslandSelection[] islands;

    private void Awake()
    {
        ManageSingleton();

        InitializeIslandValues();
    }

    private void ManageSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeIslandValues()
    {
        switch (totalUnlockedLevel)
        {
            case 1:
                SetIslandValues(new int[] { 4, 3, 2, 1, 7, 9, 5, 8 });
                break;
            case 2:
                SetIslandValues(new int[] { 8, 7, 6, 5, 2, 4, 5, 8 });
                break;
            case 3:
                SetIslandValues(new int[] { 12, 11, 10, 9, 7, 9, 5, 8 });
                break;
            case 4:
                SetIslandValues(new int[] { 17, 16, 15, 14, 7, 9, 5, 8 });
                break;
            default:
                Debug.LogError("Level index exceeds boundary");
                break;
        }
    }

    private void SetIslandValues(int[] values)
    {
        for (int i = 0; i < islands.Length; i++)
        {
            if (i < values.Length)
            {
                islands[i].islandNumberValue = values[i];
            }
            else
            {
                Debug.LogError("Island index out of range of provided values");
            }
        }
    }
}
