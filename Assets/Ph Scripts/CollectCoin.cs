using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject player;
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerMovement.coins++;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.coinCollected, this.transform.position);
            // remember to add coin collection script to player
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.coinCollected, this.transform.position);
        }
    }
}
