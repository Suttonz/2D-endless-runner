using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void LoadEndlessRunner()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void LoadPlatformer()
    {
        SceneManager.LoadScene("Platformer");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
