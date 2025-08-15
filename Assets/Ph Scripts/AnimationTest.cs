using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 latepos;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    
    {
        if (player.transform.position != latepos)
        {
            animator.SetBool("Running", true);
        }
        else if (player.transform.position == latepos)
        {
            animator.SetBool("Running", false);
        }
    }

    private void LateUpdate()
    {
        latepos = player.transform.position;
    }
}
