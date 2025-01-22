using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private SliderJoint2D musicSlider;

    public void Pause()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
