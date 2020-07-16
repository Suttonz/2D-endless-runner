using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    [SerializeField] float smokeMovingSpeed;
    [SerializeField] GameObject smokeDestoryPoint;
    private Player_Platformer player_PlatformerRef;


    void Start()
    {
        player_PlatformerRef = FindObjectOfType<Player_Platformer>();
    }


  
    void Update()
    {
        Moving();
        DestorySmoke();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerPlatformer")
        {
            player_PlatformerRef.Death();
        }
    }

    void Moving()
    {

        float movingUnit = smokeMovingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, smokeDestoryPoint.transform.position, movingUnit);

    }

    void DestorySmoke()
    {
        if(this.transform.position.y > smokeDestoryPoint.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
