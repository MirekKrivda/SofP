using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer charSprite;
    [SerializeField] private DeathCountHandler deathCounter;
    [SerializeField] private GameObject deathUI;

    private bool isCrouching;
    private bool isDead;

    private float directionX;
    private float deathTimeDefault = 0.1f;
    private float deathTime;


    private Vector2 startPos;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        deathTime = deathTimeDefault;
        isDead = false;
    }

    void Update()
    {
        if (!isDead)
        {
            HandleJump();
        }
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            HandleMovement();
            HandleFlip();
            HandleJumpAnim();
            HandleWalkAnim();
            HandleCrouchAnim();
        }
        else
        {
            HandleDeath();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetPlayer();
        }
        
    }

    // Moves charakter horizontal with global key setting
    private void HandleMovement()
    {
        if (!isCrouching)
        {
            directionX = Input.GetAxisRaw("Horizontal");
            transform.Translate(new Vector3(directionX, 0, 0) * Time.deltaTime * movementSpeed);
        }
    }

    // Moves charakter vertical jump with global key setting
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2D.velocity.y)<0.1f)
        {
            rb2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    // Flips character sprite
    private void HandleFlip()
    {
        if (directionX < 0)
        {
            charSprite.flipX = true;
        }
        else if (directionX > 0)
        {
            charSprite.flipX = false;
        }
    }

    // Animation handler
    private void HandleJumpAnim()
    {
        if(rb2D.velocity.y < 0.1f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else if (rb2D.velocity.y > 0.1f)
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
        }
    }    
    private void HandleWalkAnim()
    {
        if (directionX > 0 || directionX < 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    private void HandleCrouchAnim()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isCrouching", true);
            isCrouching = true;
            playerCollider.offset = new Vector2(0f, -0.4f);
            playerCollider.size = new Vector2(0.4f, 0.2f);
        }
        else
        {
            playerCollider.offset = new Vector2(0f, -0.1f);
            playerCollider.size = new Vector2(0.4f, 0.8f);
            anim.SetBool("isCrouching", false);
            isCrouching = false;
        }
    }

    // Stops other animations and starts game over window
    public void StartDie()
    {
        if (!isDead)
        {
            isDead = true;
            //FreezePlayerPos(true);
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isDieing", true);
            anim.Play("MC_Dieing");
            deathUI.SetActive(true);
            deathCounter.AddDeathToCount();
        }

    }

    // Starts death animations
    private void HandleDeath()
    {
        deathTime -= Time.deltaTime;
        if (deathTime < 0)
        {
            anim.SetBool("isDieing", false);
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDieing", true);
        }
    }

    // Stops all character movement
    private void FreezePlayerPos(bool value)
    {
        if (value)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb2D.constraints = RigidbodyConstraints2D.None;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // Resets all player values, animation and positions
    public void ResetPlayer()
    {
        anim.Play("MC_Idle");
        anim.SetBool("isDieing", false);
        anim.SetBool("isDead", false);
        deathUI.SetActive(false);
        transform.position = startPos;
        //FreezePlayerPos(false);
        isDead = false;

    }
}
