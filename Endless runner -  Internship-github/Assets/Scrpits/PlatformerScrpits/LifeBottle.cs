using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBottle : MonoBehaviour
{
    private Animator lifeBottleAnimator;
    private int lifeBottleCount = 2;
    private Player_Platformer player_PlatformerRef;

    void Start()
    {
        lifeBottleAnimator = GetComponentInChildren<Animator>();
        player_PlatformerRef = FindObjectOfType<Player_Platformer>();
    }

    void Update()
    {
        DestroyLifeBottle();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerPlatformer")
        {
            lifeBottleAnimator.SetTrigger("Bounce");
            lifeBottleCount--;
        }
    }

    void DestroyLifeBottle()
    {
        if (lifeBottleCount <= 0)
        {
            AddPlayerLife();
            Destroy(this.gameObject,1f);
        }
    }
    
    void AddPlayerLife()
    {
        player_PlatformerRef.IncreaseLife(40f);
    }

    
}
