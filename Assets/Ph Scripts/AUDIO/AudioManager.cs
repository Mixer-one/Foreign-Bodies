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
    private EventInstance musicEventInstance;

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
        InitializeMusic(FMODEvents.instance.music);
    }

    public void SetAmbienceParamater(string paramName, float paramValue)
    {
        ambienceEventInstance.setParameterByName(paramName, paramValue);
        Debug.Log(paramName + paramValue);
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
    
    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public void SetMusicArea(MusicArea area)
    {
        musicEventInstance.setParameterByName("area", (float)area);
    }
}
