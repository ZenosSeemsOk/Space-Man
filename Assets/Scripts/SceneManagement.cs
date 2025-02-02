using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int currentLevelIndex;
    [SerializeField] private GameObject victoryCard;
    [SerializeField] private GameObject failCard;
    [SerializeField] private Player player;
    public static SceneManagement Instance { get; private set; }
    public IslandSelection[] islands;
    private LevelSelection level;

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        Time.timeScale = 1;
        level = LevelSelection.instance;
        currentLevelIndex = level.levelIndex;
    }

    private void Update()
    {
        InitializeIslandValues();
        ShowCards();
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
        switch (currentLevelIndex)
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

    private void ShowCards()
    {
        if (!player.checkGameOver)
        {
            StartCoroutine(ShowFailCard());
        }
        else if (player.checkGameCompletion)
        {
            StartCoroutine(ShowVictoryCard());
        }
    }

    private IEnumerator ShowFailCard()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        failCard.SetActive(true);
    }

    private IEnumerator ShowVictoryCard()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        victoryCard.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Next()
    {
        level.levelIndex += 1;
        level.totalLevelUnlocked += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
