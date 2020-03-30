using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Image soundImageOn;
    private bool pauseOn;
    private bool soundOff;

    public void Pause()
    {
        if (!pauseOn)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.00001f;
            pauseOn = true;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            pauseOn = false;
        }
    }

    public void Sound()
    {
        if (!soundOff)
        {
            AudioListener.volume = 0;
            soundOff = true;
            soundImageOn.enabled = false;
        }
        else
        {
            AudioListener.volume = 1;
            soundOff = false;
            soundImageOn.enabled = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Game.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
