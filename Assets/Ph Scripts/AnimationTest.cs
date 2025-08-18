using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using FMOD.Studio;


public class AnimationTest : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 latepos;
    
    [Header("Audio")]
    private EventInstance footSteps;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        footSteps = AudioManager.instance.CreateInstance(FMODEvents.instance.Footsteps);
    }

    // Update is called once per frame
    void Update()
    
    {
        footSteps.start();
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
    /*private void UpdateSound()
    {
        PLAYBACK_STATE playbackState;
        footSteps.getPlaybackState(out playbackState);
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            footSteps.start();
        }
        else
        {
            footSteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }*/
}
