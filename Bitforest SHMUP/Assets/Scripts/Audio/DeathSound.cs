using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathSound : SoundBase
{
    protected override void Start()
    {
        base.Start();

        GetComponent<Health>().OnDeath += PlaySound;
    }
}
