using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.coins  == 3)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.unlockDoor, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
