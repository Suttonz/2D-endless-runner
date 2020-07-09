using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{


    private Rigidbody2D playerRigidbody;
    public float runSpeed;
    [SerializeField] float jumpHeight;
    private bool isOnTheGround;
    private bool jumping;
    private Animator playerAnimator;
    private float jumpTimeCountDown;
    [SerializeField] float jumpAvaiableTime;
    private bool isdoublejumpOK;
    [SerializeField] GameObject deathMenu;
    private CircleCollider2D circleCollider;
    private BoxCollider2D boxCollider;
    private CapsuleCollider2D capsuleCollider;
    [SerializeField] EnergyController energyControllerRef;
    [SerializeField] float energyIncreaseUnit;
    [SerializeField] TileGenerator tileGeneratorRef;
    [SerializeField] GameObject dustParticle;
    [SerializeField] Text longestDistanceText;
    private SpriteRenderer spriteRenderer;
    private bool colorChange;
    [SerializeField] GameObject bloodSplatter;
    private float longestDistance;
    private float currentDistance;
    private float lastRoundLongestDistance;
    [SerializeField] int jumpCount;
    [SerializeField]GameObject weapon;
    Transform shootPoint;
    public bool canHurt;
    private Color playerColor;
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] AudioSource energyBottleSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource shurikenSound;
    [SerializeField] AudioSource bleedSound;
    [SerializeField] AudioSource diamonSound;
    private bool soundEffectOK = true;

    void Start()
    {

        Time.timeScale = 0f;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        isdoublejumpOK = false;
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        //Display the longest distance the player has reached so far
        longestDistance = PlayerPrefs.GetFloat("LongestDistance");
        longestDistanceText.text = PlayerPrefs.GetFloat("LongestDistance").ToString("f0");
        shootPoint = transform.Find("ShootPoint");
        canHurt = true; 

        //get player Render's color component 
        playerColor = GetComponent<Renderer>().material.color;
        
        //Get backgroundmusic Volume
        Debug.Log("BackgroundMusic" + PlayerPrefs.GetFloat("BackgroundMusicVolume").ToString());
        backGroundMusic.volume = PlayerPrefs.GetFloat("BackgroundMusicVolume");
        //Get soundeffect Volume
        Debug.Log("BackgroundMusic" + PlayerPrefs.GetFloat("SoundEffectVolume").ToString());
        energyBottleSound.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
        jumpSound.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
        shurikenSound.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
        bleedSound.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
        diamonSound.volume = PlayerPrefs.GetFloat("SoundEffectVolume");

    }


    void Update()
    {
        Run();
        Jump();
        ActiveAnimation();
        Attack();

    }

   
    //prevent the player keep endless jumping when he is not on the tile 
    void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "GroundToo")
        {
            isOnTheGround = true;
        }*/


        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnTheGround = true;
            //trigger dust effect when it hits the ground
            Instantiate(dustParticle, transform.position, transform.rotation);
        }

        //Active DeathMeau when player trigger the deathdetector collider
        else if ( collision.gameObject.tag == "Death")
        {
            Death();    
        }

        else if (collision.collider.IsTouching(boxCollider))
        {
            if (collision.gameObject.tag == "Energy")
            {
                energyControllerRef.IncreaseEnergy(energyIncreaseUnit);
                energyBottleSound.Play();
                Destroy(collision.gameObject);
            
            }/*else if(collision.gameObject.tag =="Obstable")
            {
                energyControllerRef.ReduceEnergy(15f);
            }*/
        }

        //Ingore Turn Left and turn right collider
        if (collision.gameObject.tag == "TurnLeft")
        {
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
            Physics2D.IgnoreCollision(collision.collider, circleCollider);
        }

        if (collision.gameObject.tag == "TurnRight")
        {
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
            Physics2D.IgnoreCollision(collision.collider, circleCollider);
        }

    }

    //prevent the player keep endless jumping when he is not on the tile 
    void OnCollisionExit2D(Collision2D collision)
    {
       /* if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "GroundToo" )
        {
            isOnTheGround = false;
        }*/

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnTheGround = false;
        }
    }

   
    public void Death()
    {
        backGroundMusic.Stop();
        //Save longest distance to disk
        //Debug.Log("Saving longest distance" + longestDistance.ToString());
        PlayerPrefs.SetFloat("LongestDistance", longestDistance);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        Cursor.visible = true;
        deathMenu.SetActive(true);
        tileGeneratorRef.ToogleIsUsable(false);
    }

    void ActiveAnimation()
    {
        playerAnimator.SetFloat("Speed", playerRigidbody.velocity.x);
        playerAnimator.SetBool("OnTheGround", isOnTheGround);
    }

    void Run()
    {
        
       playerRigidbody.velocity = new Vector2(runSpeed, playerRigidbody.velocity.y);
       
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //make sure there is no sound effect trigger before the background story fade away with wrong key press
            if (soundEffectOK)
            {
                shurikenSound.Play();
            }
            Instantiate(weapon,shootPoint.position,shootPoint.rotation);
        }
    }

    /*void DoubleJump()
    {
        //Player can click jump twice to complete a double jump in the air
        //check if the player is on the gorund to trigger the double jump

        if (isOnTheGround)
        {
            isdoublejumpOK = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);

        }
        else if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isdoublejumpOK == true)
        {
            
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isdoublejumpOK == false && isOnTheGround == true)
        {
            Jump();
        }
       
    }*/

    void Jump()
    {
 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            
            if (isOnTheGround) 
            {
                //make sure there is no sound effect trigger before the background story fade away with wrong key press
                if (soundEffectOK)
                {
                    jumpSound.Play();
                }
                jumping = true;
                isdoublejumpOK = true;
                jumpTimeCountDown = jumpAvaiableTime;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);

            } else if (isdoublejumpOK)
            {
                Debug.Log("Double Jump");
                //make sure there is no sound effect trigger before the background story fade away with wrong key press
                if (soundEffectOK)
                {
                    jumpSound.Play();
                }
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
                jumpTimeCountDown = jumpAvaiableTime;
                //Dust effect when it jump
                Instantiate(dustParticle, transform.position, transform.rotation);
                isdoublejumpOK = false;
            }
            
        }

        //Player can jump higher during given during when keep hold on the jump key
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            
            if (jumpTimeCountDown > 0 && jumping)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
                jumpTimeCountDown -= Time.deltaTime;
            }
        }

        if(jumpTimeCountDown <= 0 || (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)))
        {
            jumping = false;
        }

    }

  

    public Vector3 GetPositon()
   {
       return this.transform.position;
   }

   

  public void DecreaseEnergy()
  {
        //only can hurt the player if the bool canhurt is true
        if (canHurt)
        {
            bleedSound.Play();
            //Trigger blood splatter particle
            energyControllerRef.ReduceEnergy(15f);
            Instantiate(bloodSplatter, transform.position, transform.rotation);
        }
       
  }

  public void ToogleCanhurt(bool canHurtref)
  {
      canHurt = canHurtref;
  }

  public void TooglePlayerTransparency(float transparency)
  {
      playerColor.a = transparency;
      GetComponent<Renderer>().material.color = playerColor;
  }


  public void SetlongestDistance(float currentDistance)
  {

    if ( currentDistance > longestDistance)
    {
        longestDistance = currentDistance;
 
    } else if (longestDistance < 1f)
    {
        longestDistance = 0f;
    }
    
  }

  public void PlayDiamondSoud()
  {
        diamonSound.Play();
  }
  
  public void PlayBackgroundMusic()
  {
        backGroundMusic.Play();
  }
  

  public void ToggleSoundEffectOK(bool reference)
  {
        soundEffectOK = reference;
  }
}
