using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{

    [SerializeField] GameObject creditsMenu, startMenu;

    public void OpenStartMenu()
    {
        creditsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void OpenCreditsMenu()
    {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true); 

    }
    public void LoadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void EndGame() {
        Application.Quit();      
    }
}
