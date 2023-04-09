using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class powerup_effect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
