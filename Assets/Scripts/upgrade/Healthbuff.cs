using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "powerop_effect/Healthbuff")]

public class Healthbuff : powerup_effect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().health += amount;
    }
}
