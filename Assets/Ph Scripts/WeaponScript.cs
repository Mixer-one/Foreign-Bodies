using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float damage;
    [SerializeField]private BoxCollider triggerBox;
    // Start is called before the first frame update
    void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.HP -= damage;
            print("bingbong");
            if (enemy.HP <= 0)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    public void EnableTriggerBox()
    {
        triggerBox.enabled = true;
    }

    public void DisableTriggerBox()
    {
        triggerBox.enabled = false;
    }

}
