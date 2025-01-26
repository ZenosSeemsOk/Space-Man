using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void MenuPlay()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
