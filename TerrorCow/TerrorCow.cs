using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorCow : MonoBehaviour
{
    public float moveSpeed;
    public float turboSpeed;
    public float knockBack;

    private bool facingRight = true;
    private Rigidbody2D thisRigidBody;

    private Animator anim;
    private SpriteRenderer sprite;

    private float moveDirectoin;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private bool hurt = false;
    private float hurtDelay = 0f;

    public GameController gameController;

    public int boosterFuel = 100;
    private float boosterTimer = 0.1f;
    private bool outOfFuel = false;

    public AudioSource boosterSound;
    public AudioSource mooSound;
    public AudioSource hitSound;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gameController.setBooster(boosterFuel);
    }

    void Update()
    {
        moveTerror();
        animateTerror();
        checkIfGrounded();
        hurtTerror();
        manageBooster();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            hurt = true;
        }
        if (other.tag == "Fatal")
        {
            gameController.setLives(-10);
        }
    }


    //// INTERNAL FUNCTIONS ////
    
    private void hurtTerror()
    {
        if (hurt == true)
        {
            if (facingRight)
            {
                thisRigidBody.velocity = new Vector3(-20f, 2f, 0f);
            }else
            {
                thisRigidBody.velocity = new Vector3(20f, 2f, 0f);
            }
            gameController.setLives(-1);
            mooSound.Play();
            hitSound.Play();
            hurt = false;
        }
    }

    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x*(-1), transform.localScale.y, transform.localScale.y);
    }

    private void moveTerror()
    {
        moveDirectoin = Input.GetAxisRaw("Horizontal");
        if (moveDirectoin > 0 && !facingRight)
        {
            flipCharacter();
        }
        if (moveDirectoin < 0 && facingRight)
        {
            flipCharacter();
        }
        thisRigidBody.velocity = new Vector3(moveDirectoin * moveSpeed, thisRigidBody.velocity.y, 0f);

        if( Input.GetKey("w") && !outOfFuel) {
            thisRigidBody.velocity = new Vector3(thisRigidBody.velocity.x, turboSpeed, 0f);
            if (!boosterSound.isPlaying)
            {
                boosterSound.Play();
            }
        }
        else
        {
            if (boosterSound.isPlaying)
            {
                boosterSound.Stop();
            }
        }
    }

    private void manageBooster ()
    {
        if (Input.GetKey("w") && !outOfFuel)
        {
            if(boosterTimer > 0)
            {
                boosterTimer -= Time.deltaTime;
            }
            else
            {
                boosterTimer = 0.1f;
                boosterFuel -= 2;
                if(boosterFuel <= 0)
                {
                    outOfFuel = true;
                }
                gameController.setBooster(boosterFuel);
            }
        }
        else
        {
            if (boosterTimer > 0)
            {
                boosterTimer -= Time.deltaTime;
            }
            else
            {
                if (boosterFuel < 100)
                {
                    boosterTimer = 0.15f;
                    boosterFuel += 1;
                    if (boosterFuel > 20)
                    {
                        outOfFuel = false;
                    }
                    gameController.setBooster(boosterFuel);
                }
            }
        }
        
    }

    private void animateTerror()
    {
        if (isGrounded)
        {
            anim.SetBool("isFlying", false);
            if (moveDirectoin != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
        
        if(!isGrounded && Input.GetKey("w"))
        {
           anim.SetBool("isFlying", true);
        }else
        {
           anim.SetBool("isFlying", false);
        }

        if (hurt == true && hurtDelay <= 0)
        {
            hurtDelay = 0.5f;
            sprite.color = new Color(1, 0.5f, 0.5f, 1);
        }
        if(hurtDelay > 0f)
        {
            hurtDelay -= Time.deltaTime;
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void checkIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    //// EXTERNAL FUNCTIONS ////
    public bool isFacingRight()
    {
        return facingRight;
    }

}
