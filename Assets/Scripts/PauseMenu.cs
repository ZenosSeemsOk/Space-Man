using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public UnityEvent onPaused = new UnityEvent();
    public UnityEvent onResumed = new UnityEvent();
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
        onPaused.Invoke();
        Time.timeScale = 0;
        
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        onResumed.Invoke();
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
