using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isSpikeTriggerd;

    private float spikeTime;
    private float spikeTimeDefault = 0.95f;

    private GameObject playerGO;

    private void Awake()
    {
        playerGO = GameObject.Find("Player");
        spikeTime = spikeTimeDefault;
    }
    void Update()
    {
        SpikeTriggerHandler();
    }

    // Handles spike animations
    private void SpikeTriggerHandler()
    {
        if (isSpikeTriggerd)
        {
            spikeTime -= Time.deltaTime;
            if (spikeTime < 0)
            {
                spikeTime = spikeTimeDefault;
                isSpikeTriggerd = false;
                animator.SetBool("isSpikeTriggerd", false);
            }
        }
    }

    // Triggers player charakter death
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            animator.SetBool("isSpikeTriggerd", true);
            isSpikeTriggerd = true;
            playerGO.GetComponent<MovementHandler>().StartDie();
        }
    }
}
