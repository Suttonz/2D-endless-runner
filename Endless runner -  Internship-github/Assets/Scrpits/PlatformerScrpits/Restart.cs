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
    //vairable for respawn mushroom
    private List <Vector3> mushroomsPoses = new List<Vector3>();
    [SerializeField] GameObject mushroom;
    private GameObject[] mushrooms;
    //vairable for respawn coin
    private List<Vector3> coinsPoses = new List<Vector3>();
    [SerializeField] GameObject coin;
    private GameObject[] coins;

    //variable for resapwn lifebottle
    private List<Vector3> lifeBottlesPoses = new List<Vector3>();
    [SerializeField] GameObject lifeBottle;
    private GameObject[] lifeBootles;

    private void Start()
    {
        playerStartPos = player_PlatformerRef.transform.position;
        smokeStartPos = smokeRef.transform.position;
        SaveMushroomsPosition();
        SaveCoinsPosition();
        SaveLifeBottlePosition();
    }

    void SaveMushroomsPosition()
    {
        mushrooms = GameObject.FindGameObjectsWithTag("Mushroom");
        if (mushrooms != null)
        {
            //Save all old mushrooms' positions
            for (int i = 0; i < mushrooms.Length; i++)
            {
                mushroomsPoses.Add(new Vector3(mushrooms[i].transform.position.x,
                                               mushrooms[i].transform.position.y,
                                               mushrooms[i].transform.position.z));
            }
        }
    }

    void SaveCoinsPosition()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins != null)
        {
            //Save all old coins' positions
            for (int i = 0; i < coins.Length; i++)
            {
                coinsPoses.Add(new Vector3(coins[i].transform.position.x,
                                           coins[i].transform.position.y,
                                           coins[i].transform.position.z));
            }
        }
    }


    void SaveLifeBottlePosition()
    {
        lifeBootles = GameObject.FindGameObjectsWithTag("LifeBottle");
        if (lifeBootles != null)
        {
            //Save all old coins' positions
            for (int i = 0; i < lifeBootles.Length; i++)
            {
                lifeBottlesPoses.Add(new Vector3(lifeBootles[i].transform.position.x,
                                           lifeBootles[i].transform.position.y,
                                           lifeBootles[i].transform.position.z));
            }
        }
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
        RespawnMushrooms();
        RespawnCoins();
        RespawnLifeBottles();

    }



    void RespawnMushrooms()
    {
        //Delete old mushrooms from last level
        mushrooms = GameObject.FindGameObjectsWithTag("Mushroom");
        if (mushrooms != null)
        {
            for (int i = 0; i < mushrooms.Length; i++)
            {
                Destroy(mushrooms[i].gameObject);
            }
        }

        //Respawn new mushrooms
        for (int i = 0; i < mushroomsPoses.Count; i++)
        {
            Instantiate(mushroom, new Vector3(mushroomsPoses[i].x, mushroomsPoses[i].y, mushroomsPoses[i].z), transform.rotation);
        }
    }

    void RespawnCoins()
    {
        //Delete old coins from last level
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins != null)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                Destroy(coins[i].gameObject);
            }
        }

        //Respawn new mushrooms
        for (int i = 0; i < coinsPoses.Count; i++)
        {
            Instantiate(coin, new Vector3(coinsPoses[i].x, coinsPoses[i].y, coinsPoses[i].z), transform.rotation);
        }
    }

    void RespawnLifeBottles()
    {
        lifeBootles = GameObject.FindGameObjectsWithTag("LifeBottle");
        if (lifeBootles != null)
        {
            for (int i = 0; i < lifeBootles.Length; i++)
            {
                Destroy(lifeBootles[i].gameObject);
            }
        }

        //Respawn new mushrooms
        for (int i = 0; i < lifeBottlesPoses.Count; i++)
        {
            Instantiate(lifeBottle, new Vector3(lifeBottlesPoses[i].x, lifeBottlesPoses[i].y, lifeBottlesPoses[i].z), transform.rotation);
        }
    }

}
