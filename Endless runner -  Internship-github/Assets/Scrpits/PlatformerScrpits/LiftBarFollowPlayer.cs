using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBarFollowPlayer : MonoBehaviour
{
    [SerializeField] Player_Platformer player_PlatformerRef;
    private Vector3 lifeBarOffset;

    void Start()
    {
        lifeBarOffset = new Vector3(0.05f, 0.55f, 0);
        this.transform.position = Camera.main.WorldToScreenPoint(player_PlatformerRef.transform.position + lifeBarOffset);
    }


    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(player_PlatformerRef.transform.position + lifeBarOffset);
    }
}
