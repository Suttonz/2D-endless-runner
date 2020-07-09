using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Player_Platformer player_PlatformerRef;
    private Vector3 player_PlatformerPreviousPosition;
    private float Ypos;
    private bool gameStarted;

    void Start()
    {
      
      player_PlatformerPreviousPosition = player_PlatformerRef.transform.position;
 
    }

    
    void Update()
    {
        FollowPlayerFunc();
    }

    void FollowPlayerFunc()
    {
        if(player_PlatformerRef.transform.position.y > this.transform.position.y)
        {
            Ypos = player_PlatformerRef.transform.position.y;
        }
        else
        {
            Ypos = this.transform.position.y;
        }
         
        this.transform.position = new Vector3(player_PlatformerRef.transform.position.x,Ypos);
        player_PlatformerPreviousPosition = player_PlatformerRef.transform.position;
    }
}
