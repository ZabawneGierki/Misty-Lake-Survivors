using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : WeaponBase
{
    public float damagePerTick = 5f;
    public float tickRate = 0.2f; // damage every 0.2s
    public float lifetime = 1f;   // how long beam exists
    protected override void Fire()
    {
        throw new System.NotImplementedException();
    }
}
