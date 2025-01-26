using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    public bool isPaused = false;
    public static SettingsMenu instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Pause()
    {
        settingsMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;

    }
    public void Resume()
    {
        settingsMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
}
