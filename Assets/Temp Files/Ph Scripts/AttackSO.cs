using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Attacks/BasicAttacks")]
public class AttackSO : ScriptableObject
{
    public AnimatorOverrideController AnimatOV;
    public float damage;
}
