using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : SoundBase
{
    protected override void Start()
    {
        base.Start();
        foreach (var launcher in GetComponentsInChildren<ProjectileLauncher>())
        {
            launcher.OnShoot += PlaySound;
        }
    }
}
