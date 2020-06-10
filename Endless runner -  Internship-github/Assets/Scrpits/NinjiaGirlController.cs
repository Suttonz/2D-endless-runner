using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjiaGirlController : MonoBehaviour
{

    private Animator ninjiaGirlAnimatior;
    private Rigidbody2D ninjaGirlRigidBody;
    private float runSpeed = 3f;
    private Vector3 ninJaScale;
    private Player playerRef;
    private BoxCollider2D boxCollider;


    void Start()
    {
        ninjiaGirlAnimatior = GetComponent<Animator>();
        ninjaGirlRigidBody = GetComponent<Rigidbody2D>();
        playerRef = FindObjectOfType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        ninjaGirlRigidBody.velocity = new Vector2(runSpeed, ninjaGirlRigidBody.velocity.y);
        // transform.position = Vector2.MoveTowards(transform.position, ,runSpeed * Time.deltaTime);
    }

    //Player touches ninjaGirl will decrease player's energy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IsPlayer")
        {
            playerRef.DecreaseEnergy();
            Destroy(gameObject, 0.005f);
        }

        //ingore its own kind
        if (collision.gameObject.tag == "NinjaGirl" || collision.gameObject.tag == "Energy")
        {
            Physics2D.IgnoreCollision(collision.collider,boxCollider);
        }

        if(collision.gameObject.tag == "TurnLeft")
        {
            TurnLeft();
        }

        if (collision.gameObject.tag == "TurnRight")
        {
            TurnRight();
        }
    }

    //Controll NinjaGirl direction to make it patrol on the platform
    public void TurnLeft()
    {
         ninJaScale = transform.localScale;
         ninJaScale.x = -0.3f;
         transform.localScale = ninJaScale;
         runSpeed =-3f;
    }
    
    public void TurnRight()
    {
        ninJaScale = transform.localScale;
        ninJaScale.x = 0.3f;
        transform.localScale = ninJaScale;
        runSpeed = 3f;
    }
}
