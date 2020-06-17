using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource backGroundMusic;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            PauseGame();
            
        }
        
    }


    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        backGroundMusic.Stop();
        Cursor.visible = true;
    }

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        backGroundMusic.Play();
        Cursor.visible = false;
    }
}
