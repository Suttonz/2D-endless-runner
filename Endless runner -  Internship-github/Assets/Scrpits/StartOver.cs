using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOver : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    [SerializeField] Player playerRef;
    [SerializeField] GameObject tileGenerator;
    private Vector3 tileGeneratorRespawnPoint;
    private Vector3 playerRespawnPoint;
    private GameObject[] leftOverTiles;
    [SerializeField] CameraMovement cameraRef;
    private Vector3 tile1RspawnPoint;
    [SerializeField] TileGenerator tileGeneratorRef;
    private GameObject[] leftOverEnergies;
    [SerializeField] EnergyController energyControllerRef;
    [SerializeField] Slider energyBar;
    [SerializeField] AudioSource backgroudMusic;
    [SerializeField] Text longestDistanceText;

    void Start()
    {
        playerRespawnPoint = playerRef.transform.position;
        tileGeneratorRespawnPoint = tileGenerator.transform.position;
        
    }


    void Update()
    {

        
    }


    public void Restart()
    {
        
        
            deathMenu.SetActive(false);
            Cursor.visible = false;

            tileGenerator.transform.position = tileGeneratorRespawnPoint;
            playerRef.transform.position = playerRespawnPoint;
            //Destory tiles didn't get time to be destoried from last round of the game
            leftOverTiles = GameObject.FindGameObjectsWithTag("Ground");
            for (int i = 0; i < leftOverTiles.Length; i++)
            {
                Destroy(leftOverTiles[i].gameObject);
            }
            leftOverEnergies = GameObject.FindGameObjectsWithTag("Energy");
            for (int i = 0; i < leftOverEnergies.Length; i++)
            {
                Destroy(leftOverEnergies[i].gameObject);
            }

            cameraRef.GetComponent<Camera>().orthographicSize = 5f;
            playerRef.runSpeed = 5f;
            tileGeneratorRef.ToogleIsUsable(true);
            //put player energy and UI(energyBar) all back to 100
            energyControllerRef.energy = 100f;
            energyBar.value = 100f;
            Time.timeScale = 1f;
            backgroudMusic.Play();
            longestDistanceText.text = PlayerPrefs.GetFloat("LongestDistance").ToString("f0");
            //Reset player's power off to be false
            playerRef.ToogleCanhurt(true);
            playerRef.TooglePlayerTransparency(1f);
            


    }

}
