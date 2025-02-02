using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int totalLevelUnlocked = 1;
    [SerializeField] private Button[] levelButtons;
    public int levelIndex;
    public static LevelSelection instance { get; private set; }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        foreach (var button in levelButtons)
        {
            button.interactable = false;
        }

        levelButtons[0].interactable = true;
        LevelUnlockCheck();
    }
    private void LevelUnlockCheck()
    {
        if(totalLevelUnlocked <= 1)
        {
            levelButtons[0].interactable = true;
        }
        else if(totalLevelUnlocked <=2 && totalLevelUnlocked >1)
        {
            levelButtons[1].interactable = true;
        }
        else if(totalLevelUnlocked <=3 && totalLevelUnlocked >2)
        {
            levelButtons[2].interactable = true;
        }
        else if(totalLevelUnlocked <=4 && totalLevelUnlocked >3)
        {
            levelButtons[3].interactable = true;
        }
        else
        {
            Debug.Log("Total level out of bounds");
        }
    }

    public void OpenSubPanel(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                SceneManager.LoadScene("GameScene");
                this.levelIndex = levelIndex;
                break;
            case 2:
                SceneManager.LoadScene("GameScene");
                this.levelIndex = levelIndex;
                break;
            case 3:
                SceneManager.LoadScene("GameScene");
                this.levelIndex = levelIndex;
                break;
            case 4:
                SceneManager.LoadScene("GameScene");
                this.levelIndex = levelIndex;
                break;
        }

    }
}
