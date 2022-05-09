using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private bool isFacingRight = false;

    private float lifeTime = 5f;
    private float projectileSpeed = 1f;

    private GameObject playerGO;

    private void Awake()
    {
        playerGO = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        DirectionMovementHandler();
        LifeTimeHandler();
    }

    // Destroys object after defined Time
    private void LifeTimeHandler()
    {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    // Moves object in defined Direction
    private void DirectionMovementHandler()
    {
        if (isFacingRight)
        {
            transform.position = new Vector2(transform.position.x + (projectileSpeed * Time.fixedDeltaTime), transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - (projectileSpeed * Time.fixedDeltaTime), transform.position.y);
        }
    }

    // Sets up direction and settings for projectile
    public void SetUp(bool isFacingRight, float projectileSpeed)
    {
        if (isFacingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        this.isFacingRight = isFacingRight;
        this.projectileSpeed = projectileSpeed;

    }

    // Destroys projectile on collision with Player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Destroy(gameObject);
            playerGO.GetComponent<MovementHandler>().StartDie();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Destroys projectile on collision in Player (Bugfix)
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Destroy(gameObject);
            playerGO.GetComponent<MovementHandler>().StartDie();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
