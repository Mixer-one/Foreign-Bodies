using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("audio manager instance already exists in this scene.");
        }
        else
        {
            instance = this;
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 WorldPos)
    {
        RuntimeManager.PlayOneShot(sound, WorldPos);
    }
}
