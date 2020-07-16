using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private Player_Platformer player_PlatformerRef;

    private void Start()
    {
        player_PlatformerRef = FindObjectOfType<Player_Platformer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerPlatformer")
        {
            player_PlatformerRef.ReduceLife(10f);
            Destroy(this.gameObject);
        }
    }
}
