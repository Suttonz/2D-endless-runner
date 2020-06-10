using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{

    private Player playerRef;

    private void Start()
    {
        playerRef = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "IsPlayer")
        {
            playerRef.DecreaseEnergy();
        }
    }

}
