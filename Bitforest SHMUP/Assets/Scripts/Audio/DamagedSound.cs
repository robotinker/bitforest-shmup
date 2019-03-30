using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamagedSound : SoundBase
{
    protected override void Start()
    {
        base.Start();

        GetComponent<Health>().OnDamage += PlaySound;
    }
}
