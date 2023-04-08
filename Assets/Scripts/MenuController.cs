using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{

    public static bool gameIsPaused;

    public GameObject pauseMenu;

    public GameObject optionsMenu;

    public GameObject panel;

    public AudioSource theme; 


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))  {
            if (gameIsPaused) {
                Resume();  
            } else  {
                Pause(); 
            }

        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false; 
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true; 
    }

    public void LoadScene() {
        SceneManager.LoadScene("StartMenu"); 

    } 

    public void ShowOptions() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        gameIsPaused = true;  
    }

    public void SetMusic(bool isMusic) {
        theme.mute = !isMusic; 
    }
}
