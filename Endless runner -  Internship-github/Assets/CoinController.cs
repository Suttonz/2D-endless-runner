using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Player_Platformer player_PlatformerRef;

    private void Start()
    {
        player_PlatformerRef = FindObjectOfType<Player_Platformer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerPlatformer")
        {
            player_PlatformerRef.AddCoin(1);
            Destroy(this.gameObject, 0.2f);
        } 
    }
}
