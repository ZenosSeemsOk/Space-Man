using UnityEngine;

public class IslandPause : MonoBehaviour
{
    PauseMenu pauseMenu;
    [SerializeField] IslandSelection islandSelection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu = PauseMenu.instance;
        pauseMenu.onPaused.AddListener(disableScripts);
        pauseMenu.onResumed.AddListener(enableScripts);
    }

    private void disableScripts()
    {
        islandSelection.enabled = false;
        Debug.Log("Disabled");
    }

    private void enableScripts()
    {
        islandSelection.enabled = true;
        Debug.Log("Enabled");
    }
}
