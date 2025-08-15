using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CollectCoin : MonoBehaviour
{
    [SerializeField] private EventReference collectCoin; 
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlayOneShot(collectCoin, this.transform.position);
            Debug.Log("ferfwaef");
            //Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlayOneShot(collectCoin, this.transform.position);
            Debug.Log("ferfwaef");
        }
    }
}
