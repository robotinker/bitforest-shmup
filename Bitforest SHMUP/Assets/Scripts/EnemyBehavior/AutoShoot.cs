using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    void Update()
    {
        foreach (var gun in GetComponentsInChildren<ProjectileLauncher>())
        {
            gun.Shoot();
        }
    }
}
