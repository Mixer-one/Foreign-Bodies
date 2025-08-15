using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference Footsteps { get; private set; }
    [field: Header("Coin SFX")]
    [field: SerializeField] public EventReference coinCollected { get; private set; }
    public static FMODEvents instance { get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("FMODEvents instance already exists in this scene.");
        }
        else
        {
            instance = this;
        }
    }
}
