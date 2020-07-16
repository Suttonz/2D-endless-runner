using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    private Vector3 playerStartPos;
    [SerializeField] Player_Platformer player_PlatformerRef;
    [SerializeField] Slider lifeBar;
    [SerializeField] FollowPlayer followPlayerRef;
    [SerializeField] Camera cameraRef;
    private Vector3 smokeStartPos;
    [SerializeField] SmokeController smokeRef;
    private void Start()
    {
        playerStartPos = player_PlatformerRef.transform.position;
        smokeStartPos = smokeRef.transform.position;
        
    }

    public void RestartFuc()
    {
        deathMenu.SetActive(false);
        Cursor.visible = false;
        lifeBar.gameObject.SetActive(true);
        cameraRef.transform.rotation = Quaternion.Euler(0, 0, 0);
        player_PlatformerRef.transform.position = playerStartPos;
        smokeRef.transform.position = smokeStartPos;
        followPlayerRef.transform.position = playerStartPos;
        player_PlatformerRef.SetLife(100f);
        lifeBar.value = 100f;
        Time.timeScale = 1f;


    }
}
