using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    [SerializeField] GameObject winMenu;
    [SerializeField] Slider lifeBar;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerPlatformer")
        {
            ActiveWinMenu();
        }
    }

    void ActiveWinMenu()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        lifeBar.gameObject.SetActive(false);
        winMenu.SetActive(true);
    }
}
