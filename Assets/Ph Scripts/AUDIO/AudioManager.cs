using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set;}
    private EventInstance ambienceEventInstance;

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

    void Start()
    {
        InitializeAmbiance(FMODEvents.instance.wind);
    }

    public void SetAmbienceParamater(string paramName, float paramValue)
    {
        ambienceEventInstance.setParameterByName(paramName, paramValue);
    }

    public void PlayOneShot(EventReference sound, Vector3 WorldPos)
    {
        RuntimeManager.PlayOneShot(sound, WorldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    private void InitializeAmbiance(EventReference ambianceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambianceEventReference);
        ambienceEventInstance.start();
    }
}
