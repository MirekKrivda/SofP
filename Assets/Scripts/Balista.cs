using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1;

    [SerializeField] private GameObject projectileStartPos;
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator anim;


    private bool isFacingRight;

    private float fireRate = 2.5f;
    private float timeToFire;
    private float reloadRate = 1.4f;
    private float timeToReload;



    void Awake()
    {
        isFacingRight = spriteRenderer.flipX;
        timeToFire = fireRate;
    }

    void Update()
    {
        timeToFire -= Time.deltaTime;
        timeToReload -= Time.deltaTime;
        if (timeToFire < 0)
        {
            timeToFire = fireRate;
            FireProjectile();
        }
        if (timeToReload<0)
        {
            anim.SetBool("isReloading", false);
        }
    }

    // creates new projectile object based on selected gameObject
    private void FireProjectile()
    {
        anim.SetBool("isReloading", true);
        timeToReload = reloadRate;
        GameObject projectile = Instantiate(projectilePrefab, projectileStartPos.transform.position, transform.rotation);
        projectile.GetComponent<ObjectMovement>().SetUp(isFacingRight, projectileSpeed);
    }

}

