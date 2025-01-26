using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused = false;
    public static PauseMenu instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused=false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1;
    }
}
