using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Player_Platformer : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float jumpHeight;
    private Rigidbody2D playerRigidbody;
    private Vector3 playerScale;
    private Animator playerAnimator;
    private CapsuleCollider2D capsuleCollider;
    private CircleCollider2D circleCollider;
    private bool onTheGround;
    private float climbHorizontal;
    [SerializeField] float climbSpeed;
    private float playerGravity;
    [SerializeField] float jumpAvaiableTime;
    private float jumpTimeCountDown;
    private bool isJumping;
    private bool isdoublejumpOK;
    [SerializeField] TextMeshProUGUI coinText;
    private int coinNum;
    [SerializeField] GameObject deathMenu;
    private float life;
    [SerializeField] Slider lifeBar;
    [SerializeField] TextMeshProUGUI lifeText;
    



    void Start()
    {

        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale;
        playerAnimator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        playerGravity = playerRigidbody.gravityScale;
        //life will be 100% when game start
        life = 100f;
        lifeBar.value = life;
        lifeText.text = life.ToString();
    }

    
    void Update()
    {
        Run();
        Jump();
        Climb();
        TriggerDeath();
        lifeText.text = life.ToString();
        coinText.text = coinNum.ToString();

    }

    //detect if player can jump or not
    void OnCollisionEnter2D(Collision2D collision)
    {
        if  (collision.collider.IsTouching(circleCollider))
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                onTheGround = true;
            }
            if(collision.collider.tag == "Mushroom")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.gameObject.GetComponent<Animator>().SetTrigger("Die");
                Destroy(collision.gameObject, 0.5f);
            }
        }

        if (collision.collider.IsTouching(capsuleCollider))
        {
           
            if(collision.gameObject.tag == "Mushroom")
            {
                Death();
            }
        }

       if (collision.collider.IsTouching(circleCollider) || collision.collider.IsTouching(capsuleCollider))
        {
            if(collision.gameObject.tag == "Left" || collision.gameObject.tag == "Right")
            {
                Physics2D.IgnoreCollision(collision.collider, circleCollider);
                Physics2D.IgnoreCollision(collision.collider, capsuleCollider);
            }
        }

       

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.IsTouching(capsuleCollider))
        {

            if (collision.gameObject.tag == "Mushroom")
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        lifeBar.gameObject.SetActive(false);
        deathMenu.SetActive(true);
        
    }


    private void OnCollisionExit(Collision collision)
    {
        
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.A) && onTheGround)
        {   //turn left
            playerRigidbody.velocity = new Vector2(-runSpeed, playerRigidbody.velocity.y);
            playerScale.x = -1f;
            transform.localScale = playerScale;
            playerAnimator.SetBool("Running", true);
            
        }
        if (Input.GetKeyDown(KeyCode.D) && onTheGround)
        {
            //turn right
            playerRigidbody.velocity = new Vector2(runSpeed, playerRigidbody.velocity.y);
            playerScale.x = 1f;
            transform.localScale = playerScale;
            playerAnimator.SetBool("Running", true);
        }
        
        //Stop running once play stop pressing left or right (A or D)
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {  
            playerAnimator.SetBool("Running", false);
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onTheGround)
            {
                
                jumpTimeCountDown = jumpAvaiableTime;
                isJumping = true;
                if (transform.localScale.x > 0)
                {
                    playerRigidbody.velocity = new Vector2(1.5f, jumpHeight);
                    StartCoroutine(StopMoving());


                }
                else if(transform.localScale.x < 0)
                {
                    playerRigidbody.velocity = new Vector2(-1.5f, jumpHeight);
                    StartCoroutine(StopMoving());
                }
                onTheGround = false;
                isdoublejumpOK = true;

            }else if (isdoublejumpOK)
            {
                jumpTimeCountDown = jumpAvaiableTime;
                if (transform.localScale.x > 0)
                {
                    playerRigidbody.velocity = jumpHeight*0.8f * Vector2.one;
                    StartCoroutine(StopMoving());

                }
                else if (transform.localScale.x < 0)
                {
                    playerRigidbody.velocity = new Vector2(-jumpHeight*0.8f, jumpHeight*0.8f);
                    StartCoroutine(StopMoving());
                }
                isdoublejumpOK = false;
            }
        }


        //Player can jump higher during given during when keep hold on the jump key
        if (Input.GetKey(KeyCode.Space))
        {

            if (jumpTimeCountDown > 0 && isJumping)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
                jumpTimeCountDown -= Time.deltaTime;
            }
        }

        if (jumpTimeCountDown <= 0 || (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)))
        {
            isJumping = false;
        }

    }

    void Climb()
    {

        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //float climbVertical = Input.GetAxisRaw("W");
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 1 *climbSpeed);
                playerRigidbody.gravityScale = 0f;
                playerAnimator.SetBool("Climbing", true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -1 * climbSpeed);
            }
    
        } 

        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            playerRigidbody.gravityScale = playerGravity;
            playerAnimator.SetBool("Climbing", false); 
        }
    }


    public void SwitchOffRigidbody()
    {
        playerRigidbody.bodyType = RigidbodyType2D.Static;
    }

    public void SwitchOnRigidbody()
    {
        playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }


    public void IncreaseLife(float lifeNum)
    {

        life += lifeNum;
        lifeBar.value += lifeNum;
       

        if (life >= 100f)
        {
            life = 100f;
        }
    }

    public void ReduceLife(float lifeNum)
    {
        life -= lifeNum;
        lifeBar.value -= lifeNum;
       

        if (life <= 0f)
        {
            life = 0f;
        }
    }

    public void SetLife(float lifeRef)
    {
        life = lifeRef;
        if(life > 100f)
        {
            life = 100f;
        }
    }

    public void TriggerDeath()
    {
        if (life <= 0)
        {
            Death();
        }
    }

    public Vector3 GetPositon()
    {
        return this.transform.position;
    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(0.8f);
        playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);

    }

    public void AddCoin(int coin)
    {
        coinNum += coin;
    }
}
