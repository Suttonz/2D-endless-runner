using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    [SerializeField] float runSpeed;
    private float runSpeedValue;
    private Rigidbody2D mushroomRigidy;
    private Vector3 mushroomScale;
    private BoxCollider2D mushroomCollider;
    private Player_Platformer playerPlatformerRef;
    private BoxCollider2D boxCollider;
    
    

    void Start()
    {
        mushroomRigidy = GetComponent<Rigidbody2D>();
        runSpeedValue = runSpeed;
        mushroomCollider = GetComponent<BoxCollider2D>();
        playerPlatformerRef = FindObjectOfType<Player_Platformer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        
    }

    
    void Update()
    {
        mushroomRigidy.velocity = new Vector2(runSpeed, mushroomRigidy.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.IsTouching(boxCollider))
        {
           
            if (collision.gameObject.tag == "Left")
            {
                TurnLeft();
            }
            if (collision.gameObject.tag == "Right")
            {
                TurnRight();
            }

            if (collision.gameObject.tag == "LifeBottle" || collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Fire")
            {
                Physics2D.IgnoreCollision(collision.collider, mushroomCollider);
            }

        }
    }

    public void TurnLeft()
    {
        mushroomScale = transform.localScale;
        mushroomScale.x = -3f;
        transform.localScale = mushroomScale;
        runSpeed = -1* runSpeedValue;
    }

    public void TurnRight()
    {
        mushroomScale = transform.localScale;
        mushroomScale.x = 3f;
        transform.localScale = mushroomScale;
        runSpeed = 1* runSpeedValue;
    }

    
   
   
}
